//
// /**************************************************************************
//
// PlayerFSM.cs
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
using System.Collections.Generic;

public class PlayerFSM : FSM
{
		/// <summary>
		/// The cntl.
		/// </summary>
		public PlayerController cntl;
		/// <summary>
		/// The last name of the state.
		/// </summary>
		public string lastStateName;
		/// <summary>
		/// The name of the curr state.
		/// </summary>
		public string currStateName;
	
		/// <summary>
		/// Start the specified cntl.
		/// </summary>
		/// <param name="cntl">Cntl.</param>
		public virtual void start (PlayerController cntl)
		{
				this.cntl = cntl;
		}
	
		/// <summary>
		/// Get the specified name.
		/// </summary>
		/// <param name="name">Name.</param>
		public FSMState get (string name)
		{
				if (!states.ContainsKey (name)) {
						if (name == PlayerFSMStandState.STATE_NAME)
								states.Add (PlayerFSMStandState.STATE_NAME, cntl.gameObject.AddComponent<PlayerFSMStandState> ());
				}
				return states [name];
		}

		/// <summary>
		/// Change the specified name.
		/// </summary>
		/// <param name="name">Name.</param>
		public override void change (string name)
		{
				if (lastStateName != name) {
						lastStateName = currStateName;
						currStateName = name;

						if (currentState != null) {
								currentState.exit (this);
								((PlayerFSMState)currentState).enabled = false;
						}
						currentState = get (name);
						((PlayerFSMState)currentState).enabled = true;
						currentState.enter (this);
				} else {
						currentState = get (name);
						currentState.exit (this);
						currentState.enter (this);	
				}
		}

		/// <summary>
		/// Stop this instance.
		/// </summary>
		public override void stop ()
		{
				base.stop ();
		
				PlayerFSMState[] cur_states = cntl.transform.GetComponents<PlayerFSMState> ();
				for (int i=0; i<cur_states.Length; i++)
						MonoBehaviour.Destroy (cur_states [i]);
		
				states.Clear ();
		}
}
	
