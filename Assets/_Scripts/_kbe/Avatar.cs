namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Avatar : AvatarBase
    {
        public override void __init__()
        {
            if (isPlayer())
            {
                #region register
                //匹配
                Event.registerIn("StartMatching", this, "StartMatching");
                Event.registerIn("updateProgress", this, "updateProgress");

                //比赛
                Event.registerIn("updatePlayer", this, "updatePlayer");
                Event.registerIn("getProps", this, "getProps");
                Event.registerIn("reachDestination", this, "reachDestination");
                #endregion

                // 触发登陆成功事件
                Event.fireOut("onLoginSuccessfully", KBEngineApp.app.entity_uuid, id, this);

            }
        }

        public override void onDestroy()
        {
            if (isPlayer())
            {
                KBEngine.Event.deregisterIn(this);
            }
        }

        #region Matching Send
        // 玩家发送匹配请求
        public void StartMatching(int map, int mode)
        {
            Debug.Log("Player Start Matching, id:" + id);
            baseCall("startMatching", map, mode);
        }

        public void updateProgress(int tprogerss)
        {
            if (progress < tprogerss)
            {
                progress = tprogerss;
                // Debug.LogErrorFormat("Player:{0} updateProgress:{1}", name, progress);
                cellCall("regProgress", progress);
            }
        }
        #endregion

        #region Matching Callback
        public override void onEnterWorld()
        {
            base.onEnterWorld();
            Debug.LogErrorFormat("Account onEnterWorld, id: {0},  name: {1},  roomNo: {2}", id, name, roomNo);
            Event.fireOut("onAccountEnterWorld", new object[] { KBEngineApp.app.entity_uuid, roomNo, this });
        }

        public override void onMatchingFinish(int arg1)
        {
            Debug.Log("onMatchingFinish, id is: " + id);
            if (isPlayer())
            {
                Event.fireOut("onMatchingFinish", arg1);
            }
        }

        public override void onLoadingFinish(int arg1)
        {
            if (isPlayer())
            {
                Event.fireOut("onLoadingFinish", arg1);
            }
        }
        #endregion

        #region Playing Send
        public virtual void updatePlayer(Vector3 pos, float yaw)
        {
            position.x = pos.x;
            position.y = pos.z;
            position.z = pos.y;

            direction.z = yaw;
        }

        public void getProps(int type)
        {
            Debug.Log("send get orops info, type: " + type);
            cellCall("getProps", type);
        }

        public void reachDestination()
        {
            Debug.Log("send reachDestination info");
            cellCall("reachDestination");
        }
        #endregion

        #region Playing Callback
        /// <summary>
        /// 玩家获得道具，不一定是当前player
        /// </summary>
        /// <param name="type">道具类型</param>
        public override void onGetProps(int type)
        {
            Debug.LogFormat("onGetProps, name:{0}, type:{1}", name, type);
            ServerEvents.Instance.onGetProps(id, type);
        }

        public override void onTimerChanged(int sec)
        {
            // Debug.LogFormat("onTimerChanged:{0}, name:{1}", sec, name);
            ServerEvents.Instance.onTimerChanged(sec);
        }

        public void onExitRoom(int suc)
        {
            ServerEvents.Instance.onExitRoom(suc);
        }

        public override void onReachDestination(int arg1, int arg2)
        {
            ServerEvents.Instance.onReachDestination(eid: arg1, time: arg2);
        }
        #endregion
    }
}
