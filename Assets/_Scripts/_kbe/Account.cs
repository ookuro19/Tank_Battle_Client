﻿namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Account : AccountBase
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
                //匹配
                Event.registerIn("StartMatching", this, "StartMatching");
                Event.registerIn("updateProgress", this, "updateProgress");

                //比赛
                Event.registerIn("updatePlayer", this, "updatePlayer");
                Event.registerIn("getProps", this, "getProps");
                Event.registerIn("useSkill", this, "useSkill");
                Event.registerIn("skillResult", this, "skillResult");
                Event.registerIn("reachDestination", this, "reachDestination");
                #endregion register

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

        #region Login Callback
        /// <summary>
        /// 玩家登陆时在服务器中的状态
        /// </summary>
        /// <param name="arg1">0-未登录或未匹配; 1-匹配但未比赛; 2-比赛中</param>
        public override void onLoginState(int arg1)
        {
            Debug.LogErrorFormat("onLoginState : {0}", arg1);
            Event.fireOut("onLoginState", arg1);
        }
        #endregion Login Callback

        #region Matching Send
        // 玩家发送匹配请求
        public void StartMatching(int map, int mode, int matchCode)
        {
            progress = 0;
            Debug.Log("Player Start Matching, id:" + id);
            baseCall("regStartMatching", map, mode, matchCode);
        }

        public void updateProgress(int tprogerss)
        {
            if (progress < tprogerss)
            {
                Debug.LogErrorFormat("Player:{0} now progress {1}, update to rogress:{2}", name, progress, tprogerss);
                progress = tprogerss;
                cellCall("regProgress", progress);
            }
        }

        public override void onProgressChanged(int oldValue)
        {
            Debug.LogErrorFormat("Player:{0} onProgressChanged:{1}", name, progress);
        }
        #endregion Matching Send

        #region Matching Callback
        public override void onEnterWorld()
        {
            base.onEnterWorld();
            Debug.LogErrorFormat("Account onEnterWorld, id: {0},  name: {1},  roomNo: {2}", id, name, roomNo);
            Event.fireOut("onEntityEnterWorld", new object[] { KBEngineApp.app.entity_uuid, roomNo, this });
        }

        /// <summary>
        /// 设置玩家的地图和模式编号
        /// </summary>
        /// <param name="arg1">100 * mode + map</param>
        public override void onMapModeChanged(int arg1)
        {
            if (isPlayer())
            {
                Debug.LogFormat("设置玩家的地图为: {0}, 模式为: {1}", arg1 % 100, arg1 / 100);
                Event.fireOut("onMapModeChanged", arg1);
            }
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
        #endregion Matching Callback

        #region Transform Send
        public virtual void updatePlayer(Vector3 pos, float yaw)
        {
            position.x = pos.x / 100f;
            position.y = pos.z / 100f;
            position.z = pos.y / 100f;

            direction.z = yaw;
        }
        #endregion Transform Send

        #region Props Send
        public void getProps(int type)
        {
            Debug.Log("send get orops info, type: " + type);
            cellCall("regGetProps", type);
        }
        #endregion Props Send

        #region Props Callback
        /// <summary>
        /// 玩家获得道具，不一定是当前player
        /// </summary>
        /// <param name="type">道具类型</param>
        public override void onGetProps(int type)
        {
            Debug.LogFormat("onGetProps, name:{0}, type:{1}", name, type);
            Event.fireOut("onGetProps", id, type);
        }
        #endregion Props Callback

        #region Skill Send
        /// <summary>
        /// 当前玩家实用技能
        /// </summary>
        /// <param name="targetID">施放目标ID</param>
        /// <param name="skill">技能编号</param>
        public void useSkill(int targetID, int skill)
        {
            cellCall("regUseSkill", targetID, skill);
        }

        /// <summary>
        /// 技能结算结果
        /// </summary>
        /// <param name="userID">使用者ID</param>
        /// <param name="targetID">施放目标ID</param>
        /// <param name="suc">结算结果编号</param>
        public void skillResult(int userID, int targetID, int suc)
        {
            //只有当前玩家与技能施放者相同时才上报技能计算结果
            if (userID == id)
            {
                cellCall("regSkillResult", targetID, suc);
            }
        }
        #endregion Skill Send

        #region Skill Callback
        /// <summary>
        /// 有玩家施放技能
        /// </summary>
        /// <param name="userID">使用者ID</param>
        /// <param name="targetID">技能目标ID</param>
        /// <param name="suc">结算结果：0命中，1未命中</param>
        public override void onUseSkill(int userID, int targetID, int skill)
        {
            Debug.LogFormat("{0} use skill {1} to {2}", userID, skill, targetID);
            Event.fireOut("onUseSkill", userID, targetID, skill);
        }

        /// <summary>
        /// 技能施放结果回调
        /// </summary>
        /// <param name="userID">使用者ID</param>
        /// <param name="targetID">技能目标ID</param>
        /// <param name="suc">结算结果：0命中，1未命中</param>
        public override void onSkillResult(int userID, int targetID, int suc)
        {

            Debug.LogFormat("{0} use skill hit {1} : {2}", userID, targetID, suc == 0 ? true : false);
            Event.fireOut("onSkillResult", userID, targetID, suc);
        }
        #endregion Skill Callback

        #region Destination Send
        public void reachDestination()
        {
            Debug.Log("send reachDestination info");
            cellCall("regReachDestination");
        }
        #endregion Destination Send

        #region Destination Callback
        public override void onTimerChanged(int sec)
        {
            // Debug.LogFormat("onTimerChanged:{0}, name:{1}", sec, name);
            Event.fireOut("onTimerChanged", sec);
        }

        public override void onExitRoom(int suc)
        {
            Event.fireOut("onExitRoom", suc);
        }

        public override void onReachDestination(int arg1, int arg2)
        {
            Event.fireOut("onReachDestination", arg1, arg2);
        }
        #endregion Destination Callback

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
