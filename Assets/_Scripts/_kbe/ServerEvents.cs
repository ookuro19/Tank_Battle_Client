using System.Collections;
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
    #endregion

    #region Login Callback
    /// <summary>
    /// 登录成功的回调
    /// </summary>
    public void onLoginSuccessfully()
    {
        SceneManager.LoadScene("Main");
    }
    #endregion

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
    #endregion

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
    #endregion

    #region Playing Send
    /// <summary>
    /// 当前玩家到达终点
    /// </summary>
    public void ReachDestination()
    {
        KBEngine.Event.fireIn("reachDestination");
    }

    /// <summary>
    /// 当前玩家获得道具
    /// </summary>
    /// <param name="type">道具类型</param>
    public void GetProps(int type)
    {
        KBEngine.Event.fireIn("getProps", type);
    }
    #endregion

    #region Playing Callback
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

    }

    /// <summary>
    /// 其他玩家获得道具
    /// </summary>
    /// <param name="eid"></param>
    /// <param name="type"></param>
    public void onGetProps(int eid, int type)
    {

    }

    /// <summary>
    /// 当前玩家是否成功退出房间
    /// </summary>
    /// <param name="suc"></param>
    public void onExitRoom(int suc)
    {

    }
    #endregion

}
