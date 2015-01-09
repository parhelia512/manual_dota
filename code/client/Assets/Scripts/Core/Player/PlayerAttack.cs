//
// /**************************************************************************
//
// PlayerAttack.cs
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

public class PlayerAttack : MonoBehaviour
{
		private int _skillID;
		private PlayerFSM _thisFSM;
		//private SpriteManualSequenceAction _manualSeq;

		/// <summary>
		/// Gets or sets the skill I.
		/// </summary>
		/// <value>The skill I.</value>
		public int SkillID {
				get{ return _skillID; }
				set{ _skillID = value; }
		}

		/// <summary>
		/// Gets or sets the this FS.
		/// </summary>
		/// <value>The this FS.</value>
		public PlayerFSM ThisFSM {
				get{ return _thisFSM; }
				set{ _thisFSM = value; }
		}
	
		/// <summary>
		/// Gets or sets the manual seq.
		/// </summary>
		/// <value>The manual seq.</value>
//		public SpriteManualSequenceAction ManualSeq {
//				get{ return _manualSeq; }
//				set{ _manualSeq = value; }
//		}

		/// <summary>
		/// Attack this instance.
		/// </summary>
		public void Attack ()
		{
				GameObject sprite_skill = new GameObject ("sprite");
				sprite_skill.transform.parent = ThisFSM.cntl.transform;

				//ManualSeq = sprite_skill.AddComponent<SpriteManualSequenceAction> ();
				//ManualSeq.cntl = ThisFSM.cntl;
				//ManualSeq.skill = FindSkillData();

				//ManualSeq.enable();
		}

//		private Schemas.SkillConfigSkillsLvConfig FindSkillData ()
//		{
//				return SkillConfigData.FindBySkillId(SkillID.ToString(), 1);
//		}
}
