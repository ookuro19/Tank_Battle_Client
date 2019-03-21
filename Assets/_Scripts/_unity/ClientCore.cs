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

    // Use this for initialization
    void Start()
    {
        Instance = this;
        installEvents();
    }

    void Update()
    {
        Debug.LogErrorFormat("distance:{0}", Vector3.Distance(g_tankList[0].m_Instance.transform.position, g_tankList[1].m_Instance.transform.position));
    }

    public void AccountEnterWorld(int eid, KBEngine.Avatar account)
    {
        TankManager tm = new TankManager();
        tm.SetAvatar(account);
        g_tankDict.Add(account.id, tm);
        g_tankList.Add(tm);
        g_tankList.Sort((x, y) => x.m_roomNo.CompareTo(y.m_roomNo));
    }

    #region KBEngine
    void installEvents()
    {
        // world
        KBEngine.Event.registerOut("set_position", this, "set_position");
        KBEngine.Event.registerOut("updatePosition", this, "updatePosition");
        KBEngine.Event.registerOut("set_direction", this, "set_direction");
    }

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
    #endregion
}
