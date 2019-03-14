public class NewEvents
{
    #region Send
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
        KBEngine.Event.fireIn("getProps");
    }
    #endregion

    #region Callback
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