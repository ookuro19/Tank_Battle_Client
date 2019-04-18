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
                    _name = UnicodeToString(nameS);
                }
                return _name;
            }
        }

        public override void __init__()
        {
            if (isPlayer())
            {
                #region register
                //比赛
                Event.registerIn("updateRobot", this, "updateRobot");
                Event.registerIn("skillResult", this, "skillResult");
                Event.registerIn("reachDestination", this, "reachDestination");
                #endregion register
            }
        }

        public override void onDestroy()
        {
            if (isPlayer())
            {
                KBEngine.Event.deregisterIn(this);
            }
        }

        #region Matching Callback
        public override void onEnterWorld()
        {
            base.onEnterWorld();
            Debug.LogErrorFormat("Robot onEnterWorld, id: {0},  name: {1},  roomNo: {2}", id, name, roomNo);
            Event.fireOut("onEntityEnterWorld", new object[] { KBEngineApp.app.entity_uuid, roomNo, this });
        }
        #endregion Matching Callback

        #region Transform Send
        public virtual void updateRobot(Vector3 pos, float yaw)
        {
            position.x = pos.x / 100f;
            position.y = pos.z / 100f;
            position.z = pos.y / 100f;

            direction.z = yaw;
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
