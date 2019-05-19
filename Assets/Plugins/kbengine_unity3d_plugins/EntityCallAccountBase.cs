/*
	Generated by KBEngine!
	Please do not modify this file!
	
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Account.def
	public class EntityBaseEntityCall_AccountBase : EntityCall
	{

		public EntityBaseEntityCall_AccountBase(Int32 eid, string ename) : base(eid, ename)
		{
			type = ENTITYCALL_TYPE.ENTITYCALL_TYPE_BASE;
		}

		public void regStartMatching(Int32 arg1, Int32 arg2, Int32 arg3)
		{
			Bundle pBundle = newCall("regStartMatching", 0);
			if(pBundle == null)
				return;

			bundle.writeInt32(arg1);
			bundle.writeInt32(arg2);
			bundle.writeInt32(arg3);
			sendCall(null);
		}

	}

	public class EntityCellEntityCall_AccountBase : EntityCall
	{

		public EntityCellEntityCall_AccountBase(Int32 eid, string ename) : base(eid, ename)
		{
			type = ENTITYCALL_TYPE.ENTITYCALL_TYPE_CELL;
		}

		public void regGetProps(string arg1, Int32 arg2)
		{
			Bundle pBundle = newCall("regGetProps", 0);
			if(pBundle == null)
				return;

			bundle.writeUnicode(arg1);
			bundle.writeInt32(arg2);
			sendCall(null);
		}

		public void regProgress(Int32 arg1)
		{
			Bundle pBundle = newCall("regProgress", 0);
			if(pBundle == null)
				return;

			bundle.writeInt32(arg1);
			sendCall(null);
		}

		public void regPropResult(Int32 arg1, Int32 arg2, Int32 arg3, Byte arg4)
		{
			Bundle pBundle = newCall("regPropResult", 0);
			if(pBundle == null)
				return;

			bundle.writeInt32(arg1);
			bundle.writeInt32(arg2);
			bundle.writeInt32(arg3);
			bundle.writeUint8(arg4);
			sendCall(null);
		}

		public void regReachDestination()
		{
			Bundle pBundle = newCall("regReachDestination", 0);
			if(pBundle == null)
				return;

			sendCall(null);
		}

		public void regUseProp(Int32 arg1, Int32 arg2)
		{
			Bundle pBundle = newCall("regUseProp", 0);
			if(pBundle == null)
				return;

			bundle.writeInt32(arg1);
			bundle.writeInt32(arg2);
			sendCall(null);
		}

	}
	}