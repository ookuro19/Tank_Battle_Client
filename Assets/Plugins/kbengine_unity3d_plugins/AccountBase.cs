/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Account : AccountBase)
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Account.def
	// Please inherit and implement "class Account : AccountBase"
	public abstract class AccountBase : Entity
	{
		public EntityBaseEntityCall_AccountBase baseEntityCall = null;
		public EntityCellEntityCall_AccountBase cellEntityCall = null;

		public string nameS = "";
		public virtual void onNameSChanged(string oldValue) {}
		public Int32 progress = 0;
		public virtual void onProgressChanged(Int32 oldValue) {}
		public Int32 roomNo = 0;
		public virtual void onRoomNoChanged(Int32 oldValue) {}

		public abstract void onExitRoom(Int32 arg1); 
		public abstract void onGetPropsClient(Int32 arg1, string arg2, Int32 arg3); 
		public abstract void onLoadingFinish(Int32 arg1); 
		public abstract void onLoginState(Int32 arg1); 
		public abstract void onMapModeChanged(Int32 arg1); 
		public abstract void onMatchingFinish(Int32 arg1); 
		public abstract void onPropResultClient(Int32 arg1, Int32 arg2, Int32 arg3, Byte arg4); 
		public abstract void onReachDestination(Int32 arg1, Int32 arg2); 
		public abstract void onTimerChanged(Int32 arg1); 
		public abstract void onUseProp(Int32 arg1, Int32 arg2, Int32 arg3, Vector3 arg4); 

		public AccountBase()
		{
		}

		public override void onGetBase()
		{
			baseEntityCall = new EntityBaseEntityCall_AccountBase(id, className);
		}

		public override void onGetCell()
		{
			cellEntityCall = new EntityCellEntityCall_AccountBase(id, className);
		}

		public override void onLoseCell()
		{
			cellEntityCall = null;
		}

		public override EntityCall getBaseEntityCall()
		{
			return baseEntityCall;
		}

		public override EntityCall getCellEntityCall()
		{
			return cellEntityCall;
		}

		public override void attachComponents()
		{
		}

		public override void detachComponents()
		{
		}

		public override void onRemoteMethodCall(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Account"];

			UInt16 methodUtype = 0;
			UInt16 componentPropertyUType = 0;

			if(sm.usePropertyDescrAlias)
			{
				componentPropertyUType = stream.readUint8();
			}
			else
			{
				componentPropertyUType = stream.readUint16();
			}

			if(sm.useMethodDescrAlias)
			{
				methodUtype = stream.readUint8();
			}
			else
			{
				methodUtype = stream.readUint16();
			}

			Method method = null;

			if(componentPropertyUType == 0)
			{
				method = sm.idmethods[methodUtype];
			}
			else
			{
				Property pComponentPropertyDescription = sm.idpropertys[componentPropertyUType];
				switch(pComponentPropertyDescription.properUtype)
				{
					default:
						break;
				}

				return;
			}

			switch(method.methodUtype)
			{
				case 24:
					Int32 onExitRoom_arg1 = stream.readInt32();
					onExitRoom(onExitRoom_arg1);
					break;
				case 19:
					Int32 onGetPropsClient_arg1 = stream.readInt32();
					string onGetPropsClient_arg2 = stream.readUnicode();
					Int32 onGetPropsClient_arg3 = stream.readInt32();
					onGetPropsClient(onGetPropsClient_arg1, onGetPropsClient_arg2, onGetPropsClient_arg3);
					break;
				case 18:
					Int32 onLoadingFinish_arg1 = stream.readInt32();
					onLoadingFinish(onLoadingFinish_arg1);
					break;
				case 15:
					Int32 onLoginState_arg1 = stream.readInt32();
					onLoginState(onLoginState_arg1);
					break;
				case 16:
					Int32 onMapModeChanged_arg1 = stream.readInt32();
					onMapModeChanged(onMapModeChanged_arg1);
					break;
				case 17:
					Int32 onMatchingFinish_arg1 = stream.readInt32();
					onMatchingFinish(onMatchingFinish_arg1);
					break;
				case 21:
					Int32 onPropResultClient_arg1 = stream.readInt32();
					Int32 onPropResultClient_arg2 = stream.readInt32();
					Int32 onPropResultClient_arg3 = stream.readInt32();
					Byte onPropResultClient_arg4 = stream.readUint8();
					onPropResultClient(onPropResultClient_arg1, onPropResultClient_arg2, onPropResultClient_arg3, onPropResultClient_arg4);
					break;
				case 22:
					Int32 onReachDestination_arg1 = stream.readInt32();
					Int32 onReachDestination_arg2 = stream.readInt32();
					onReachDestination(onReachDestination_arg1, onReachDestination_arg2);
					break;
				case 23:
					Int32 onTimerChanged_arg1 = stream.readInt32();
					onTimerChanged(onTimerChanged_arg1);
					break;
				case 20:
					Int32 onUseProp_arg1 = stream.readInt32();
					Int32 onUseProp_arg2 = stream.readInt32();
					Int32 onUseProp_arg3 = stream.readInt32();
					Vector3 onUseProp_arg4 = stream.readVector3();
					onUseProp(onUseProp_arg1, onUseProp_arg2, onUseProp_arg3, onUseProp_arg4);
					break;
				default:
					break;
			};
		}

		public override void onUpdatePropertys(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Account"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			while(stream.length() > 0)
			{
				UInt16 _t_utype = 0;
				UInt16 _t_child_utype = 0;

				{
					if(sm.usePropertyDescrAlias)
					{
						_t_utype = stream.readUint8();
						_t_child_utype = stream.readUint8();
					}
					else
					{
						_t_utype = stream.readUint16();
						_t_child_utype = stream.readUint16();
					}
				}

				Property prop = null;

				if(_t_utype == 0)
				{
					prop = pdatas[_t_child_utype];
				}
				else
				{
					Property pComponentPropertyDescription = pdatas[_t_utype];
					switch(pComponentPropertyDescription.properUtype)
					{
						default:
							break;
					}

					return;
				}

				switch(prop.properUtype)
				{
					case 40001:
						Vector3 oldval_direction = direction;
						direction = stream.readVector3();

						if(prop.isBase())
						{
							if(inited)
								onDirectionChanged(oldval_direction);
						}
						else
						{
							if(inWorld)
								onDirectionChanged(oldval_direction);
						}

						break;
					case 5:
						string oldval_nameS = nameS;
						nameS = stream.readUnicode();

						if(prop.isBase())
						{
							if(inited)
								onNameSChanged(oldval_nameS);
						}
						else
						{
							if(inWorld)
								onNameSChanged(oldval_nameS);
						}

						break;
					case 40000:
						Vector3 oldval_position = position;
						position = stream.readVector3();

						if(prop.isBase())
						{
							if(inited)
								onPositionChanged(oldval_position);
						}
						else
						{
							if(inWorld)
								onPositionChanged(oldval_position);
						}

						break;
					case 7:
						Int32 oldval_progress = progress;
						progress = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onProgressChanged(oldval_progress);
						}
						else
						{
							if(inWorld)
								onProgressChanged(oldval_progress);
						}

						break;
					case 9:
						Int32 oldval_roomNo = roomNo;
						roomNo = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onRoomNoChanged(oldval_roomNo);
						}
						else
						{
							if(inWorld)
								onRoomNoChanged(oldval_roomNo);
						}

						break;
					case 40002:
						stream.readUint32();
						break;
					default:
						break;
				};
			}
		}

		public override void callPropertysSetMethods()
		{
			ScriptModule sm = EntityDef.moduledefs["Account"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			Vector3 oldval_direction = direction;
			Property prop_direction = pdatas[2];
			if(prop_direction.isBase())
			{
				if(inited && !inWorld)
					onDirectionChanged(oldval_direction);
			}
			else
			{
				if(inWorld)
				{
					if(prop_direction.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onDirectionChanged(oldval_direction);
					}
				}
			}

			string oldval_nameS = nameS;
			Property prop_nameS = pdatas[4];
			if(prop_nameS.isBase())
			{
				if(inited && !inWorld)
					onNameSChanged(oldval_nameS);
			}
			else
			{
				if(inWorld)
				{
					if(prop_nameS.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onNameSChanged(oldval_nameS);
					}
				}
			}

			Vector3 oldval_position = position;
			Property prop_position = pdatas[1];
			if(prop_position.isBase())
			{
				if(inited && !inWorld)
					onPositionChanged(oldval_position);
			}
			else
			{
				if(inWorld)
				{
					if(prop_position.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onPositionChanged(oldval_position);
					}
				}
			}

			Int32 oldval_progress = progress;
			Property prop_progress = pdatas[5];
			if(prop_progress.isBase())
			{
				if(inited && !inWorld)
					onProgressChanged(oldval_progress);
			}
			else
			{
				if(inWorld)
				{
					if(prop_progress.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onProgressChanged(oldval_progress);
					}
				}
			}

			Int32 oldval_roomNo = roomNo;
			Property prop_roomNo = pdatas[6];
			if(prop_roomNo.isBase())
			{
				if(inited && !inWorld)
					onRoomNoChanged(oldval_roomNo);
			}
			else
			{
				if(inWorld)
				{
					if(prop_roomNo.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onRoomNoChanged(oldval_roomNo);
					}
				}
			}

		}
	}
}