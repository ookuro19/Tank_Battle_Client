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
            Debug.LogFormat("Account onEnterWorld, id: {0},  name: {1},  roomNo: {2}", id, name, roomNo);
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
                // Event.fireOut("onLoadingFinish", new object[] { arg1 });
                ServerEvents.Instance.onLoadingFinish(arg1);
            }
        }
        #endregion

        #region Playing Sendx
        public virtual void updatePlayer(Vector3 pos, float yaw)
        {
            position.x = pos.x;
            position.y = pos.z;
            position.z = pos.y;

            direction.z = yaw;
        }

        public void getProps(int type)
        {
            cellCall("getProps", type);
        }

        public void reachDestination()
        {
            cellCall("reachDestination");
        }
        #endregion

        #region Playing Callback
        public void onGetProps(int type)
        {
            ServerEvents.Instance.onGetProps(id, type);
        }

        public void onTimerChanged(int sec)
        {
            ServerEvents.Instance.onTimerChanged(sec);
        }

        public void onExitRoom(int suc)
        {
            ServerEvents.Instance.onExitRoom(suc);
        }
        #endregion
    }
}
