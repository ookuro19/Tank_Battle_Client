namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Room : RoomBase
    {
        public override void __init__()
        {
            KBEDebug.LogFormat("Room::Init");
        }

        public override void onDestroy()
        {

        }

        public override void onEnterWorld()
        {
            base.onEnterWorld();
            KBEDebug.LogFormat("Room::onEnterWorld, room: {0}", id);
            // Event.fireOut("onEntityEnterWorld", KBEngineApp.app.entity_uuid, roomNo, this);
        }

        #region Callback
        #region Matching
        public override void onLoadingFinish(int suc)
        {
            Event.fireOut("onLoadingFinish", suc);
        }
        #endregion Matching

        #region Prop
        /// <summary>
        /// 恢复相应道具
        /// </summary>
        /// <param name="propList">需要恢复的道具列表</param>
        public override void onResetProps(PROP_LIST propList)
        {
            KBEDebug.LogFormat("Room::onResetProps");
            Event.fireOut("onResetProps", propList);
        }

        /// <summary>
        /// 技能施放结果回调
        /// </summary>
        /// <param name="userID">使用者ID</param>
        /// <param name="targetID">技能目标ID</param>
        /// <param name="type">prop_type</param>
        /// <param name="suc">结算结果：0-命中, 1-未命中</param>
        public override void onPropResult(int userID, int targetID, int type, byte suc)
        {
            KBEDebug.LogFormat("{0} use skill hit {1} : {2}", userID, targetID, suc == 0 ? true : false);
            Event.fireOut("onPropResult", userID, targetID, type, (int)suc);
        }
        #endregion Prop

        #region Destination
        public override void onTimerChanged(int sec)
        {
            // KBEDebug.LogFormat("onTimerChanged:{0}, name:{1}", sec, name);
            Event.fireOut("onTimerChanged", sec);
        }

        public override void onReachDestination(int arg1, int arg2)
        {
            Event.fireOut("onReachDestination", arg1, arg2);
        }
        #endregion Destination

        #endregion Callback

    }
}