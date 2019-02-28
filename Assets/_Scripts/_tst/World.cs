using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using Complete;

public class World : MonoBehaviour
{
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

    #region KBEngine
    void installEvents()
    {
        KBEngine.Event.registerOut("onAccountEnterWorld", this, "onAccountEnterWorld");
    }

    public void onAccountEnterWorld(UInt64 rndUUID, Int32 eid, Account account)
    {
        if (!account.isPlayer())
        {
            return;
        }

        Debug.LogError("onAccountEnterWorld");

        createPlayer();
    }
    #endregion

    public void createPlayer()
    {
        if (KBEngineApp.app.entity_type != "Account")
        {
            return;
        }

        Account account = (Account)KBEngineApp.app.player();
        if (account == null)
        {
            Debug.Log("wait create(palyer)!");
            return;
        }

        TankManager entity = new TankManager();
        account.renderObj = entity.m_Instance;
        entity.SetCurPlayer();

        GameManager.PlayerEnterIn(entity);

        // 有必要设置一下，由于该接口由Update异步调用，有可能set_position等初始化信息已经先触发了
        // 那么如果不设置renderObj的位置和方向将为0
        // set_position(account);
        // set_direction(account);
    }


}
