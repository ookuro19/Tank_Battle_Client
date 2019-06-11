namespace KBEngine
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
                Event.registerIn("regGetProps", this, "regGetProps");
                Event.registerIn("regUseProp", this, "regUseProp");
                Event.registerIn("regPropResult", this, "regPropResult");
                Event.registerIn("reachDestination", this, "reachDestination");
                Event.registerIn("regGetGold", this, "regGetGold");
                Event.registerIn("regBuyEquip", this, "regBuyEquip");
                Event.registerIn("regChangeEquip", this, "regChangeEquip");
                #endregion register

                // 触发登陆成功事件
                Event.fireOut("onLoginSuccessfully", KBEngineApp.app.entity_uuid, id, this);
            }

            KBEDebug.LogFormat("gold: {0}", gold);
            KBEDebug.LogFormat("current equip, head: {0}, clothes: {1}, hand: {2}, shoe: {3}, bag: {4}",
                                currentItemDict.head, currentItemDict.clothes, currentItemDict.hand, currentItemDict.shoe, currentItemDict.bag);
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
            KBEDebug.LogFormat("onLoginState : {0}", arg1);
            Event.fireOut("onLoginState", arg1);
        }
        #endregion Login Callback

        #region Matching Send
        // 玩家发送匹配请求
        public void StartMatching(int map, int mode, int matchCode)
        {
            progress = 0;
            KBEDebug.Log("Player Start Matching, id:" + id);
            baseEntityCall.regStartMatching(map, mode, matchCode);
        }

        public void updateProgress(int tprogerss)
        {
            if (progress < tprogerss)
            {
                KBEDebug.LogFormat("Player:{0} now progress {1}, update to rogress:{2}", name, progress, tprogerss);
                progress = tprogerss;
                cellEntityCall.regProgress(progress);
            }
        }

        public override void onProgressChanged(int oldValue)
        {
            KBEDebug.LogFormat("Player:{0} onProgressChanged:{1}", name, progress);
        }
        #endregion Matching Send

        #region Matching Callback
        public override void onEnterWorld()
        {
            base.onEnterWorld();
            KBEDebug.LogFormat("Account onEnterWorld, id: {0},  name: {1},  roomNo: {2}", id, name, roomNo);
            Event.fireOut("onEntityEnterWorld", new object[] { KBEngineApp.app.entity_uuid, roomNo, this });
        }

        /// <summary>
        /// 设置玩家的地图和模式编号
        /// </summary>
        /// <param name="mapNum">地图</param>
        /// <param name="modeNum">模式</param>
        public override void onMapModeChanged(int mapNum, int modeNum)
        {
            if (isPlayer())
            {
                KBEDebug.LogFormat("设置玩家的地图为: {0}, 模式为: {1}", mapNum, modeNum);
                Event.fireOut("onMapModeChanged", mapNum, modeNum);
            }
        }

        public override void onMatchingFinish(int arg1)
        {
            KBEDebug.Log("onMatchingFinish, id is: " + id);
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
        public void regGetProps(string propKey, int type)
        {
            KBEDebug.Log("send get orops info, type: " + type);
            cellEntityCall.regGetProps(propKey, type);
        }
        #endregion Props Send

        #region Props Callback
        /// <summary>
        /// 玩家获得道具, 不一定是当前player
        /// </summary>
        /// <param name="arg1">id</param>
        /// <param name="arg2">prop_key</param>
        /// <param name="arg3">prop_type</param>
        public override void onGetPropsClient(int arg1, string arg2, int arg3)
        {
            KBEDebug.LogFormat("onGetPropsClient, self id: {3}, owner id:{0}, key:{1}, type:{2}", arg1, arg2, arg3, id);
            Event.fireOut("onGetProps", arg1, arg2, arg3);
        }

        /// <summary>
        /// 恢复相应道具
        /// </summary>
        /// <param name="arg1">需要恢复的道具列表</param>
        public override void onResetPropClient(PROP_LIST arg1)
        {
            KBEDebug.LogFormat("onResetPropClient");
            Event.fireOut("onResetProp", arg1);
        }
        #endregion Props Callback

        #region Skill Send
        /// <summary>
        /// 当前玩家使用道具
        /// </summary>
        /// <param name="targetID">施放目标ID</param>
        /// <param name="type">道具类型</param>
        public void regUseProp(int targetID, int type)
        {
            cellEntityCall.regUseProp(targetID, type);
        }

        /// <summary>
        /// 技能结算结果
        /// </summary>
        /// <param name="userID">使用者ID</param>
        /// <param name="targetID">施放目标ID</param>
        /// <param name="type">道具类型</param>
        /// <param name="suc">结算结果编号</param>
        public void regPropResult(int userID, int targetID, int type, int suc)
        {
            //只有当前玩家与技能施放者相同时才上报技能计算结果
            if (userID == id)
            {
                cellEntityCall.regPropResult(userID, targetID, type, (byte)suc);
            }
        }
        #endregion Skill Send

        #region Skill Callback
        /// <summary>
        /// 有玩家施放技能
        /// </summary>
        /// <param name="arg1">使用者ID</param>
        /// <param name="arg2">技能目标ID</param>
        /// <param name="arg3">prop_type</param>
        /// <param name="arg4">使用技能时坐标</param>
        public override void onUseProp(int arg1, int arg2, int arg3, Vector3 arg4)
        {
            KBEDebug.LogFormat("{0} use skill {1} to {2}, pos is {3}", arg1, arg2, arg3, arg4);
            Event.fireOut("onUseProp", arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// 技能施放结果回调
        /// </summary>
        /// <param name="userID">使用者ID</param>
        /// <param name="targetID">技能目标ID</param>
        /// <param name="type">prop_type</param>
        /// <param name="suc">结算结果：0-命中, 1-未命中</param>
        public override void onPropResultClient(int userID, int targetID, int type, byte suc)
        {
            KBEDebug.LogFormat("{0} use skill hit {1} : {2}", userID, targetID, suc == 0 ? true : false);
            Event.fireOut("onPropResult", userID, targetID, type, (int)suc);
        }
        #endregion Skill Callback

        #region Shop Send
        /// <summary>
        /// 得到金币
        /// </summary>
        /// <param name="tGold"></param>
        public void regGetGold(int tGold)
        {
            KBEDebug.LogFormat("regGetGold: {0}", tGold);
            baseEntityCall.regGetGold(tGold);
        }

        /// <summary>
        /// 购买装备
        /// </summary>
        /// <param name="itemID">装备id</param>
        public void regBuyEquip(int itemID)
        {
            KBEDebug.LogFormat("regBuyEquip: {0}", itemID);
            baseEntityCall.regBuyEquip(itemID);
        }

        /// <summary>
        /// 切换装备
        /// </summary>
        /// <param name="itemID">装备id</param>
        public void regChangeEquip(int itemID)
        {
            KBEDebug.LogFormat("regChangeEquip: {0}", itemID);
            baseEntityCall.regChangeEquip(itemID);
        }
        #endregion Shop Send

        #region Shop Callback
        /// <summary>
        /// 得到金币回调
        /// </summary>
        /// <param name="tGold"></param>
        public override void onGetGold(int tGold)
        {
            KBEDebug.LogFormat("onGetGold {0}", tGold);
            Event.fireOut("onGetGold", tGold);
        }

        /// <summary>
        /// 购买装备回调
        /// </summary>
        /// <param name="itemID">装备id</param>
        /// <param name="suc">购买结果: 0-成功, 1-已拥有, 2-金币不足, 3-道具不存在</param>
        public override void onBuyEquip(int itemID, byte suc)
        {
            KBEDebug.LogFormat("onBuyEquip {0}, result is {1}", itemID, suc);
            KBEDebug.LogFormat("current equip, head: {0}, clothes: {1}, hand: {2}, shoe: {3}, bag: {4}",
                                currentItemDict.head, currentItemDict.clothes, currentItemDict.hand, currentItemDict.shoe, currentItemDict.bag);
            Event.fireOut("onBuyEquip", itemID, (int)suc);
        }

        /// <summary>
        /// 切换装备回调
        /// </summary>
        /// <param name="itemID">装备id</param>
        /// <param name="suc">结果: 0-成功, 1-未拥有</param>
        public override void onChangeEquip(int itemID, byte suc)
        {
            KBEDebug.LogFormat("onChangeEquip {0}, result is {1}", itemID, suc);
            KBEDebug.LogFormat("current equip, head: {0}, clothes: {1}, hand: {2}, shoe: {3}, bag: {4}",
                                currentItemDict.head, currentItemDict.clothes, currentItemDict.hand, currentItemDict.shoe, currentItemDict.bag);
            Event.fireOut("onChangeEquip", itemID, (int)suc);
        }
        #endregion Shop Callback

        #region Destination Send
        public void reachDestination()
        {
            KBEDebug.Log("send reachDestination info");
            cellEntityCall.regReachDestination();
        }
        #endregion Destination Send

        #region Destination Callback
        public override void onTimerChanged(int sec)
        {
            // KBEDebug.LogFormat("onTimerChanged:{0}, name:{1}", sec, name);
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
