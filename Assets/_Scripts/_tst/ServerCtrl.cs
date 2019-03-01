using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using UnityEngine.SceneManagement;

public class ServerCtrl : MonoBehaviour
{
    public static List<TankManager> g_tankList = new List<TankManager>();

    #region Unity Method
    void Start()
    {
        installEvents();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        KBEngine.Event.fireIn("logout");
    }
    #endregion

    #region KBEngine
    void installEvents()
    {
        KBEngine.Event.registerOut("onAccountEnterWorld", this, "onAccountEnterWorld");
        KBEngine.Event.registerOut("set_position", this, "set_position");
        KBEngine.Event.registerOut("updatePosition", this, "updatePosition");
    }

    public void onAccountEnterWorld(UInt64 rndUUID, Int32 eid, Account account)
    {
        if (!account.isPlayer())
        {
            Account tAccount = (Account)KBEngineApp.app.player();
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
            StartCoroutine(GameStart());
        }
    }

    IEnumerator GameStart()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("World");
        yield return async;
    }

    public void updatePosition(KBEngine.Entity entity)
    {
        Debug.Log(string.Format("updatePosition:: entity: {0}, pos: {1}", entity.id, entity.position));
        if (entity.renderObj == null)
        {
            Debug.LogError("entity.renderObj == null");
            return;
        }

        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        // Vector3 currpos = new Vector3(entity.position.x, entity.position.z, go.transform.position.z);
        go.transform.position = entity.position;
    }

    public void set_position(KBEngine.Entity entity)
    {
        Debug.Log(string.Format("set_position::entity: {0}, pos: {1}", entity.id, entity.position));
        if (entity.renderObj == null)
            return;

        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        Vector3 currpos = new Vector3(entity.position.x, entity.position.z, go.transform.position.z);
        go.transform.position = currpos;
    }
    #endregion
}
