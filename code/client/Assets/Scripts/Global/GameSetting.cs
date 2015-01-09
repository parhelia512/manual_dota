//
// /**************************************************************************
//
// GameSetting.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Date: 14-12-29
//
// Description:Provide  functions  to connect Oracle
//
// Copyright (c) 2014 xiaohong
//
// **************************************************************************/

using UnityEngine;
using System.Collections;

public static class GameSetting
{
	#region PlayerPrefs Constants
		private const string HAIR_COLOR = "Hair Color";
		private const string HAIR_MESH = "Hair Mesh";
		private const string NAME = "Player Name";
		private const string BASE_VALUE = " - BASE VALUE";
		private const string EXP_TO_LEVEL = " - EXP TO LEVEL";
		private const string CUR_VALUE = " - Cur Value";
		private const string CHARACTER_WIDTH = "Char Width";
		private const string CHARACTER_HEIGHT = "Char Height";
	#endregion

	#region Resource Paths
		/// <summary>
		/// The MELE e_ WEAPO n_ ICO n_ PAT.
		/// </summary>
		public const string MELEE_WEAPON_ICON_PATH = "Item/Icon/Weapon/Melee/";
		/// <summary>
		/// The MELE e_ WEAPO n_ MES h_ PAT.
		/// </summary>
		public const string MELEE_WEAPON_MESH_PATH = "Item/Mesh/Weapon/Melee/";
	#endregion

		/// <summary>
		/// The pc.
		/// </summary>
		public static PlayerCharacter pc;
		/// <summary>
		/// The level names.
		/// </summary>
		public static string[] levelNames = {
		"Main Menu",
		"Character Generation",
		"Character Customization",
		"Tutorial"
	};

		static GameSetting ()
		{
		}
}
