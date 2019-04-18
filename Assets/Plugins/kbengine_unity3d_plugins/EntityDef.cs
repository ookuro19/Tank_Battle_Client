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

	public class EntityDef
	{
		public static Dictionary<string, UInt16> datatype2id = new Dictionary<string, UInt16>();
		public static Dictionary<string, DATATYPE_BASE> datatypes = new Dictionary<string, DATATYPE_BASE>();
		public static Dictionary<UInt16, DATATYPE_BASE> id2datatypes = new Dictionary<UInt16, DATATYPE_BASE>();
		public static Dictionary<string, Int32> entityclass = new Dictionary<string, Int32>();
		public static Dictionary<string, ScriptModule> moduledefs = new Dictionary<string, ScriptModule>();
		public static Dictionary<UInt16, ScriptModule> idmoduledefs = new Dictionary<UInt16, ScriptModule>();

		public static bool init()
		{
			initDataTypes();
			initDefTypes();
			initScriptModules();
			return true;
		}

		public static bool reset()
		{
			clear();
			return init();
		}

		public static void clear()
		{
			datatype2id.Clear();
			datatypes.Clear();
			id2datatypes.Clear();
			entityclass.Clear();
			moduledefs.Clear();
			idmoduledefs.Clear();
		}

		public static void initDataTypes()
		{
			datatypes["UINT8"] = new DATATYPE_UINT8();
			datatypes["UINT16"] = new DATATYPE_UINT16();
			datatypes["UINT32"] = new DATATYPE_UINT32();
			datatypes["UINT64"] = new DATATYPE_UINT64();

			datatypes["INT8"] = new DATATYPE_INT8();
			datatypes["INT16"] = new DATATYPE_INT16();
			datatypes["INT32"] = new DATATYPE_INT32();
			datatypes["INT64"] = new DATATYPE_INT64();

			datatypes["FLOAT"] = new DATATYPE_FLOAT();
			datatypes["DOUBLE"] = new DATATYPE_DOUBLE();

			datatypes["STRING"] = new DATATYPE_STRING();
			datatypes["VECTOR2"] = new DATATYPE_VECTOR2();

			datatypes["VECTOR3"] = new DATATYPE_VECTOR3();

			datatypes["VECTOR4"] = new DATATYPE_VECTOR4();
			datatypes["PYTHON"] = new DATATYPE_PYTHON();

			datatypes["UNICODE"] = new DATATYPE_UNICODE();
			datatypes["ENTITYCALL"] = new DATATYPE_ENTITYCALL();

			datatypes["BLOB"] = new DATATYPE_BLOB();
		}

		public static void initScriptModules()
		{
			ScriptModule pAccountModule = new ScriptModule("Account");
			EntityDef.moduledefs["Account"] = pAccountModule;
			EntityDef.idmoduledefs[1] = pAccountModule;

			Property pAccount_position = new Property();
			pAccount_position.name = "position";
			pAccount_position.properUtype = 40000;
			pAccount_position.properFlags = 4;
			pAccount_position.aliasID = 1;
			Vector3 Account_position_defval = new Vector3();
			pAccount_position.defaultVal = Account_position_defval;
			pAccountModule.propertys["position"] = pAccount_position; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_position.aliasID] = pAccount_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(position / 40000).");

			Property pAccount_direction = new Property();
			pAccount_direction.name = "direction";
			pAccount_direction.properUtype = 40001;
			pAccount_direction.properFlags = 4;
			pAccount_direction.aliasID = 2;
			Vector3 Account_direction_defval = new Vector3();
			pAccount_direction.defaultVal = Account_direction_defval;
			pAccountModule.propertys["direction"] = pAccount_direction; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_direction.aliasID] = pAccount_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(direction / 40001).");

			Property pAccount_spaceID = new Property();
			pAccount_spaceID.name = "spaceID";
			pAccount_spaceID.properUtype = 40002;
			pAccount_spaceID.properFlags = 16;
			pAccount_spaceID.aliasID = 3;
			UInt32 Account_spaceID_defval;
			UInt32.TryParse("", out Account_spaceID_defval);
			pAccount_spaceID.defaultVal = Account_spaceID_defval;
			pAccountModule.propertys["spaceID"] = pAccount_spaceID; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_spaceID.aliasID] = pAccount_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(spaceID / 40002).");

			Property pAccount_nameS = new Property();
			pAccount_nameS.name = "nameS";
			pAccount_nameS.properUtype = 5;
			pAccount_nameS.properFlags = 4;
			pAccount_nameS.aliasID = 4;
			string Account_nameS_defval = "";
			pAccount_nameS.defaultVal = Account_nameS_defval;
			pAccountModule.propertys["nameS"] = pAccount_nameS; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_nameS.aliasID] = pAccount_nameS;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(nameS / 5).");

			Property pAccount_progress = new Property();
			pAccount_progress.name = "progress";
			pAccount_progress.properUtype = 7;
			pAccount_progress.properFlags = 128;
			pAccount_progress.aliasID = 5;
			Int32 Account_progress_defval;
			Int32.TryParse("0", out Account_progress_defval);
			pAccount_progress.defaultVal = Account_progress_defval;
			pAccountModule.propertys["progress"] = pAccount_progress; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_progress.aliasID] = pAccount_progress;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(progress / 7).");

			Property pAccount_roomNo = new Property();
			pAccount_roomNo.name = "roomNo";
			pAccount_roomNo.properUtype = 9;
			pAccount_roomNo.properFlags = 4;
			pAccount_roomNo.aliasID = 6;
			Int32 Account_roomNo_defval;
			Int32.TryParse("0", out Account_roomNo_defval);
			pAccount_roomNo.defaultVal = Account_roomNo_defval;
			pAccountModule.propertys["roomNo"] = pAccount_roomNo; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_roomNo.aliasID] = pAccount_roomNo;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(roomNo / 9).");

			List<DATATYPE_BASE> pAccount_onExitRoom_args = new List<DATATYPE_BASE>();
			pAccount_onExitRoom_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onExitRoom = new Method();
			pAccount_onExitRoom.name = "onExitRoom";
			pAccount_onExitRoom.methodUtype = 22;
			pAccount_onExitRoom.aliasID = 1;
			pAccount_onExitRoom.args = pAccount_onExitRoom_args;

			pAccountModule.methods["onExitRoom"] = pAccount_onExitRoom; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onExitRoom.aliasID] = pAccount_onExitRoom;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onExitRoom / 22).");

			List<DATATYPE_BASE> pAccount_onGetProps_args = new List<DATATYPE_BASE>();
			pAccount_onGetProps_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onGetProps = new Method();
			pAccount_onGetProps.name = "onGetProps";
			pAccount_onGetProps.methodUtype = 17;
			pAccount_onGetProps.aliasID = 2;
			pAccount_onGetProps.args = pAccount_onGetProps_args;

			pAccountModule.methods["onGetProps"] = pAccount_onGetProps; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onGetProps.aliasID] = pAccount_onGetProps;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onGetProps / 17).");

			List<DATATYPE_BASE> pAccount_onLoadingFinish_args = new List<DATATYPE_BASE>();
			pAccount_onLoadingFinish_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onLoadingFinish = new Method();
			pAccount_onLoadingFinish.name = "onLoadingFinish";
			pAccount_onLoadingFinish.methodUtype = 16;
			pAccount_onLoadingFinish.aliasID = 3;
			pAccount_onLoadingFinish.args = pAccount_onLoadingFinish_args;

			pAccountModule.methods["onLoadingFinish"] = pAccount_onLoadingFinish; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onLoadingFinish.aliasID] = pAccount_onLoadingFinish;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onLoadingFinish / 16).");

			List<DATATYPE_BASE> pAccount_onLoginState_args = new List<DATATYPE_BASE>();
			pAccount_onLoginState_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onLoginState = new Method();
			pAccount_onLoginState.name = "onLoginState";
			pAccount_onLoginState.methodUtype = 13;
			pAccount_onLoginState.aliasID = 4;
			pAccount_onLoginState.args = pAccount_onLoginState_args;

			pAccountModule.methods["onLoginState"] = pAccount_onLoginState; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onLoginState.aliasID] = pAccount_onLoginState;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onLoginState / 13).");

			List<DATATYPE_BASE> pAccount_onMapModeChanged_args = new List<DATATYPE_BASE>();
			pAccount_onMapModeChanged_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onMapModeChanged = new Method();
			pAccount_onMapModeChanged.name = "onMapModeChanged";
			pAccount_onMapModeChanged.methodUtype = 14;
			pAccount_onMapModeChanged.aliasID = 5;
			pAccount_onMapModeChanged.args = pAccount_onMapModeChanged_args;

			pAccountModule.methods["onMapModeChanged"] = pAccount_onMapModeChanged; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onMapModeChanged.aliasID] = pAccount_onMapModeChanged;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onMapModeChanged / 14).");

			List<DATATYPE_BASE> pAccount_onMatchingFinish_args = new List<DATATYPE_BASE>();
			pAccount_onMatchingFinish_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onMatchingFinish = new Method();
			pAccount_onMatchingFinish.name = "onMatchingFinish";
			pAccount_onMatchingFinish.methodUtype = 15;
			pAccount_onMatchingFinish.aliasID = 6;
			pAccount_onMatchingFinish.args = pAccount_onMatchingFinish_args;

			pAccountModule.methods["onMatchingFinish"] = pAccount_onMatchingFinish; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onMatchingFinish.aliasID] = pAccount_onMatchingFinish;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onMatchingFinish / 15).");

			List<DATATYPE_BASE> pAccount_onReachDestination_args = new List<DATATYPE_BASE>();
			pAccount_onReachDestination_args.Add(EntityDef.id2datatypes[8]);
			pAccount_onReachDestination_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onReachDestination = new Method();
			pAccount_onReachDestination.name = "onReachDestination";
			pAccount_onReachDestination.methodUtype = 20;
			pAccount_onReachDestination.aliasID = 7;
			pAccount_onReachDestination.args = pAccount_onReachDestination_args;

			pAccountModule.methods["onReachDestination"] = pAccount_onReachDestination; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onReachDestination.aliasID] = pAccount_onReachDestination;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onReachDestination / 20).");

			List<DATATYPE_BASE> pAccount_onSkillResult_args = new List<DATATYPE_BASE>();
			pAccount_onSkillResult_args.Add(EntityDef.id2datatypes[8]);
			pAccount_onSkillResult_args.Add(EntityDef.id2datatypes[8]);
			pAccount_onSkillResult_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onSkillResult = new Method();
			pAccount_onSkillResult.name = "onSkillResult";
			pAccount_onSkillResult.methodUtype = 19;
			pAccount_onSkillResult.aliasID = 8;
			pAccount_onSkillResult.args = pAccount_onSkillResult_args;

			pAccountModule.methods["onSkillResult"] = pAccount_onSkillResult; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onSkillResult.aliasID] = pAccount_onSkillResult;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onSkillResult / 19).");

			List<DATATYPE_BASE> pAccount_onTimerChanged_args = new List<DATATYPE_BASE>();
			pAccount_onTimerChanged_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onTimerChanged = new Method();
			pAccount_onTimerChanged.name = "onTimerChanged";
			pAccount_onTimerChanged.methodUtype = 21;
			pAccount_onTimerChanged.aliasID = 9;
			pAccount_onTimerChanged.args = pAccount_onTimerChanged_args;

			pAccountModule.methods["onTimerChanged"] = pAccount_onTimerChanged; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onTimerChanged.aliasID] = pAccount_onTimerChanged;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onTimerChanged / 21).");

			List<DATATYPE_BASE> pAccount_onUseSkill_args = new List<DATATYPE_BASE>();
			pAccount_onUseSkill_args.Add(EntityDef.id2datatypes[8]);
			pAccount_onUseSkill_args.Add(EntityDef.id2datatypes[8]);
			pAccount_onUseSkill_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_onUseSkill = new Method();
			pAccount_onUseSkill.name = "onUseSkill";
			pAccount_onUseSkill.methodUtype = 18;
			pAccount_onUseSkill.aliasID = 10;
			pAccount_onUseSkill.args = pAccount_onUseSkill_args;

			pAccountModule.methods["onUseSkill"] = pAccount_onUseSkill; 
			pAccountModule.useMethodDescrAlias = true;
			pAccountModule.idmethods[(UInt16)pAccount_onUseSkill.aliasID] = pAccount_onUseSkill;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(onUseSkill / 18).");

			List<DATATYPE_BASE> pAccount_regStartMatching_args = new List<DATATYPE_BASE>();
			pAccount_regStartMatching_args.Add(EntityDef.id2datatypes[8]);
			pAccount_regStartMatching_args.Add(EntityDef.id2datatypes[8]);
			pAccount_regStartMatching_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_regStartMatching = new Method();
			pAccount_regStartMatching.name = "regStartMatching";
			pAccount_regStartMatching.methodUtype = 6;
			pAccount_regStartMatching.aliasID = -1;
			pAccount_regStartMatching.args = pAccount_regStartMatching_args;

			pAccountModule.methods["regStartMatching"] = pAccount_regStartMatching; 
			pAccountModule.base_methods["regStartMatching"] = pAccount_regStartMatching;

			pAccountModule.idbase_methods[pAccount_regStartMatching.methodUtype] = pAccount_regStartMatching;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(regStartMatching / 6).");

			List<DATATYPE_BASE> pAccount_regGetProps_args = new List<DATATYPE_BASE>();
			pAccount_regGetProps_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_regGetProps = new Method();
			pAccount_regGetProps.name = "regGetProps";
			pAccount_regGetProps.methodUtype = 3;
			pAccount_regGetProps.aliasID = -1;
			pAccount_regGetProps.args = pAccount_regGetProps_args;

			pAccountModule.methods["regGetProps"] = pAccount_regGetProps; 
			pAccountModule.cell_methods["regGetProps"] = pAccount_regGetProps;

			pAccountModule.idcell_methods[pAccount_regGetProps.methodUtype] = pAccount_regGetProps;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(regGetProps / 3).");

			List<DATATYPE_BASE> pAccount_regProgress_args = new List<DATATYPE_BASE>();
			pAccount_regProgress_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_regProgress = new Method();
			pAccount_regProgress.name = "regProgress";
			pAccount_regProgress.methodUtype = 1;
			pAccount_regProgress.aliasID = -1;
			pAccount_regProgress.args = pAccount_regProgress_args;

			pAccountModule.methods["regProgress"] = pAccount_regProgress; 
			pAccountModule.cell_methods["regProgress"] = pAccount_regProgress;

			pAccountModule.idcell_methods[pAccount_regProgress.methodUtype] = pAccount_regProgress;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(regProgress / 1).");

			List<DATATYPE_BASE> pAccount_regReachDestination_args = new List<DATATYPE_BASE>();

			Method pAccount_regReachDestination = new Method();
			pAccount_regReachDestination.name = "regReachDestination";
			pAccount_regReachDestination.methodUtype = 2;
			pAccount_regReachDestination.aliasID = -1;
			pAccount_regReachDestination.args = pAccount_regReachDestination_args;

			pAccountModule.methods["regReachDestination"] = pAccount_regReachDestination; 
			pAccountModule.cell_methods["regReachDestination"] = pAccount_regReachDestination;

			pAccountModule.idcell_methods[pAccount_regReachDestination.methodUtype] = pAccount_regReachDestination;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(regReachDestination / 2).");

			List<DATATYPE_BASE> pAccount_regSkillResult_args = new List<DATATYPE_BASE>();
			pAccount_regSkillResult_args.Add(EntityDef.id2datatypes[8]);
			pAccount_regSkillResult_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_regSkillResult = new Method();
			pAccount_regSkillResult.name = "regSkillResult";
			pAccount_regSkillResult.methodUtype = 5;
			pAccount_regSkillResult.aliasID = -1;
			pAccount_regSkillResult.args = pAccount_regSkillResult_args;

			pAccountModule.methods["regSkillResult"] = pAccount_regSkillResult; 
			pAccountModule.cell_methods["regSkillResult"] = pAccount_regSkillResult;

			pAccountModule.idcell_methods[pAccount_regSkillResult.methodUtype] = pAccount_regSkillResult;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(regSkillResult / 5).");

			List<DATATYPE_BASE> pAccount_regUseSkill_args = new List<DATATYPE_BASE>();
			pAccount_regUseSkill_args.Add(EntityDef.id2datatypes[8]);
			pAccount_regUseSkill_args.Add(EntityDef.id2datatypes[8]);

			Method pAccount_regUseSkill = new Method();
			pAccount_regUseSkill.name = "regUseSkill";
			pAccount_regUseSkill.methodUtype = 4;
			pAccount_regUseSkill.aliasID = -1;
			pAccount_regUseSkill.args = pAccount_regUseSkill_args;

			pAccountModule.methods["regUseSkill"] = pAccount_regUseSkill; 
			pAccountModule.cell_methods["regUseSkill"] = pAccount_regUseSkill;

			pAccountModule.idcell_methods[pAccount_regUseSkill.methodUtype] = pAccount_regUseSkill;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), method(regUseSkill / 4).");

			ScriptModule pRobotModule = new ScriptModule("Robot");
			EntityDef.moduledefs["Robot"] = pRobotModule;
			EntityDef.idmoduledefs[2] = pRobotModule;

			Property pRobot_position = new Property();
			pRobot_position.name = "position";
			pRobot_position.properUtype = 40000;
			pRobot_position.properFlags = 4;
			pRobot_position.aliasID = 1;
			Vector3 Robot_position_defval = new Vector3();
			pRobot_position.defaultVal = Robot_position_defval;
			pRobotModule.propertys["position"] = pRobot_position; 

			pRobotModule.usePropertyDescrAlias = true;
			pRobotModule.idpropertys[(UInt16)pRobot_position.aliasID] = pRobot_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Robot), property(position / 40000).");

			Property pRobot_direction = new Property();
			pRobot_direction.name = "direction";
			pRobot_direction.properUtype = 40001;
			pRobot_direction.properFlags = 4;
			pRobot_direction.aliasID = 2;
			Vector3 Robot_direction_defval = new Vector3();
			pRobot_direction.defaultVal = Robot_direction_defval;
			pRobotModule.propertys["direction"] = pRobot_direction; 

			pRobotModule.usePropertyDescrAlias = true;
			pRobotModule.idpropertys[(UInt16)pRobot_direction.aliasID] = pRobot_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Robot), property(direction / 40001).");

			Property pRobot_spaceID = new Property();
			pRobot_spaceID.name = "spaceID";
			pRobot_spaceID.properUtype = 40002;
			pRobot_spaceID.properFlags = 16;
			pRobot_spaceID.aliasID = 3;
			UInt32 Robot_spaceID_defval;
			UInt32.TryParse("", out Robot_spaceID_defval);
			pRobot_spaceID.defaultVal = Robot_spaceID_defval;
			pRobotModule.propertys["spaceID"] = pRobot_spaceID; 

			pRobotModule.usePropertyDescrAlias = true;
			pRobotModule.idpropertys[(UInt16)pRobot_spaceID.aliasID] = pRobot_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Robot), property(spaceID / 40002).");

			Property pRobot_nameS = new Property();
			pRobot_nameS.name = "nameS";
			pRobot_nameS.properUtype = 10;
			pRobot_nameS.properFlags = 4;
			pRobot_nameS.aliasID = 4;
			string Robot_nameS_defval = "";
			pRobot_nameS.defaultVal = Robot_nameS_defval;
			pRobotModule.propertys["nameS"] = pRobot_nameS; 

			pRobotModule.usePropertyDescrAlias = true;
			pRobotModule.idpropertys[(UInt16)pRobot_nameS.aliasID] = pRobot_nameS;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Robot), property(nameS / 10).");

			Property pRobot_progress = new Property();
			pRobot_progress.name = "progress";
			pRobot_progress.properUtype = 11;
			pRobot_progress.properFlags = 4;
			pRobot_progress.aliasID = 5;
			Int32 Robot_progress_defval;
			Int32.TryParse("100", out Robot_progress_defval);
			pRobot_progress.defaultVal = Robot_progress_defval;
			pRobotModule.propertys["progress"] = pRobot_progress; 

			pRobotModule.usePropertyDescrAlias = true;
			pRobotModule.idpropertys[(UInt16)pRobot_progress.aliasID] = pRobot_progress;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Robot), property(progress / 11).");

			Property pRobot_roomNo = new Property();
			pRobot_roomNo.name = "roomNo";
			pRobot_roomNo.properUtype = 12;
			pRobot_roomNo.properFlags = 4;
			pRobot_roomNo.aliasID = 6;
			Int32 Robot_roomNo_defval;
			Int32.TryParse("0", out Robot_roomNo_defval);
			pRobot_roomNo.defaultVal = Robot_roomNo_defval;
			pRobotModule.propertys["roomNo"] = pRobot_roomNo; 

			pRobotModule.usePropertyDescrAlias = true;
			pRobotModule.idpropertys[(UInt16)pRobot_roomNo.aliasID] = pRobot_roomNo;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Robot), property(roomNo / 12).");

			pRobotModule.useMethodDescrAlias = true;
			List<DATATYPE_BASE> pRobot_regReachDestination_args = new List<DATATYPE_BASE>();

			Method pRobot_regReachDestination = new Method();
			pRobot_regReachDestination.name = "regReachDestination";
			pRobot_regReachDestination.methodUtype = 23;
			pRobot_regReachDestination.aliasID = -1;
			pRobot_regReachDestination.args = pRobot_regReachDestination_args;

			pRobotModule.methods["regReachDestination"] = pRobot_regReachDestination; 
			pRobotModule.cell_methods["regReachDestination"] = pRobot_regReachDestination;

			pRobotModule.idcell_methods[pRobot_regReachDestination.methodUtype] = pRobot_regReachDestination;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Robot), method(regReachDestination / 23).");

		}

		public static void initDefTypes()
		{
			{
				UInt16 utype = 2;
				string typeName = "UINT8";
				string name = "UINT8";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 3;
				string typeName = "UINT16";
				string name = "UINT16";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 5;
				string typeName = "ROOM_NUM";
				string name = "UINT64";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 4;
				string typeName = "UINT32";
				string name = "UINT32";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 6;
				string typeName = "INT8";
				string name = "INT8";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 7;
				string typeName = "INT16";
				string name = "INT16";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 8;
				string typeName = "MATCH_CODE";
				string name = "INT32";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 9;
				string typeName = "INT64";
				string name = "INT64";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 1;
				string typeName = "STRING";
				string name = "STRING";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 12;
				string typeName = "UNICODE";
				string name = "UNICODE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 13;
				string typeName = "FLOAT";
				string name = "FLOAT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 14;
				string typeName = "DOUBLE";
				string name = "DOUBLE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PYTHON";
				string name = "PYTHON";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_DICT";
				string name = "PY_DICT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_TUPLE";
				string name = "PY_TUPLE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_LIST";
				string name = "PY_LIST";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 20;
				string typeName = "ENTITYCALL";
				string name = "ENTITYCALL";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 11;
				string typeName = "BLOB";
				string name = "BLOB";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 15;
				string typeName = "VECTOR2";
				string name = "VECTOR2";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 16;
				string typeName = "DIRECTION3D";
				string name = "VECTOR3";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 17;
				string typeName = "VECTOR4";
				string name = "VECTOR4";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			foreach(string datatypeStr in EntityDef.datatypes.Keys)
			{
				DATATYPE_BASE dataType = EntityDef.datatypes[datatypeStr];
				if(dataType != null)
				{
					dataType.bind();
				}
			}
		}

	}


}