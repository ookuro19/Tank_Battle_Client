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
            tm.eid = eid;
            PlayerEnterIn(tm);

            Debug.LogError("onEnterWorld, Player: " + eid);
        }
        else
        {
            TankManager tm = new TankManager();
            tm.m_account = account;
            tm.eid = eid;
            PlayerEnterIn(tm);
            Debug.LogError("onEnterWorld, Enemy" + eid);
        }
    }

    private void PlayerEnterIn(TankManager tPlayer)
    {
        g_tankList.Add(tPlayer);
        if (g_tankList.Count == 2)
        {
            g_tankList.Sort((x, y) => x.eid.CompareTo(y.eid));
            for (int i = 0; i < g_tankList.Count; i++)
            {
                Debug.Log("g_tankList[i].eid is: " + g_tankList[i].eid);
            }
        }
    }
}
