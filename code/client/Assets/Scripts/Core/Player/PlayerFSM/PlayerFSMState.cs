//
// /**************************************************************************
//
// PlayerFSMState.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Date: 14-12-26
//
// Description:Provide  functions  to connect Oracle
//
// Copyright (c) 2014 xiaohong
//
// **************************************************************************/

using UnityEngine;
using System.Collections;

public class PlayerFSMState : FSMState
{
		/// <summary>
		/// The this_fsm.
		/// </summary>
		public PlayerFSM this_fsm = null;

		/// <summary>
		/// Enter the specified fsm.
		/// </summary>
		/// <param name="fsm">Fsm.</param>
		public override void enter (FSM fsm)
		{
				this_fsm = fsm as PlayerFSM; 
				//base.enter (fsm);
		}
}
