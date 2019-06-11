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

		public ITEM_LIST bagItemList = new ITEM_LIST();
		public virtual void onBagItemListChanged(ITEM_LIST oldValue) {}
		public EQUIP_DICT currentItemDict = new EQUIP_DICT();
		public virtual void onCurrentItemDictChanged(EQUIP_DICT oldValue) {}
		public Int32 gold = 0;
		public virtual void onGoldChanged(Int32 oldValue) {}
		public SByte lastLoginDate = 0;
		public virtual void onLastLoginDateChanged(SByte oldValue) {}
		public Int16 lastLoginDayLoginTimes = 0;
		public virtual void onLastLoginDayLoginTimesChanged(Int16 oldValue) {}
		public Int16 lastLoginDayPlayTime = 0;
		public virtual void onLastLoginDayPlayTimeChanged(Int16 oldValue) {}
		public string nameS = "";
		public virtual void onNameSChanged(string oldValue) {}
		public Int32 progress = 0;
		public virtual void onProgressChanged(Int32 oldValue) {}
		public Int32 roomNo = 0;
		public virtual void onRoomNoChanged(Int32 oldValue) {}
		public Int16 totalLoginTimes = 0;
		public virtual void onTotalLoginTimesChanged(Int16 oldValue) {}
		public Int16 totalPlayTime = 0;
		public virtual void onTotalPlayTimeChanged(Int16 oldValue) {}

		public abstract void onBuyEquip(Int32 arg1, Byte arg2); 
		public abstract void onChangeEquip(Int32 arg1, Byte arg2); 
		public abstract void onExitRoom(Int32 arg1); 
		public abstract void onGetGold(Int32 arg1); 
		public abstract void onGetPropsClient(Int32 arg1, string arg2, Int32 arg3); 
		public abstract void onLoadingFinish(Int32 arg1); 
		public abstract void onLoginState(Int32 arg1); 
		public abstract void onMapModeChanged(Int32 arg1, Int32 arg2); 
		public abstract void onMatchingFinish(Int32 arg1); 
		public abstract void onPropResultClient(Int32 arg1, Int32 arg2, Int32 arg3, Byte arg4); 
		public abstract void onReachDestination(Int32 arg1, Int32 arg2); 
		public abstract void onResetPropClient(PROP_LIST arg1); 
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
				case 29:
					Int32 onBuyEquip_arg1 = stream.readInt32();
					Byte onBuyEquip_arg2 = stream.readUint8();
					onBuyEquip(onBuyEquip_arg1, onBuyEquip_arg2);
					break;
				case 30:
					Int32 onChangeEquip_arg1 = stream.readInt32();
					Byte onChangeEquip_arg2 = stream.readUint8();
					onChangeEquip(onChangeEquip_arg1, onChangeEquip_arg2);
					break;
				case 28:
					Int32 onExitRoom_arg1 = stream.readInt32();
					onExitRoom(onExitRoom_arg1);
					break;
				case 31:
					Int32 onGetGold_arg1 = stream.readInt32();
					onGetGold(onGetGold_arg1);
					break;
				case 22:
					Int32 onGetPropsClient_arg1 = stream.readInt32();
					string onGetPropsClient_arg2 = stream.readUnicode();
					Int32 onGetPropsClient_arg3 = stream.readInt32();
					onGetPropsClient(onGetPropsClient_arg1, onGetPropsClient_arg2, onGetPropsClient_arg3);
					break;
				case 21:
					Int32 onLoadingFinish_arg1 = stream.readInt32();
					onLoadingFinish(onLoadingFinish_arg1);
					break;
				case 18:
					Int32 onLoginState_arg1 = stream.readInt32();
					onLoginState(onLoginState_arg1);
					break;
				case 19:
					Int32 onMapModeChanged_arg1 = stream.readInt32();
					Int32 onMapModeChanged_arg2 = stream.readInt32();
					onMapModeChanged(onMapModeChanged_arg1, onMapModeChanged_arg2);
					break;
				case 20:
					Int32 onMatchingFinish_arg1 = stream.readInt32();
					onMatchingFinish(onMatchingFinish_arg1);
					break;
				case 24:
					Int32 onPropResultClient_arg1 = stream.readInt32();
					Int32 onPropResultClient_arg2 = stream.readInt32();
					Int32 onPropResultClient_arg3 = stream.readInt32();
					Byte onPropResultClient_arg4 = stream.readUint8();
					onPropResultClient(onPropResultClient_arg1, onPropResultClient_arg2, onPropResultClient_arg3, onPropResultClient_arg4);
					break;
				case 26:
					Int32 onReachDestination_arg1 = stream.readInt32();
					Int32 onReachDestination_arg2 = stream.readInt32();
					onReachDestination(onReachDestination_arg1, onReachDestination_arg2);
					break;
				case 25:
					PROP_LIST onResetPropClient_arg1 = ((DATATYPE_PROP_LIST)method.args[0]).createFromStreamEx(stream);
					onResetPropClient(onResetPropClient_arg1);
					break;
				case 27:
					Int32 onTimerChanged_arg1 = stream.readInt32();
					onTimerChanged(onTimerChanged_arg1);
					break;
				case 23:
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
					case 16:
						ITEM_LIST oldval_bagItemList = bagItemList;
						bagItemList = ((DATATYPE_ITEM_LIST)EntityDef.id2datatypes[23]).createFromStreamEx(stream);

						if(prop.isBase())
						{
							if(inited)
								onBagItemListChanged(oldval_bagItemList);
						}
						else
						{
							if(inWorld)
								onBagItemListChanged(oldval_bagItemList);
						}

						break;
					case 17:
						EQUIP_DICT oldval_currentItemDict = currentItemDict;
						currentItemDict = ((DATATYPE_EQUIP_DICT)EntityDef.id2datatypes[24]).createFromStreamEx(stream);

						if(prop.isBase())
						{
							if(inited)
								onCurrentItemDictChanged(oldval_currentItemDict);
						}
						else
						{
							if(inWorld)
								onCurrentItemDictChanged(oldval_currentItemDict);
						}

						break;
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
					case 8:
						Int32 oldval_gold = gold;
						gold = stream.readInt32();

						if(prop.isBase())
						{
							if(inited)
								onGoldChanged(oldval_gold);
						}
						else
						{
							if(inWorld)
								onGoldChanged(oldval_gold);
						}

						break;
					case 3:
						SByte oldval_lastLoginDate = lastLoginDate;
						lastLoginDate = stream.readInt8();

						if(prop.isBase())
						{
							if(inited)
								onLastLoginDateChanged(oldval_lastLoginDate);
						}
						else
						{
							if(inWorld)
								onLastLoginDateChanged(oldval_lastLoginDate);
						}

						break;
					case 7:
						Int16 oldval_lastLoginDayLoginTimes = lastLoginDayLoginTimes;
						lastLoginDayLoginTimes = stream.readInt16();

						if(prop.isBase())
						{
							if(inited)
								onLastLoginDayLoginTimesChanged(oldval_lastLoginDayLoginTimes);
						}
						else
						{
							if(inWorld)
								onLastLoginDayLoginTimesChanged(oldval_lastLoginDayLoginTimes);
						}

						break;
					case 5:
						Int16 oldval_lastLoginDayPlayTime = lastLoginDayPlayTime;
						lastLoginDayPlayTime = stream.readInt16();

						if(prop.isBase())
						{
							if(inited)
								onLastLoginDayPlayTimeChanged(oldval_lastLoginDayPlayTime);
						}
						else
						{
							if(inWorld)
								onLastLoginDayPlayTimeChanged(oldval_lastLoginDayPlayTime);
						}

						break;
					case 2:
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
					case 13:
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
					case 15:
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
					case 6:
						Int16 oldval_totalLoginTimes = totalLoginTimes;
						totalLoginTimes = stream.readInt16();

						if(prop.isBase())
						{
							if(inited)
								onTotalLoginTimesChanged(oldval_totalLoginTimes);
						}
						else
						{
							if(inWorld)
								onTotalLoginTimesChanged(oldval_totalLoginTimes);
						}

						break;
					case 4:
						Int16 oldval_totalPlayTime = totalPlayTime;
						totalPlayTime = stream.readInt16();

						if(prop.isBase())
						{
							if(inited)
								onTotalPlayTimeChanged(oldval_totalPlayTime);
						}
						else
						{
							if(inWorld)
								onTotalPlayTimeChanged(oldval_totalPlayTime);
						}

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

			ITEM_LIST oldval_bagItemList = bagItemList;
			Property prop_bagItemList = pdatas[4];
			if(prop_bagItemList.isBase())
			{
				if(inited && !inWorld)
					onBagItemListChanged(oldval_bagItemList);
			}
			else
			{
				if(inWorld)
				{
					if(prop_bagItemList.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onBagItemListChanged(oldval_bagItemList);
					}
				}
			}

			EQUIP_DICT oldval_currentItemDict = currentItemDict;
			Property prop_currentItemDict = pdatas[5];
			if(prop_currentItemDict.isBase())
			{
				if(inited && !inWorld)
					onCurrentItemDictChanged(oldval_currentItemDict);
			}
			else
			{
				if(inWorld)
				{
					if(prop_currentItemDict.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onCurrentItemDictChanged(oldval_currentItemDict);
					}
				}
			}

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

			Int32 oldval_gold = gold;
			Property prop_gold = pdatas[6];
			if(prop_gold.isBase())
			{
				if(inited && !inWorld)
					onGoldChanged(oldval_gold);
			}
			else
			{
				if(inWorld)
				{
					if(prop_gold.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onGoldChanged(oldval_gold);
					}
				}
			}

			SByte oldval_lastLoginDate = lastLoginDate;
			Property prop_lastLoginDate = pdatas[7];
			if(prop_lastLoginDate.isBase())
			{
				if(inited && !inWorld)
					onLastLoginDateChanged(oldval_lastLoginDate);
			}
			else
			{
				if(inWorld)
				{
					if(prop_lastLoginDate.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onLastLoginDateChanged(oldval_lastLoginDate);
					}
				}
			}

			Int16 oldval_lastLoginDayLoginTimes = lastLoginDayLoginTimes;
			Property prop_lastLoginDayLoginTimes = pdatas[8];
			if(prop_lastLoginDayLoginTimes.isBase())
			{
				if(inited && !inWorld)
					onLastLoginDayLoginTimesChanged(oldval_lastLoginDayLoginTimes);
			}
			else
			{
				if(inWorld)
				{
					if(prop_lastLoginDayLoginTimes.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onLastLoginDayLoginTimesChanged(oldval_lastLoginDayLoginTimes);
					}
				}
			}

			Int16 oldval_lastLoginDayPlayTime = lastLoginDayPlayTime;
			Property prop_lastLoginDayPlayTime = pdatas[9];
			if(prop_lastLoginDayPlayTime.isBase())
			{
				if(inited && !inWorld)
					onLastLoginDayPlayTimeChanged(oldval_lastLoginDayPlayTime);
			}
			else
			{
				if(inWorld)
				{
					if(prop_lastLoginDayPlayTime.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onLastLoginDayPlayTimeChanged(oldval_lastLoginDayPlayTime);
					}
				}
			}

			string oldval_nameS = nameS;
			Property prop_nameS = pdatas[10];
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
			Property prop_progress = pdatas[11];
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
			Property prop_roomNo = pdatas[12];
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

			Int16 oldval_totalLoginTimes = totalLoginTimes;
			Property prop_totalLoginTimes = pdatas[13];
			if(prop_totalLoginTimes.isBase())
			{
				if(inited && !inWorld)
					onTotalLoginTimesChanged(oldval_totalLoginTimes);
			}
			else
			{
				if(inWorld)
				{
					if(prop_totalLoginTimes.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onTotalLoginTimesChanged(oldval_totalLoginTimes);
					}
				}
			}

			Int16 oldval_totalPlayTime = totalPlayTime;
			Property prop_totalPlayTime = pdatas[14];
			if(prop_totalPlayTime.isBase())
			{
				if(inited && !inWorld)
					onTotalPlayTimeChanged(oldval_totalPlayTime);
			}
			else
			{
				if(inWorld)
				{
					if(prop_totalPlayTime.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onTotalPlayTimeChanged(oldval_totalPlayTime);
					}
				}
			}

		}
	}
}