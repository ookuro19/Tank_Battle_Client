using System;
using UnityEngine;
using KBEngine;

[Serializable]
public class TankManager
{
    // This class is to manage various settings on a tank.
    // It works with the GameManager class to control how the tanks behave
    // and whether or not players have control of their tank in the 
    // different phases of the game.

    public Color m_PlayerColor = Color.blue;                // This is the color this tank will be tinted.
    public Transform m_SpawnPoint;                          // The position and direction the tank will have when it spawns.
    [HideInInspector] public int m_PlayerNumber;            // This specifies which player this the manager for.
    [HideInInspector] public string m_ColoredPlayerText;    // A string that represents the player with their number colored to match their tank.
    [HideInInspector] public GameObject m_Instance;         // A reference to the instance of the tank when it is created.
    [HideInInspector] public int m_Wins;                    // The number of wins this player has so far.

    private TankMovement m_movement;                        // Reference to tank's movement script, used to disable and enable control.
    private TankShooting m_shooting;                        // Reference to tank's shooting script, used to disable and enable control.
    private TankHealth m_health;                          // Reference to tank's health script, used to disable and enable control.
    private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.

    //server
    public bool entityEnabled = true;
    public KBEngine.Avatar m_avatar { get; private set; }
    public int m_eid { get; private set; }
    public int m_roomNo { get; private set; }
    public string m_avatarName { get; private set; }
    private bool isPlayer = false;
    private EPropType m_curPropType = EPropType.ept_None;

    public void SetAvatar(KBEngine.Avatar tAccount)
    {
        m_avatar = tAccount;
        m_eid = tAccount.id;
        m_roomNo = tAccount.roomNo;
        m_avatarName = tAccount.name;
        isPlayer = tAccount.isPlayer;
        m_curPropType = EPropType.ept_None;

        Debug.LogErrorFormat("onEnterWorld,{0} is Player: {1} ", m_avatarName, isPlayer);
    }

    public void Setup()
    {
        m_Instance.GetComponent<Collider>().enabled = isPlayer;
        // Get references to the components.
        m_movement = m_Instance.GetComponent<TankMovement>();
        m_shooting = m_Instance.GetComponent<TankShooting>();
        m_health = m_Instance.GetComponent<TankHealth>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        m_movement.m_avatar = m_avatar;
        m_shooting.m_isPlayer = isPlayer;
        m_shooting.m_tankmanager = this;
        m_health.SetIDText(m_avatarName);
        // Create a string using the correct color that says 'PLAYER 1' etc based on the tank's color and the player's number.
        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        // Get all of the renderers of the tank.
        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        // Go through all the renderers...
        for (int i = 0; i < renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            renderers[i].material.color = m_PlayerColor;
        }
    }

    // Used during the phases of the game where the player shouldn't be able to control their tank.
    public void DisableControl()
    {
        m_movement.enabled = false;
        m_shooting.enabled = false;

        m_CanvasGameObject.SetActive(false);
    }

    // Used during the phases of the game where the player should be able to control their tank.
    public void EnableControl()
    {
        m_movement.enabled = true;
        m_shooting.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }

    // Used at the start of each round to put the tank into it's default state.
    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }

    public void entityEnable()
    {
        entityEnabled = true;
    }

    public void entityDisable()
    {
        entityEnabled = false;
    }

    public int GetProgress()
    {
        if (m_avatar == null)
        {
            return 0;
        }
        return m_avatar.progress;
    }

    public void onGetProps(int type)
    {
        Debug.LogErrorFormat("id: {0} get props {1}", m_eid, (EPropType)type);
        m_curPropType = (EPropType)type;
    }

    public void useSkill(int targetID, int type)
    {
        if ((int)m_curPropType == type)
        {
            m_curPropType = EPropType.ept_None;
            ServerEvents.Instance.useSkill(targetID, type);
        }
        else
        {
            Debug.LogErrorFormat("You dont have this prop " + (EPropType)type);
        }
    }

    // 向target使用技能
    public void onUseSkill(TankManager targetTM, int type, Vector3 pos)
    {
        switch ((EPropType)type)
        {
            case EPropType.ePT_Bullet:
                {
                    m_shooting.onUseSkill(targetTM, type);
                    break;
                }
            case EPropType.ePT_Shell:
                {
                    
                    break;
                }
            default:
                {
                    break;
                }
        }

    }

    /// <summary>
    /// 被使用技能的结算结果
    /// </summary>
    /// <param name="suc">结算结果：0命中，1未命中</param>
    public void onSkillResult(int suc)
    {
        if (suc == 0)
        {
            m_health.TakeDamage(10);
        }
    }
}
