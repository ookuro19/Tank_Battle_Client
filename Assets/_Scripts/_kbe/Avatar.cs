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
            Debug.Log(string.Format("Account onEnterWorld, id: {0},  name: {1},  roomNo: {2}", id, name, roomNo));
            Event.fireOut("onAccountEnterWorld", new object[] { KBEngineApp.app.entity_uuid, roomNo, this });
        }

        public virtual void updatePlayer(float x, float y, float z, float yaw)
        {
            position.x = x;
            position.y = y;
            position.z = z;

            direction.z = yaw;
        }

        public void updateProgress(int tprogerss)
        {
            progress = tprogerss;
            if (!isLoadingFinish && progress == 100)
            {
                isLoadingFinish = true;
                baseCall("regLoadingProgress", new object[] { progress });
            }
        }

        public override void onProgressChanged(int oldValue)
        {
            Debug.Log(string.Format("id: {0} , progress: {1}", id, oldValue));
        }

        public void StartMatching(int map, int mode)
        {
            isLoadingFinish = false;
            Debug.Log("Player Start Matching, id:" + id);
            baseCall("startMatching", new object[] { map, mode });
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
