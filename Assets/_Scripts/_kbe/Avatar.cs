namespace KBEngine
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Avatar
    {
        public bool isRobot;
        private Account m_account = null;
        private Robot m_robot = null;

        #region Properties
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

        public string name
        {
            get
            {
                return isRobot ? m_robot.name : m_account.name;
            }
        }

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

        public Int32 id
        {
            get
            {
                return isRobot ? m_robot.id : m_account.id;
            }
        }

        public bool isPlayer()
        {
            return isRobot ? m_robot.isPlayer() : m_account.isPlayer();
        }

        public Int32 roomNo
        {
            get
            {
                return isRobot ? m_robot.roomNo : m_account.roomNo;
            }
        }

        public Int32 progress
        {
            get
            {
                return isRobot ? m_robot.progress : m_account.progress;
            }
        }

        #endregion Properties

    }
}