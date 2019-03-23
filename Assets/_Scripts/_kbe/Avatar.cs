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
        #endregion Matching Send

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
            cellCall("getProps", type);
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
            cellCall("useSkill", targetID, skill);
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
                cellCall("skillResult", targetID, suc);
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
            cellCall("reachDestination");
        }
        #endregion Destination Send

        #region Destination Callback
        public override void onTimerChanged(int sec)
        {
            // Debug.LogFormat("onTimerChanged:{0}, name:{1}", sec, name);
            Event.fireOut("onTimerChanged", sec);
        }

        public void onExitRoom(int suc)
        {
            Event.fireOut("onExitRoom", suc);
        }

        public override void onReachDestination(int arg1, int arg2)
        {
            Event.fireOut("onReachDestination", arg1, arg2);
        }
        #endregion Destination Callback

    }
}
