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
    }

    public void AccountEnterWorld(int eid, KBEngine.Avatar account)
    {
        TankManager tm = new TankManager();
        tm.SetAvatar(account);
        g_tankDict.Add(account.id, tm);
        g_tankList.Add(tm);
        g_tankList.Sort((x, y) => x.m_roomNo.CompareTo(y.m_roomNo));
    }
}
