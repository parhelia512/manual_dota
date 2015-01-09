//
// /**************************************************************************
//
// AnimatorHashIDs.cs
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

public class AnimatorHashIDs : MonoBehaviour
{
		public int baseLayer = 0;
		public int attackLayer = 1;
		public int hurtLayer = 2;
		public int movementState;
		public int speedFloat;
		// Use this for initialization
		void Start ()
		{
				movementState = Animator.StringToHash ("Base Layer.movement");

				speedFloat = Animator.StringToHash ("Speed");
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
