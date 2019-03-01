namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Account : AccountBase
    {
        public override void __init__()
        {
            if (isPlayer())
            {
                Event.registerIn("updatePlayer", this, "updatePlayer");

                // 触发登陆成功事件
                Event.fireOut("onLoginSuccessfully", new object[] { KBEngineApp.app.entity_uuid, id, this });
            }
        }

        public override void onDestroy()
        {
            Debug.Log("-----------Account onDestroy, id:" + id + " -----------");

            if (isPlayer())
            {
                KBEngine.Event.deregisterIn(this);
            }
        }

        public override void onEnterWorld()
        {
            base.onEnterWorld();
            Debug.Log("Account onEnterWorld, id:" + id);
            Event.fireOut("onAccountEnterWorld", new object[] { KBEngineApp.app.entity_uuid, id, this });
        }

        public virtual void updatePlayer(float x, float y, float z, float yaw)
        {
            position.x = x;
            position.y = y;
            position.z = z;

            direction.z = yaw;
        }

        public void SetInitPos(Vector3 tpos, Vector3 trot)
        {
            if (isPlayer())
            {
                Debug.Log("SetInitPos");
                cellCall("enterGameWorld", new object[] { this, tpos, trot });
            }
        }
    }
}
