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

    #region Send
    /// <summary>
    /// 玩家登录
    /// </summary>
    /// <param name="name">玩家名称</param>
    /// <param name="pwd">密码</param>
    public static void PlayerLogin(string name, string pwd)
    {
        KBEngine.Event.fireIn("login", StringToUnicode(name), pwd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_demo"));
    }

    /// 当前玩家获得道具
    /// </summary>
    /// <param name="propKey"></param>
    /// <param name="type">道具类型</param>
    public static void GetProps(string propKey, int type)
    {
        KBEngine.Event.fireIn("regGetProps", propKey, type);
    }

    /// <summary>
    /// 当前玩家使用道具
    /// </summary>
    /// <param name="targetID">施放目标ID</param>
    /// <param name="type">道具类型</param>
    public static void UseProp(int targetID, int type)
    {
        KBEngine.Event.fireIn("regUseProp", targetID, type);
    }

    /// <summary>
    /// 道具结算结果
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">施放目标ID</param>
    /// <param name="type">道具类型</param>
    /// <param name="suc">结算结果编号</param>
    public static void PropResult(int userID, int targetID, int type, int suc)
    {
        //最好当前玩家与技能施放者相同时才上报技能计算结果
        KBEngine.Event.fireIn("regPropResult", userID, targetID, type, suc);
    }

    /// <summary>
    /// 得到金币
    /// </summary>
    /// <param name="tGold"></param>
    public static void regGetGold(int tGold)
    {
        KBEngine.Event.fireIn("regGetGold", tGold);
    }

    /// <summary>
    /// 购买装备
    /// </summary>
    /// <param name="itemID">装备id</param>
    public static void regBuyEquip(int itemID)
    {
        KBEngine.Event.fireIn("regBuyEquip", itemID);
    }

    /// <summary>
    /// 切换装备
    /// </summary>
    /// <param name="itemID">装备id</param>
    public static void regChangeEquip(int itemID)
    {
        KBEngine.Event.fireIn("regChangeEquip", itemID);
    }


    #endregion Send

    #region Callback
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
        KBEngine.Event.registerOut("onResetProp", this, "onResetProp");
        KBEngine.Event.registerOut("onUseProp", this, "onUseProp");
        KBEngine.Event.registerOut("onPropResult", this, "onPropResult");
        KBEngine.Event.registerOut("onTimerChanged", this, "onTimerChanged");
        KBEngine.Event.registerOut("onExitRoom", this, "onExitRoom");
        KBEngine.Event.registerOut("onReachDestination", this, "onReachDestination");

        // Shop
        KBEngine.Event.registerOut("onGetGold", this, "onGetGold");
        KBEngine.Event.registerOut("onBuyEquip", this, "onBuyEquip");
        KBEngine.Event.registerOut("onChangeEquip", this, "onChangeEquip");
    }

    #region Login
    public void onConnectionState(bool success)
    {
        if (!success)
            KBEDebug.LogError("connect(" + KBEngineApp.app.getInitArgs().ip + ":" + KBEngineApp.app.getInitArgs().port + ") is error! (连接错误)");
        else
            KBEDebug.Log("connect successfully, please wait...(连接成功，请等候...)");
    }

    public void onLoginFailed(UInt16 failedcode)
    {
        if (failedcode == 20)
        {
            KBEDebug.LogError("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode) + ", " + System.Text.Encoding.ASCII.GetString(KBEngineApp.app.serverdatas()));
        }
        else
        {
            KBEDebug.LogError("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode));
        }
    }

    public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, KBEngine.Account account)
    {
        KBEDebug.Log("login is successfully!(登陆成功!)");
        KBEngine.Avatar m_Avatar = new KBEngine.Avatar(account);
        ServerEvents.Instance.onLoginSuccessfully(eid, m_Avatar);
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
        ServerEvents.Instance.onSetGameMapMode(arg1 / 100, arg1 % 100);
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
    public void onGetProps(int id, string propKey, int type)
    {
        ServerEvents.Instance.onGetProps(id, propKey, type);
    }

    /// <summary>
    /// 恢复道具
    /// </summary>
    /// <param name="propsList">道具列表</param>
    public void onResetProp(List<string> propsList)
    {
        ServerEvents.Instance.onResetProp(propsList);
    }

    /// <summary>
    /// 有玩家施放技能
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="type">技能编号</param>
    /// <param name="pos">使用技能时坐标</param>
    public void onUseProp(int userID, int targetID, int type, Vector3 pos)
    {
        ServerEvents.Instance.onUseProp(userID, targetID, type, pos);
    }

    /// <summary>
    /// 道具结果回调
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="type">prop_type</param>
    /// <param name="suc">结算结果：0命中，1未命中</param>
    public void onPropResult(int userID, int targetID, int type, int suc)
    {
        ServerEvents.Instance.onPropResult(userID, targetID, type, suc);
    }
    #endregion Prop

    #region Destination
    public void onTimerChanged(int sec)
    {
        ServerEvents.Instance.onTimerChanged(sec);
    }

    public void onExitRoom(int suc)
    {
        KBEDebug.Log("onExitRoom");
        ServerEvents.Instance.onExitRoom(suc);
    }

    public void onReachDestination(int eid, int time)
    {
        ServerEvents.Instance.onReachDestination(eid, time);
    }
    #endregion Destination

    #region Shop
    /// <summary>
    /// 得到金币回调
    /// </summary>
    /// <param name="tGold"></param>
    public void onGetGold(int tGold)
    {
        ServerEvents.Instance.onGetGold(tGold);
    }

    /// <summary>
    /// 购买装备回调
    /// </summary>
    /// <param name="itemID">装备id</param>
    /// <param name="suc">购买结果: 0-成功, 1-已拥有, 2-金币不足, 3-道具不存在</param>
    public void onBuyEquip(int itemID, int suc)
    {
        ServerEvents.Instance.onBuyEquip(itemID, suc);
    }

    /// <summary>
    /// 切换装备回调
    /// </summary>
    /// <param name="itemID">装备id</param>
    /// <param name="suc">结果: 0-成功, 1-未拥有</param>
    public void onChangeEquip(int itemID, int suc)
    {
        ServerEvents.Instance.onChangeEquip(itemID, suc);
    }
    #endregion Shop

    #endregion Callback

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
        KBEDebug.Log("player reg name is " + stringBuilder.ToString());
        return stringBuilder.ToString();
    }
    #endregion util
}
