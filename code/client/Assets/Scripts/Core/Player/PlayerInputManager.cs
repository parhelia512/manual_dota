//
// /**************************************************************************
//
// PlayerInputManager.cs
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

public class PlayerInputManager : MonoBehaviour
{
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Tab))
						SendMessage (MessengerEventType.TargetEnemy.ToString ());
		}
}
