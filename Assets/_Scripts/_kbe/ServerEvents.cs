﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KBEngine;

public class ServerEvents
{
    private static ServerEvents instance;
    public static ServerEvents Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ServerEvents();
            }
            return instance;
        }
    }

    #region Login Send
    /// <summary>
    /// 玩家登录
    /// </summary>
    /// <param name="name">玩家名称</param>
    /// <param name="pwd">密码</param>
    public void PlayerLogin(string name, string pwd)
    {
        KBEngine.Event.fireIn("login", name, pwd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_demo"));
    }
    #endregion Login Send

    #region Login Callback
    /// <summary>
    /// 登录成功的回调
    /// </summary>
    public void onLoginSuccessfully()
    {
        SceneManager.LoadScene("Main");
    }
    #endregion Login Callback

    #region Matching Send
    /// <summary>
    /// 开始匹配
    /// </summary>
    /// <param name="map">地图编号</param>
    /// <param name="mode">模式编号</param>
    public static void StartMatching(int map, int mode)
    {
        KBEngine.Event.fireIn("StartMatching", map, mode);
        SceneManager.LoadScene("Room");
    }

    /// <summary>
    /// 更新加载进度
    /// </summary>
    /// <param name="tProcess">加载进度</param>
    public void UpdateLoadingProgress(int tProcess)
    {
        KBEngine.Event.fireIn("updateProgress", tProcess);
    }
    #endregion Matching Send

    #region Matching Callback
    public void onAvatarEnter(int eid, KBEngine.Avatar account)
    {
        ClientCore.Instance.AccountEnterWorld(eid, account);
        UI_Room.Instance.PlayerEnterin();
    }

    /// <summary>
    /// 匹配完成
    /// </summary>
    public void onMatchingFinish()
    {
        UI_Room.isStartLoading = true;
    }

    /// <summary>
    /// 所有玩家加载结束
    /// </summary>
    /// <param name="suc"></param>
    public void onLoadingFinish(int suc)
    {
        UI_Room.onLoadingFinish();
    }
    #endregion Matching Callback

    #region Props Send
    /// <summary>
    /// 当前玩家获得道具
    /// </summary>
    /// <param name="type">道具类型</param>
    public void GetProps(int type)
    {
        KBEngine.Event.fireIn("getProps", type);
    }
    #endregion Props Send

    #region Props Callback
    /// <summary>
    /// 其他玩家获得道具
    /// </summary>
    /// <param name="eid"></param>
    /// <param name="type"></param>
    public void onGetProps(int eid, int type)
    {
        ClientCore.Instance.onGetProps(eid, type);
    }
    #endregion Props Callback

    #region Destination Send
    /// <summary>
    /// 当前玩家到达终点
    /// </summary>
    public void ReachDestination()
    {
        KBEngine.Event.fireIn("reachDestination");
    }
    #endregion Destination Send

    #region Destination Callback
    /// <summary>
    /// 其他玩家到达终点
    /// </summary>
    /// <param name="eid">玩家实体ID</param>
    /// <param name="time">用时</param>
    public void onReachDestination(int eid, float time)
    {

    }

    /// <summary>
    /// 有玩家抵达终点后，服务器发来的统一倒计时
    /// </summary>
    /// <param name="sec">倒计时</param>
    public void onTimerChanged(int sec)
    {
        Debug.LogFormat("-------onTimerChanged : {0} ----------", sec);
    }

    /// <summary>
    /// 当前玩家是否成功退出房间
    /// </summary>
    /// <param name="suc"></param>
    public void onExitRoom(int suc)
    {

    }
    #endregion Destination Callback

    #region Skill Send
    /// <summary>
    /// 当前玩家实用技能
    /// </summary>
    /// <param name="targetID">施放目标ID</param>
    /// <param name="skill">技能编号</param>
    public void useSkill(int targetID, int skill)
    {
        KBEngine.Event.fireIn("useSkill", targetID, skill);
    }

    /// <summary>
    /// 技能结算结果
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">施放目标ID</param>
    /// <param name="suc">结算结果编号</param>
    public void skillResult(int userID, int targetID, int suc)
    {
        //最好当前玩家与技能施放者相同时才上报技能计算结果
        KBEngine.Event.fireIn("skillResult", userID, targetID, suc);
    }
    #endregion Skill Send

    #region Skill Callback
    /// <summary>
    /// 有玩家施放技能
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="skill">技能编号</param>
    public void onUseSkill(int userID, int targetID, int skill)
    {
        ClientCore.Instance.onUseSkill(userID, targetID, skill);
    }

    /// <summary>
    /// 技能施放结果回调
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="suc">结算结果：0命中，1未命中</param>
    public void onSkillResult(int userID, int targetID, int suc)
    {
        ClientCore.Instance.onSkillResult(userID, targetID, suc);
    }
    #endregion Skill Callback

}
