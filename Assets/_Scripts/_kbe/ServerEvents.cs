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

    #region login
    /// <summary>
    /// 玩家登录
    /// </summary>
    /// <param name="name">玩家名称</param>
    /// <param name="pwd">密码</param>
    public void PlayerLogin(string name, string pwd)
    {
        KBEngine.Event.fireIn("login", name, pwd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_demo"));
    }

    /// <summary>
    /// 登录成功的回调
    /// </summary>
    public void onLoginSuccessfully()
    {
        SceneManager.LoadScene("Main");
    }
    #endregion

    #region Matching
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

    public void onAvatarEnter(int eid, KBEngine.Avatar account)
    {
        ClientCore.Instance.AccountEnterWorld(eid, account);
        UI_Room.Instance.PlayerEnterin();
    }

    /// <summary>
    /// 匹配完成
    /// </summary>
    public void MatchingFinish()
    {
        UI_Room.isStartLoading = true;
    }

    /// <summary>
    /// 更新加载进度
    /// </summary>
    /// <param name="tProcess">加载进度</param>
    public void UpdateLoadingProgress(int tProcess)
    {
        KBEngine.Event.fireIn("updateProgress", tProcess);
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
}
