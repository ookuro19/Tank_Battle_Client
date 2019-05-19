/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Robot : RobotBase)
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Robot.def
	// Please inherit and implement "class Robot : RobotBase"
	public abstract class RobotBase : Entity
	{
		public EntityBaseEntityCall_RobotBase baseEntityCall = null;
		public EntityCellEntityCall_RobotBase cellEntityCall = null;

		public string nameS = "";
		public virtual void onNameSChanged(string oldValue) {}
		public Int32 progress = 100;
		public virtual void onProgressChanged(Int32 oldValue) {}
		public Int32 roomNo = 0;
		public virtual void onRoomNoChanged(Int32 oldValue) {}


		public RobotBase()
		{
		}

		public override void onGetBase()
		{
			baseEntityCall = new EntityBaseEntityCall_RobotBase(id, className);
		}

		public override void onGetCell()
		{
			cellEntityCall = new EntityCellEntityCall_RobotBase(id, className);
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
			ScriptModule sm = EntityDef.moduledefs["Robot"];

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
				default:
					break;
			};
		}

		public override void onUpdatePropertys(MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Robot"];
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
					case 10:
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
					case 11:
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
					case 13:
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
			ScriptModule sm = EntityDef.moduledefs["Robot"];
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