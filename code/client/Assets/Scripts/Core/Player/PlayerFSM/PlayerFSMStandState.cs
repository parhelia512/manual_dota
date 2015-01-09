//
// /**************************************************************************
//
// PlayerFSMStandState.cs
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

public class PlayerFSMStandState : PlayerFSMState
{
		/// <summary>
		/// The STAT e_ NAM.
		/// </summary>
		public static string STATE_NAME = "Stand";

		// Update is called once per frame
		void Update ()
		{
		}

		/// <summary>
		/// Enter the specified fsm.
		/// </summary>
		/// <param name="fsm">Fsm.</param>
		public override void enter (FSM fsm)
		{
				base.enter (fsm);

				if (this_fsm == null)
						return;
		
				//设置base layer（stand）层的权重为1
				this_fsm.cntl.animator.SetLayerWeight (0, 1);

		}

		/// <summary>
		/// Exit the specified fsm.
		/// </summary>
		/// <param name="fsm">Fsm.</param>
		public override void exit (FSM fsm)
		{
				base.exit (fsm);

		}
}

