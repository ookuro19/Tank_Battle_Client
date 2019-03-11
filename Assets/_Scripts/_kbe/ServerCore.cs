using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
using UnityEngine.SceneManagement;

public class ServerCore : MonoBehaviour
{
    #region Unity Method
    void Start()
    {
        installEvents();
    }

    void OnDestroy()
    {
        KBEngine.Event.fireIn("logout");
    }
    #endregion


    #region KBEngine
    void installEvents()
    {
        // common
        KBEngine.Event.registerOut("onConnectionState", this, "onConnectionState");

        // login
        KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");

        // matching
        KBEngine.Event.registerOut("onAccountEnterWorld", this, "onAccountEnterWorld");
        KBEngine.Event.registerOut("onMatchingFinish", this, "onMatchingFinish");

        // world
        KBEngine.Event.registerOut("set_position", this, "set_position");
        KBEngine.Event.registerOut("updatePosition", this, "updatePosition");
        KBEngine.Event.registerOut("set_direction", this, "set_direction");
    }

    #region login
    public void onConnectionState(bool success)
    {
        if (!success)
            Debug.LogError("connect(" + KBEngineApp.app.getInitArgs().ip + ":" + KBEngineApp.app.getInitArgs().port + ") is error! (连接错误)");
        else
            Debug.Log("connect successfully, please wait...(连接成功，请等候...)");
    }

    public void onLoginFailed(UInt16 failedcode)
    {
        if (failedcode == 20)
        {
            Debug.LogError("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode) + ", " + System.Text.Encoding.ASCII.GetString(KBEngineApp.app.serverdatas()));
        }
        else
        {
            Debug.LogError("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode));
        }
    }

    public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, KBEngine.Avatar accountEntity)
    {
        Debug.Log("login is successfully!(登陆成功!)");
        ServerEvents.Instance.onLoginSuccessfully();
    }
    #endregion

    #region matching
    public void onAccountEnterWorld(UInt64 rndUUID, Int32 eid, KBEngine.Avatar account)
    {
        ServerEvents.Instance.onAvatarEnter(eid, account);
    }

    public void onMatchingFinish(int suc)
    {
        ServerEvents.Instance.MatchingFinish();
    }
    #endregion

    public void updatePosition(KBEngine.Entity entity)
    {
        Debug.LogFormat("updatePosition:: entity: {0}, pos: {1}", entity.id, entity.position);
        if (entity.renderObj == null)
        {
            Debug.LogError("entity.renderObj == null");
            return;
        }

        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        Vector3 currpos = new Vector3(entity.position.x, entity.position.z, entity.position.y);
        go.transform.position = currpos;
    }

    public void set_position(KBEngine.Entity entity)
    {
        Debug.LogFormat("set_position::entity: {0}, pos: {1}", entity.id, entity.position);
        if (entity.renderObj == null)
            return;

        GameObject go = ((UnityEngine.GameObject)entity.renderObj);
        Vector3 currpos = new Vector3(entity.position.x, entity.position.z, entity.position.y);
        go.transform.position = currpos;
    }

    public void set_direction(KBEngine.Entity entity)
    {
        Debug.LogFormat("set_direction::entity: {0}, rot: {1}", entity.id, entity.direction);
        if (entity.renderObj == null)
            return;

        ((UnityEngine.GameObject)entity.renderObj).transform.eulerAngles = 180f / (float)System.Math.PI *
            new Vector3(entity.direction.y, entity.direction.z, entity.direction.x);
    }
    #endregion
}
