//
// /**************************************************************************
//
// PlayerController.cs
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

public class PlayerController : BaseController
{   
		/// <summary>
		/// The instance.
		/// </summary>
		//public static PlayerController instance;
		/// <summary>
		/// The player_fsm.
		/// </summary>
		public PlayerFSM player_fsm;
		/// <summary>
		/// The player_characrer.
		/// </summary>
		public PlayerCharacter player_characrer;
		/// <summary>
		/// The player_health.
		/// </summary>
		public PlayerHealth player_health;
		/// <summary>
		/// The player_attack.
		/// </summary>
		public PlayerAttack player_attack;
		/// <summary>
		/// The player_ A.
		/// </summary>
		public PlayerAI player_AI;
		/// <summary>
		/// The seclect target.
		/// </summary>
		public SeclectTargetting seclectTarget;
		/// <summary>
		/// The animator.
		/// </summary>
		public Animator animator;
		/// <summary>
		/// The hash I ds.
		/// </summary>
		public AnimatorHashIDs hashIDs;


		// Use this for initialization
		void Start ()
		{
				//instance = this;
				Init ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void Init ()
		{
				//玩家属性
				player_characrer = GetComponent<PlayerCharacter> ();
				if (player_characrer == null)
						player_characrer = gameObject.AddComponent<PlayerCharacter> ();

				//玩家生命魔法 
				player_health = GetComponent<PlayerHealth> ();
				if (player_health == null)
						player_health = gameObject.AddComponent<PlayerHealth> ();
				player_health.deathDelegate = new Callback(Death);

				//玩家攻击受击
				player_attack = GetComponent<PlayerAttack> ();
				if (player_attack == null)
						player_attack = gameObject.AddComponent<PlayerAttack> ();

				//玩家AI
				player_AI = GetComponent<PlayerAI> ();
				if (player_AI == null)
						player_AI = gameObject.AddComponent<PlayerAI> ();
				player_AI.activeAI = false;

				//搜索敌人
				seclectTarget = GetComponent<SeclectTargetting> ();
				if (seclectTarget == null)
						seclectTarget = gameObject.AddComponent<SeclectTargetting> ();

				//动画管理器
				animator = GetComponent<Animator> ();
				if (animator == null)
						Debug.LogError ("PlayerController Init Error Animator is Null");

				//Animator HashIDs
				hashIDs = GetComponent<AnimatorHashIDs>();
				if(hashIDs = null)
					hashIDs = gameObject.AddComponent<AnimatorHashIDs>();

				//玩家状态机
				player_fsm = new PlayerFSM ();
				player_fsm.start (this);
				player_fsm.change (PlayerFSMStandState.STATE_NAME);
		}

		private void Death()
		{
				player_fsm.change(PlayerFSMStandState.STATE_NAME);
		}
}
