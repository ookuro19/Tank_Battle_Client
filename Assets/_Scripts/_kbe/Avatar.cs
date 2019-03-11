namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Avatar : AvatarBase
    {
        bool isLoadingFinish = false;

        public override void __init__()
        {
            if (isPlayer())
            {
                Event.registerIn("updatePlayer", this, "updatePlayer");
                Event.registerIn("updateProgress", this, "updateProgress");
                Event.registerIn("StartMatching", this, "StartMatching");

                // 触发登陆成功事件
                Event.fireOut("onLoginSuccessfully", new object[] { KBEngineApp.app.entity_uuid, id, this });
            }
        }

        public override void onDestroy()
        {
            if (isPlayer())
            {
                KBEngine.Event.deregisterIn(this);
            }
        }

        public override void onEnterWorld()
        {
            base.onEnterWorld();
            Debug.LogFormat("Account onEnterWorld, id: {0},  name: {1},  roomNo: {2}", id, name, roomNo);
            Event.fireOut("onAccountEnterWorld", new object[] { KBEngineApp.app.entity_uuid, roomNo, this });
        }

        public virtual void updatePlayer(Vector3 pos, float yaw)
        {
            position.x = pos.x;
            position.y = pos.z;
            position.z = pos.y;

            direction.z = yaw;
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

        public void StartMatching(int map, int mode)
        {
            isLoadingFinish = false;
            Debug.Log("Player Start Matching, id:" + id);
            baseCall("startMatching", 3, 2);//new object[] { map, mode });
        }

        public override void onLoadingFinish(int arg1)
        {
            if (isPlayer())
            {
                // Event.fireOut("onLoadingFinish", new object[] { arg1 });
                ServerEvents.Instance.onLoadingFinish(arg1);
            }
        }

        public override void onMatchingFinish(int arg1)
        {
            Debug.Log("onMatchingFinish, id is: " + id);
            if (isPlayer())
            {
                Event.fireOut("onMatchingFinish", new object[] { arg1 });
            }
        }
    }
}
