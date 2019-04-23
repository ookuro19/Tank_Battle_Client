namespace KBEngine
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Avatar
    {
        public bool isRobot { get; private set; }
        private Account m_account = null;
        private Robot m_robot = null;

        public Avatar(Entity entity)
        {
            if (entity.className == "Account")
            {
                isRobot = false;
                m_account = (Account)entity;
            }
            else
            {
                isRobot = true;
                m_robot = (Robot)entity;
            }
        }

        #region Properties
        /// <summary>
        /// 名字
        /// </summary>
        public string name
        {
            get
            {
                return isRobot ? m_robot.name : m_account.name;
            }
        }

        /// <summary>
        /// 场景内gameobject
        /// </summary>
        public System.Object renderObj
        {
            get
            {
                return isRobot ? m_robot.renderObj : m_account.renderObj;
            }
            set
            {
                if (isRobot)
                {
                    m_robot.renderObj = value;
                }
                else
                {
                    m_account.renderObj = value;
                }
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        public Int32 id
        {
            get
            {
                return isRobot ? m_robot.id : m_account.id;
            }
        }

        /// <summary>
        /// 是否是玩家
        /// </summary>
        public bool isPlayer
        {
            get
            {
                return isRobot ? m_robot.isPlayer() : m_account.isPlayer();
            }
        }

        /// <summary>
		/// 对于玩家自身来说，它表示是否自己被其它玩家控制了；
		/// 对于其它entity来说，表示我本机是否控制了这个entity
		/// </summary>
        public bool isControllerdRobot
        {
            get
            {
                return isRobot ? m_robot.isControlled : false;
            }
        }
        /// <summary>
        /// 房间进入顺位
        /// </summary>
        public Int32 roomNo
        {
            get
            {
                return isRobot ? m_robot.roomNo : m_account.roomNo;
            }
        }

        /// <summary>
        /// 加载进度
        /// </summary>
        public Int32 progress
        {
            get
            {
                return isRobot ? m_robot.progress : m_account.progress;
            }
        }

        #endregion Properties

        #region foo
        public void updateRobotTran(Vector3 pos)
        {
            if (isRobot && m_robot != null)
            {
                m_robot.updateRobotTran(pos);
            }
        }
        #endregion
    }
}