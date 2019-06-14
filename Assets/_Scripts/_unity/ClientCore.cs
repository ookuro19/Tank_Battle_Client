using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class ClientCore : MonoBehaviour
{
    public static ClientCore Instance;

    // 以玩家ID为key的dictionary
    public static Dictionary<int, TankManager> g_tankDict = new Dictionary<int, TankManager>();

    // 按座位号排序的列表
    public static List<TankManager> g_tankList = new List<TankManager>();

    public static Dictionary<string, PropBehavior> g_propDict = new Dictionary<string, PropBehavior>();

    // Use this for initialization
    void Start()
    {
        Instance = this;
        installEvents();
    }

    void installEvents()
    {
        // world
        KBEngine.Event.registerOut("set_position", this, "set_position");
        KBEngine.Event.registerOut("updatePosition", this, "updatePosition");
        KBEngine.Event.registerOut("set_direction", this, "set_direction");
    }

    public void AccountEnterWorld(int eid, KBEngine.Avatar account)
    {
        TankManager tm = new TankManager();
        tm.SetAvatar(account);
        g_tankDict.Add(account.id, tm);
        g_tankList.Add(tm);
        g_tankList.Sort((x, y) => x.m_roomNo.CompareTo(y.m_roomNo));
    }

    public void onAvatarControlled(KBEngine.Avatar avatar, bool isControlled_)
    {
        Debug.LogErrorFormat("Avatar id {0} iscontroller {1}", avatar.id, isControlled_);
        // if (isControlled_)
        // {
        //     GameObject tGO = avatar.renderObj as GameObject;
        //     tGO.AddComponent<AutoMove>();
        //     tGO.GetComponent<Collider>().enabled = false;
        // }
    }

    public void ExitRoom()
    {
        for (int i = 0; i < g_tankList.Count; i++)
        {
            g_tankList[i].m_Instance = null;
            g_tankList[i].m_avatar.renderObj = null;
        }
        g_tankDict.Clear();
        g_tankList.Clear();
    }

    #region Transform
    public void updatePosition(KBEngine.Entity entity)
    {
        // Debug.LogFormat("updatePosition:: entity: {0}, pos: {1}", entity.id, entity.position);
        if (entity.renderObj == null)
        {
            Debug.LogError("entity.renderObj == null");
            return;
        }

        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        Vector3 currpos = new Vector3(entity.position.x, entity.position.z, entity.position.y);
        go.transform.position = currpos * 100f;
    }

    public void set_position(KBEngine.Entity entity)
    {
        // Debug.LogFormat("set_position::entity: {0}, pos: {1}", entity.id, entity.position);
        if (entity.renderObj == null)
            return;

        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        Vector3 currpos = new Vector3(entity.position.x, entity.position.z, entity.position.y);
        go.transform.position = currpos * 100f;
    }

    public void set_direction(KBEngine.Entity entity)
    {
        // Debug.LogFormat("set_direction::entity: {0}, rot: {1}", entity.id, entity.direction);
        if (entity.renderObj == null)
            return;

        ((UnityEngine.GameObject)entity.renderObj).transform.eulerAngles = 180f / (float)System.Math.PI *
            new Vector3(entity.direction.y, entity.direction.z, entity.direction.x);
    }
    #endregion Transform

    #region Props
    public void onGetProps(int eid, string propKey, int type)
    {
        if (g_tankDict.ContainsKey(eid))
        {
            g_tankDict[eid].onGetProps(type);
        }

        if (g_propDict.ContainsKey(propKey))
        {
            g_propDict[propKey].DisableProp();
        }
    }

    /// <summary>
    /// 恢复道具
    /// </summary>
    /// <param name="propsList">道具列表</param>
    public void onResetProp(List<string> propsList)
    {
        for (int i = 0; i < propsList.Count; i++)
        {
            Debug.Log("onResetPropClient " + propsList[i]);
            if (g_propDict.ContainsKey(propsList[i]))
            {
                g_propDict[propsList[i]].ResetProp();
            }
        }
    }
    #endregion Props

    #region Skill
    public int GetEnemyID(int selfID)
    {
        int tid = 0;
        if (g_tankDict.ContainsKey(selfID))
        {
            foreach (var key in g_tankDict.Keys)
            {
                // Debug.LogFormat("g_tankDict key is : {0}", key);
                if (key != selfID)
                {
                    tid = key;
                    break;
                }
            }
        }
        else
        {
            tid = 0;
        }

        // Debug.LogFormat("player {0} enemy is : {1}", selfID, tid);

        return tid;
    }

    /// <summary>
    /// 有玩家施放技能
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="prop">本来是技能编号，本游戏中作为炮弹力度大小</param>
    public void onUseSkill(int userID, int targetID, int prop, Vector3 pos)
    {
        if (g_tankDict.ContainsKey(userID)
                && g_tankDict.ContainsKey(targetID))
        {
            g_tankDict[userID].onUseSkill(g_tankDict[targetID], (EPropType) prop, pos);
        }
    }

    /// <summary>
    /// 技能施放结果回调
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="suc">结算结果：0命中，1未命中</param>
    public void onSkillResult(int userID, int targetID, int type, int suc)
    {
        if (g_tankDict.ContainsKey(targetID))
        {
            g_tankDict[userID].onSkillResult(g_tankDict[targetID], type, suc);
        }
    }
    #endregion skill

    #region Equipment
    /// <summary>
    /// 得到金币
    /// </summary>
    /// <param name="tGold"></param>
    public void regGetGold(int tGold)
    {
        ServerEvents.Instance.regGetGold(tGold);
    }

    /// <summary>
    /// 购买装备
    /// </summary>
    /// <param name="itemID">装备id</param>
    public void regBuyEquip(int itemID)
    {
        ServerEvents.Instance.regBuyEquip(itemID);
    }

    /// <summary>
    /// 切换装备
    /// </summary>
    /// <param name="itemID">装备id</param>
    public void regChangeEquip(int itemID)
    {
        ServerEvents.Instance.regChangeEquip(itemID);
    }
    #endregion Equipment
}
