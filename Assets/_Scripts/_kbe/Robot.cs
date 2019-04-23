namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Robot : RobotBase
    {
        private string _name = "";
        public string name
        {
            get
            {
                if (_name == "")
                {
                    _name = nameS;//UnicodeToString(nameS);
                }
                return _name;
            }
        }

        public override void __init__()
        {

        }

        public override void onDestroy()
        {

        }

        /// <summary>
		/// This callback method is called when the local entity control by the client has been enabled or disabled. 
		/// See the Entity.controlledBy() method in the CellApp server code for more infomation.
		/// </summary>
		/// <param name="isControlled">
		/// 对于玩家自身来说，它表示是否自己被其它玩家控制了；
		/// 对于其它entity来说，表示我本机是否控制了这个entity
		/// </param>
		public override void onControlled(bool isControlled_)
        {
            Debug.LogFormat("Robot: {0}, isControlled_: {1}", id, isControlled_);
            Event.fireOut("onAvatarControlled", this, isControlled_);
        }

        #region Matching Callback
        public override void onEnterWorld()
        {
            base.onEnterWorld();
            Debug.LogErrorFormat("Robot onEnterWorld, id: {0},  name: {1},  roomNo: {2}", id, name, roomNo);
            Event.fireOut("onEntityEnterWorld", KBEngineApp.app.entity_uuid, roomNo, this);
        }
        #endregion Matching Callback

        #region Transform Send
        public virtual void updateRobotTran(Vector3 pos)
        {
            if (isControlled)
            {
                position.x = pos.x / 100f;
                position.y = pos.z / 100f;
                position.z = pos.y / 100f;
            }
        }
        #endregion Transform Send

        #region util
        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <returns>The to string.</returns>
        /// <param name="unicode">Unicode.</param>
        private string UnicodeToString(string unicode)
        {
            string resultStr = "";
            string[] strList = unicode.Split('u');
            for (int i = 1; i < strList.Length; i++)
            {
                resultStr += (char)int.Parse(strList[i], System.Globalization.NumberStyles.HexNumber);
            }
            return resultStr;
        }
        #endregion util

    }
}
