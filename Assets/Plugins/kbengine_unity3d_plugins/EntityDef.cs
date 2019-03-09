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
			ScriptModule pAvatarModule = new ScriptModule("Avatar");
			EntityDef.moduledefs["Avatar"] = pAvatarModule;
			EntityDef.idmoduledefs[1] = pAvatarModule;

			Property pAvatar_position = new Property();
			pAvatar_position.name = "position";
			pAvatar_position.properUtype = 40000;
			pAvatar_position.properFlags = 4;
			pAvatar_position.aliasID = 1;
			Vector3 Avatar_position_defval = new Vector3();
			pAvatar_position.defaultVal = Avatar_position_defval;
			pAvatarModule.propertys["position"] = pAvatar_position; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_position.aliasID] = pAvatar_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(position / 40000).");

			Property pAvatar_direction = new Property();
			pAvatar_direction.name = "direction";
			pAvatar_direction.properUtype = 40001;
			pAvatar_direction.properFlags = 4;
			pAvatar_direction.aliasID = 2;
			Vector3 Avatar_direction_defval = new Vector3();
			pAvatar_direction.defaultVal = Avatar_direction_defval;
			pAvatarModule.propertys["direction"] = pAvatar_direction; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_direction.aliasID] = pAvatar_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(direction / 40001).");

			Property pAvatar_spaceID = new Property();
			pAvatar_spaceID.name = "spaceID";
			pAvatar_spaceID.properUtype = 40002;
			pAvatar_spaceID.properFlags = 16;
			pAvatar_spaceID.aliasID = 3;
			UInt32 Avatar_spaceID_defval;
			UInt32.TryParse("", out Avatar_spaceID_defval);
			pAvatar_spaceID.defaultVal = Avatar_spaceID_defval;
			pAvatarModule.propertys["spaceID"] = pAvatar_spaceID; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_spaceID.aliasID] = pAvatar_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(spaceID / 40002).");

			Property pAvatar_name = new Property();
			pAvatar_name.name = "name";
			pAvatar_name.properUtype = 2;
			pAvatar_name.properFlags = 4;
			pAvatar_name.aliasID = 4;
			string Avatar_name_defval = "";
			pAvatar_name.defaultVal = Avatar_name_defval;
			pAvatarModule.propertys["name"] = pAvatar_name; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_name.aliasID] = pAvatar_name;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(name / 2).");

			Property pAvatar_progress = new Property();
			pAvatar_progress.name = "progress";
			pAvatar_progress.properUtype = 4;
			pAvatar_progress.properFlags = 128;
			pAvatar_progress.aliasID = 5;
			Int32 Avatar_progress_defval;
			Int32.TryParse("0", out Avatar_progress_defval);
			pAvatar_progress.defaultVal = Avatar_progress_defval;
			pAvatarModule.propertys["progress"] = pAvatar_progress; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_progress.aliasID] = pAvatar_progress;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(progress / 4).");

			Property pAvatar_roomNo = new Property();
			pAvatar_roomNo.name = "roomNo";
			pAvatar_roomNo.properUtype = 5;
			pAvatar_roomNo.properFlags = 4;
			pAvatar_roomNo.aliasID = 6;
			Int32 Avatar_roomNo_defval;
			Int32.TryParse("0", out Avatar_roomNo_defval);
			pAvatar_roomNo.defaultVal = Avatar_roomNo_defval;
			pAvatarModule.propertys["roomNo"] = pAvatar_roomNo; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_roomNo.aliasID] = pAvatar_roomNo;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(roomNo / 5).");

			List<DATATYPE_BASE> pAvatar_onLoadingFinish_args = new List<DATATYPE_BASE>();
			pAvatar_onLoadingFinish_args.Add(EntityDef.id2datatypes[8]);

			Method pAvatar_onLoadingFinish = new Method();
			pAvatar_onLoadingFinish.name = "onLoadingFinish";
			pAvatar_onLoadingFinish.methodUtype = 7;
			pAvatar_onLoadingFinish.aliasID = 1;
			pAvatar_onLoadingFinish.args = pAvatar_onLoadingFinish_args;

			pAvatarModule.methods["onLoadingFinish"] = pAvatar_onLoadingFinish; 
			pAvatarModule.useMethodDescrAlias = true;
			pAvatarModule.idmethods[(UInt16)pAvatar_onLoadingFinish.aliasID] = pAvatar_onLoadingFinish;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(onLoadingFinish / 7).");

			List<DATATYPE_BASE> pAvatar_onMatchingFinish_args = new List<DATATYPE_BASE>();
			pAvatar_onMatchingFinish_args.Add(EntityDef.id2datatypes[8]);

			Method pAvatar_onMatchingFinish = new Method();
			pAvatar_onMatchingFinish.name = "onMatchingFinish";
			pAvatar_onMatchingFinish.methodUtype = 6;
			pAvatar_onMatchingFinish.aliasID = 2;
			pAvatar_onMatchingFinish.args = pAvatar_onMatchingFinish_args;

			pAvatarModule.methods["onMatchingFinish"] = pAvatar_onMatchingFinish; 
			pAvatarModule.useMethodDescrAlias = true;
			pAvatarModule.idmethods[(UInt16)pAvatar_onMatchingFinish.aliasID] = pAvatar_onMatchingFinish;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(onMatchingFinish / 6).");

			List<DATATYPE_BASE> pAvatar_regLoadingProgress_args = new List<DATATYPE_BASE>();
			pAvatar_regLoadingProgress_args.Add(EntityDef.id2datatypes[8]);

			Method pAvatar_regLoadingProgress = new Method();
			pAvatar_regLoadingProgress.name = "regLoadingProgress";
			pAvatar_regLoadingProgress.methodUtype = 4;
			pAvatar_regLoadingProgress.aliasID = -1;
			pAvatar_regLoadingProgress.args = pAvatar_regLoadingProgress_args;

			pAvatarModule.methods["regLoadingProgress"] = pAvatar_regLoadingProgress; 
			pAvatarModule.base_methods["regLoadingProgress"] = pAvatar_regLoadingProgress;

			pAvatarModule.idbase_methods[pAvatar_regLoadingProgress.methodUtype] = pAvatar_regLoadingProgress;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(regLoadingProgress / 4).");

			List<DATATYPE_BASE> pAvatar_startMatching_args = new List<DATATYPE_BASE>();
			pAvatar_startMatching_args.Add(EntityDef.id2datatypes[5]);
			pAvatar_startMatching_args.Add(EntityDef.id2datatypes[5]);

			Method pAvatar_startMatching = new Method();
			pAvatar_startMatching.name = "startMatching";
			pAvatar_startMatching.methodUtype = 1;
			pAvatar_startMatching.aliasID = -1;
			pAvatar_startMatching.args = pAvatar_startMatching_args;

			pAvatarModule.methods["startMatching"] = pAvatar_startMatching; 
			pAvatarModule.base_methods["startMatching"] = pAvatar_startMatching;

			pAvatarModule.idbase_methods[pAvatar_startMatching.methodUtype] = pAvatar_startMatching;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), method(startMatching / 1).");

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
				string typeName = "MODE_NUM";
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
				string typeName = "ENTITY_ID";
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
