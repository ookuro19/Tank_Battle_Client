using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class ClientCore : MonoBehaviour
{
    public static ClientCore Instance;

    public static List<TankManager> g_tankList = new List<TankManager>();

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    public void AccountEnterWorld(int eid, KBEngine.Avatar account)
    {
        // Debug.LogError("account.isPlayer():  " + account.isPlayer());
        if (account.isPlayer())
        {
            KBEngine.Avatar tAccount = (KBEngine.Avatar)KBEngineApp.app.player();
            if (tAccount == null)
            {
                Debug.Log("wait create(palyer)!");
                return;
            }

            TankManager tm = new TankManager();
            tm.m_account = account;
            tm.SetCurPlayer();
            tm.m_roomNo = account.roomNo;
            tm.m_avatarName = account.name;
            PlayerEnterIn(tm);

            Debug.LogError("onEnterWorld, Player: " + account.name);
        }
        else
        {
            TankManager tm = new TankManager();
            tm.m_account = account;
            tm.m_roomNo = account.roomNo;
            tm.m_avatarName = account.name;
            PlayerEnterIn(tm);
            Debug.LogError("onEnterWorld, Enemy" + account.name);
        }
    }

    private void PlayerEnterIn(TankManager tPlayer)
    {
        g_tankList.Add(tPlayer);
        if (g_tankList.Count == 2)
        {
            g_tankList.Sort((x, y) => x.m_roomNo.CompareTo(y.m_roomNo));
        }
    }
}
