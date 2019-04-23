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
using System.Text;
using UnityEngine;
using KBEngine;
using UnityEngine.SceneManagement;

public enum EPlatform
{
    steam,
    ocgo,
    mi,
    htcwave
}

public class ServerCore : MonoBehaviour
{

    #region Unity Method
    void Start()
    {
        installEvents();
    }

    void OnDestroy()
    {
        // KBEngineApp.app.logout();
        KBEngine.Event.fireIn("logout");
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
        KBEngine.Event.registerOut("onLoginState", this, "onLoginState");

        // Enter&Leave
        KBEngine.Event.registerOut("onEntityEnterWorld", this, "onEntityEnterWorld");
        KBEngine.Event.registerOut("onAvatarControlled", this, "onAvatarControlled");
        
        // matching
        KBEngine.Event.registerOut("onMapModeChanged", this, "onMapModeChanged");
        KBEngine.Event.registerOut("onMatchingFinish", this, "onMatchingFinish");
        KBEngine.Event.registerOut("onLoadingFinish", this, "onLoadingFinish");

        // gaming 
        KBEngine.Event.registerIn("updateRobotTran", this, "updateRobotTran");

        KBEngine.Event.registerOut("onGetProps", this, "onGetProps");
        KBEngine.Event.registerOut("onUseSkill", this, "onUseSkill");
        KBEngine.Event.registerOut("onSkillResult", this, "onSkillResult");
        KBEngine.Event.registerOut("onTimerChanged", this, "onTimerChanged");
        KBEngine.Event.registerOut("onExitRoom", this, "onExitRoom");
        KBEngine.Event.registerOut("onReachDestination", this, "onReachDestination");
    }

    #region Login
    /// <summary>
    /// 玩家登录
    /// </summary>
    /// <param name="name">玩家名称</param>
    /// <param name="pwd">密码</param>
    public static void PlayerLogin(string name, string pwd)
    {
        KBEngine.Event.fireIn("login", StringToUnicode(name), pwd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_demo"));
    }

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

    public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, KBEngine.Account accountEntity)
    {
        Debug.Log("login is successfully!(登陆成功!)");
        ServerEvents.Instance.onLoginSuccessfully();
    }

    /// <summary>
    /// 玩家登陆时在服务器中的状态
    /// </summary>
    /// <param name="loginState">0-未登录或未匹配; 1-匹配但未比赛; 2-比赛中</param>
    public void onLoginState(int loginState)
    {
        ServerEvents.Instance.onLoginState(loginState);
    }
    #endregion Login

    #region Enter&Leave
    public void onEntityEnterWorld(UInt64 rndUUID, Int32 eid, KBEngine.Entity account)
    {
        KBEngine.Avatar m_Avatar = new KBEngine.Avatar(account);
        ServerEvents.Instance.onAvatarEnter(eid, m_Avatar);
    }

    public void onAvatarControlled(KBEngine.Robot robot, bool isControlled_)
    {
        KBEngine.Avatar m_Avatar = new KBEngine.Avatar(robot);
        ServerEvents.Instance.onAvatarControlled(m_Avatar, isControlled_);
    }
    #endregion Enter&Leave

    #region Matching
    /// <summary>
    /// 设置玩家的地图和模式编号
    /// </summary>
    /// <param name="arg1">100 * mode + map</param>
    public void onMapModeChanged(int arg1)
    {
        ServerEvents.Instance.onSetGameMapMode(arg1);
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

    #region Transform
    public void updateRobotTran(KBEngine.Avatar avatar, Vector3 pos)
    {
        avatar.updateRobotTran(pos);
    }
    #endregion Transform

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
        Debug.Log("onExitRoom");
        ServerEvents.Instance.onExitRoom(suc);
    }

    public void onReachDestination(int eid, int time)
    {
        ServerEvents.Instance.onReachDestination(eid, time);
    }
    #endregion Destination

    #endregion KBEngine

    #region util
    /// <summary>
    /// 字符串转Unicode码
    /// </summary>
    /// <returns>The to unicode.</returns>
    /// <param name="value">Value.</param>
    public static string StringToUnicode(string value)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(value);
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i += 2)
        {
            // 取两个字符，每个字符都是右对齐。
            stringBuilder.AppendFormat("u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
        }
        Debug.Log("player reg name is " + stringBuilder.ToString());
        return stringBuilder.ToString();
    }
    #endregion util
}
