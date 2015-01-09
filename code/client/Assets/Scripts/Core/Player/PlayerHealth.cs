//
// /**************************************************************************
//
// PlayerHealth.cs
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

public class PlayerHealth : MonoBehaviour
{
		private int _curHp;
		private int _maxHp;
		private int _curMp;
		private int _maxMp;
		/// <summary>
		/// The death delegate.
		/// </summary>
		public Callback deathDelegate;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		/// <summary>
		/// Gets or sets the current hp.
		/// </summary>
		/// <value>The current hp.</value>
		public int CurHp {
				get{ return _curHp; }
				set {
						if (value > _maxHp)
								_curHp = _maxHp;
						if (value < 0) {
								_curHp = 0;
						}
				}
		}

		/// <summary>
		/// Gets or sets the max hp.
		/// </summary>
		/// <value>The max hp.</value>
		public int MaxHp {
				get{ return _maxHp; }
				set {
						if (0 >= value)
								_maxHp = 1;
						else
								_maxHp = value;
						UpdateCurrentHp (_maxHp);
				}
		}

		/// <summary>
		/// Gets or sets the current mp.
		/// </summary>
		/// <value>The current mp.</value>
		public int CurMp {
				get{ return _curMp; }
				set {
						if (value > _curMp)
								_curMp = _maxMp;
						if (value < 0) {
								_curMp = 0;
						}
				}
		}

		/// <summary>
		/// Gets or sets the max mp.
		/// </summary>
		/// <value>The max mp.</value>
		public int MaxMp {
				get{ return _maxMp; }
				set {
						if (0 >= value)
								_maxMp = 1;
						else
								_maxMp = value;
				}
		}

		/// <summary>
		/// Updates the current hp.
		/// </summary>
		/// <param name="hp">Hp.</param>
		public void UpdateCurrentHp (int hp)
		{
				CurHp += hp;
				if (CurHp <= 0)
						deathDelegate ();
		}

		/// <summary>
		/// Updates the current mp.
		/// </summary>
		/// <param name="mp">Mp.</param>
		public void UpdateCurrentMp (int mp)
		{
				CurMp += mp;
		}

}
