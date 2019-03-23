/*
 * @Description: 主要用于KBEngine与unity交互的回调，避免线程错误
 * @Author: ookuro19 
 * @Date: 2019-03-23 10:51:27 
 * @Last Modified by: ookuro19
 * @Last Modified time: 2019-03-23 10:55:54
 */
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
        KBEngineApp.app.logout();
        // KBEngine.Event.fireIn("logout");
    }
    #endregion Unity Method

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
        KBEngine.Event.registerOut("onLoadingFinish", this, "onLoadingFinish");

        // gaming 
        KBEngine.Event.registerOut("onGetProps", this, "onGetProps");
        KBEngine.Event.registerOut("onUseSkill", this, "onUseSkill");
        KBEngine.Event.registerOut("onSkillResult", this, "onSkillResult");
        KBEngine.Event.registerOut("onTimerChanged", this, "onTimerChanged");
        KBEngine.Event.registerOut("onExitRoom", this, "onExitRoom");
        KBEngine.Event.registerOut("onReachDestination", this, "onReachDestination");
    }

    #region Login
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
    #endregion Login

    #region Matching
    public void onAccountEnterWorld(UInt64 rndUUID, Int32 eid, KBEngine.Avatar account)
    {
        ServerEvents.Instance.onAvatarEnter(eid, account);
    }

    public void onMatchingFinish(int suc)
    {
        ServerEvents.Instance.onMatchingFinish();
    }

    public void onLoadingFinish(int suc)
    {
        ServerEvents.Instance.onLoadingFinish(suc);
    }
    #endregion Matching

    #region Props
    /// <summary>
    /// 玩家获得道具，不一定是当前player
    /// </summary>
    /// <param name="type">道具类型</param>
    public void onGetProps(int id, int type)
    {
        ServerEvents.Instance.onGetProps(id, type);
    }
    #endregion Props

    #region Skill
    /// <summary>
    /// 有玩家施放技能
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="skill">技能编号</param>
    public void onUseSkill(int userID, int targetID, int skill)
    {
        ServerEvents.Instance.onUseSkill(userID, targetID, skill);
    }

    /// <summary>
    /// 技能施放结果回调
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="suc">结算结果：0命中，1未命中</param>
    public void onSkillResult(int userID, int targetID, int suc)
    {
        ServerEvents.Instance.onSkillResult(userID, targetID, suc);
    }
    #endregion Skill

    #region Destination
    public void onTimerChanged(int sec)
    {
        ServerEvents.Instance.onTimerChanged(sec);
    }

    public void onExitRoom(int suc)
    {
        ServerEvents.Instance.onExitRoom(suc);
    }

    public void onReachDestination(int eid, int time)
    {
        ServerEvents.Instance.onReachDestination(eid, time);
    }
    #endregion Destination

    #endregion KBEngine
}
