//
// /**************************************************************************
//
// FSM.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Date: 14-12-24
//
// Description:Provide  functions  to connect Oracle
//
// Copyright (c) 2014 xiaohong
//
// **************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FSMState : MonoBehaviour
{
		/// <summary>
		/// Enter the specified fsm.
		/// </summary>
		/// <param name="fsm">Fsm.</param>
		public virtual void enter (FSM fsm)
		{
		}

		/// <summary>
		/// Update the specified fsm.
		/// </summary>
		/// <param name="fsm">Fsm.</param>
		public virtual void update (FSM fsm)
		{
		}

		/// <summary>
		/// Exit the specified fsm.
		/// </summary>
		/// <param name="fsm">Fsm.</param>
		public virtual void exit (FSM fsm)
		{
		}
}

public class FSM
{
		/// <summary>
		/// The board.
		/// </summary>
		public FSMBlackboard board = new FSMBlackboard ();
		protected FSMState currentState = null;
		protected FSMState lastState = null;
		protected Dictionary<string, FSMState> states = new Dictionary<string, FSMState> ();
	
		/// <summary>
		/// Change the specified name.
		/// </summary>
		/// <param name="name">Name.</param>
		public virtual void change (string name)
		{
				if (states.ContainsKey (name)) {
						if (currentState != null)
								currentState.exit (this);
						currentState = states [name];
						currentState.enter (this);
				}
		}

		/// <summary>
		/// Current this instance.
		/// </summary>
		public virtual FSMState current ()
		{
				return currentState;
		}

		/// <summary>
		/// Get the specified name.
		/// </summary>
		/// <param name="name">Name.</param>
		public FSMState get (string name)
		{
				if (states.ContainsKey (name))
						return states [name];
				return null;
		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		public void update ()
		{
				if (currentState != null)
						currentState.update (this);
		}
	
		/// <summary>
		/// Stop this instance.
		/// </summary>
		public virtual void stop ()
		{
				if (currentState != null) {
						currentState.exit (this);
						currentState = null;
				}
		}
}
