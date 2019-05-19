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
        ServerCore.PlayerLogin(name, pwd);
    }
    #endregion Login Send

    #region Login Callback
    /// <summary>
    /// 登录成功的回调
    /// </summary>
    public void onLoginSuccessfully(int id, KBEngine.Avatar accountEntity)
    {
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// 玩家登陆时在服务器中的状态
    /// </summary>
    /// <param name="loginState">0-未登录或未匹配; 1-匹配但未比赛; 2-比赛中</param>
    public void onLoginState(int loginState)
    {
        switch (loginState)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {

                    break;
                }
            case 2:
                {
                    SceneManager.LoadSceneAsync("World");
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    #endregion Login Callback

    /// <summary>
    /// 有机器人切换控制权
    /// </summary>
    /// <param name="avatar"></param>
    /// <param name="isControlled_">表示我本机是否控制了这个entity</param>
    public void onAvatarControlled(KBEngine.Avatar avatar, bool isControlled_)
    {
        ClientCore.Instance.onAvatarControlled(avatar, isControlled_);
    }

    #region Matching Send
    /// <summary>
    /// 开始匹配
    /// </summary>
    /// <param name="map">地图编号</param>
    /// <param name="mode">模式编号</param>
    public static void StartMatching(int map, int mode, int matchCode)
    {
        KBEngine.Event.fireIn("StartMatching", map, mode, matchCode);
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
    /// <summary>
    /// 设置玩家的地图和模式编号
    /// </summary>
    /// <param name="num">100 * mode + map</param>
    public void onSetGameMapMode(int num)
    {

    }

    public void onAvatarEnter(int eid, KBEngine.Avatar account)
    {
        ClientCore.Instance.AccountEnterWorld(eid, account);
    }


    /// <summary>
    /// 匹配完成
    /// </summary>
    public void onMatchingFinish()
    {
        UI_Room.Instance.StartLoading();
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

    #region Transform Send
    /// <summary>
    /// 机器人同步坐标
    /// </summary>
    /// <param name="avatar">机器人实体</param>
    /// <param name="pos">位置</param>
    public void UpdateRobotTran(KBEngine.Avatar avatar, Vector3 pos)
    {
        KBEngine.Event.fireIn("updateRobotTran", avatar, pos);
    }

    /// <summary>
    /// 玩家同步坐标
    /// </summary>
    /// <param name="pos">位置</param>
    public void UpdatePlayerTran(Vector3 pos, float y_angle)
    {
        KBEngine.Event.fireIn("updatePlayer", pos, y_angle);
    }

    #endregion Transform Send

    #region Get Props Send
    /// <summary>
    /// 当前玩家获得道具
    /// </summary>
    /// <param name="propKey">道具键值</param>
    /// <param name="type">道具类型</param>
    public void GetProps(string propKey, int type)
    {
        ServerCore.GetProps(propKey, type);
    }
    #endregion Props Send

    #region Props Callback
    /// <summary>
    /// 其他玩家获得道具
    /// </summary>
    /// <param name="eid">玩家实体ID</param>
    /// <param name="propKey">道具键值</param>
    /// <param name="type">道具种类</param>
    public void onGetProps(int eid, string propKey, int type)
    {
        ClientCore.Instance.onGetProps(eid, propKey, type);
    }
    #endregion Props Callback

    #region Use Prop Send
    /// <summary>
    /// 当前玩家使用道具
    /// </summary>
    /// <param name="targetID">施放目标ID</param>
    /// <param name="type">道具类型</param>
    public void useSkill(int targetID, int type)
    {
        ServerCore.UseProp(targetID, type);
    }

    /// <summary>
    /// 道具结算结果
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">施放目标ID</param>
    /// <param name="type">道具类型</param>
    /// <param name="suc">结算结果编号</param>
    public void PropResult(int userID, int targetID, int type, int suc)
    {
        //最好当前玩家与技能施放者相同时才上报技能计算结果
        ServerCore.PropResult(userID, targetID, type, suc);
    }
    #endregion Skill Send

    #region Skill Callback
    /// <summary>
    /// 有玩家使用道具
    /// </summary>
    /// <param name="userID">使用者ID</param>
    /// <param name="targetID">技能目标ID</param>
    /// <param name="type">技能编号</param>
    /// <param name="pos">使用技能时坐标</param>
    public void onUseProp(int userID, int targetID, int type, Vector3 pos)
    {
        ClientCore.Instance.onUseSkill(userID, targetID, type);
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
        ClientCore.Instance.onSkillResult(userID, targetID, suc);
    }
    #endregion Skill Callback

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
        ClientCore.Instance.ExitRoom();
        SceneManager.LoadScene("Main");
    }
    #endregion Destination Callback

}
