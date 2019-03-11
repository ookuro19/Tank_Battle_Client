/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Avatar : AvatarBase)
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Avatar.def
	// Please inherit and implement "class Avatar : AvatarBase"
	public abstract class AvatarBase : Entity
	{
		public EntityBaseEntityCall_AvatarBase baseEntityCall = null;
		public EntityCellEntityCall_AvatarBase cellEntityCall = null;

		public string name = "";
		public virtual void onNameChanged(string oldValue) {}
		public Int32 progress = 0;
		public virtual void onProgressChanged(Int32 oldValue) {}
		public Int32 roomNo = 0;
		public virtual void onRoomNoChanged(Int32 oldValue) {}

		public abstract void onLoadingFinish(Int32 arg1); 
		public abstract void onMatchingFinish(Int32 arg1); 

		public AvatarBase()
		{
		}

		public override void onGetBase()
		{
			baseEntityCall = new EntityBaseEntityCall_AvatarBase(id, className);
		}

		public override void onGetCell()
		{
			cellEntityCall = new EntityCellEntityCall_AvatarBase(id, className);
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
			ScriptModule sm = EntityDef.moduledefs["Avatar"];

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
				case 7:
					Int32 onLoadingFinish_arg1 = stream.readInt32();
					onLoadingFinish(onLoadingFinish_arg1);
					break;
				case 6:
					Int32 onMatchingFinish_arg1 = stream.readInt32();
					onMatchingFinish(onMatchingFinish_arg1);
					break;
				default:
					break;
			};
		}

		public override void onUpdatePropertys(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Avatar"];
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
					case 2:
						string oldval_name = name;
						name = stream.readUnicode();

						if(prop.isBase())
						{
							if(inited)
								onNameChanged(oldval_name);
						}
						else
						{
							if(inWorld)
								onNameChanged(oldval_name);
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
					case 4:
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
					case 5:
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
			ScriptModule sm = EntityDef.moduledefs["Avatar"];
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

			string oldval_name = name;
			Property prop_name = pdatas[4];
			if(prop_name.isBase())
			{
				if(inited && !inWorld)
					onNameChanged(oldval_name);
			}
			else
			{
				if(inWorld)
				{
					if(prop_name.isOwnerOnly() && !isPlayer())
					{
					}
					else
					{
						onNameChanged(oldval_name);
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