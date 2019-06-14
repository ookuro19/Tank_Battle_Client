using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPropBehavior : MonoBehaviour
{
    public GameObject prefab_Mine;
    public GameObject m_shield;
    public Transform tran_mineSpawn;
    //Server
    [HideInInspector] public bool m_isPlayer = false;
    [HideInInspector] public TankManager m_tankmanager = null;
    private string m_usePropBtn;                // The input axis that is used for launching shells.
    private EPropType m_curPropType = EPropType.ept_None;

    private void Start()
    {
        // The fire axis is based on the player number.
        m_usePropBtn = "Fire";
    }

    private void Update()
    {
        if (!m_isPlayer)
        {
            return;
        }

        if (Input.GetButtonDown(m_usePropBtn))
        {
            switch (m_curPropType)
            {
                case EPropType.ePT_Shell:
                    {
                        m_curPropType = EPropType.ept_None;
                        m_tankmanager.useSkill(m_tankmanager.m_eid, EPropType.ePT_Shell);
                        break;
                    }
                case EPropType.ePT_Mine:
                    {
                        m_curPropType = EPropType.ept_None;
                        m_tankmanager.useSkill(m_tankmanager.m_eid, EPropType.ePT_Mine);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

    public void onGetProp(EPropType type)
    {
        m_curPropType = type;
    }

    public void onUseSkill(TankManager target, EPropType type, Vector3 pos)
    {
        Debug.LogErrorFormat("TankPropBehavior::onUseSkill {0}", type);
        switch (type)
        {
            case EPropType.ePT_Shell:
                {
                    StopCoroutine("ieUseSheild");
                    StartCoroutine("ieUseSheild");
                    break;
                }
            case EPropType.ePT_Mine:
                {
                    Vector3 tPos = 100f * new Vector3(pos.x, pos.z, pos.y);
                    GameObject.Instantiate(prefab_Mine, tPos, Quaternion.identity);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void onSkillResult(TankManager target, EPropType type)
    {
        Debug.LogErrorFormat("TankPropBehavior::onSkillResult {0}", type);

    }
    IEnumerator ieUseSheild()
    {
        m_shield.SetActive(true);
        yield return new WaitForSeconds(5f);
        m_shield.SetActive(false);
    }
}
