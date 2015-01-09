//
// /**************************************************************************
//
// SeclectTargetting.cs
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

public class SeclectTargetting : MonoBehaviour
{
		/// <summary>
		/// The targets.
		/// </summary>
		public List<Transform> targets;
		/// <summary>
		/// The seclected target.
		/// </summary>
		public Transform seclectedTarget;
		private Transform myTransform;
		// Use this for initialization
		void Start ()
		{
				targets = new List<Transform> ();
				seclectedTarget = null;
				myTransform = transform;

	
		}
	
		// Update is called once per frame
		void Update ()
		{
//				if (Input.GetKeyDown (KeyCode.Tab))
//						TargetEnemy ();
	
		}

	
		public void OnEnable() {
		Messenger.AddListener( MessengerEventType.TargetEnemy.ToString(), TargetEnemy );
		}
		
		public void OnDisable() {
		Messenger.RemoveListener( MessengerEventType.TargetEnemy.ToString(), TargetEnemy );
		}

		/// <summary>
		/// Adds all enemies.
		/// </summary>
		public void AddAllEnemies ()
		{
				GameObject[] go = GameObject.FindGameObjectsWithTag (GameTagManager.Enemy);

				foreach (GameObject enemy in go)
						AddTarget (enemy.transform);
		}

		/// <summary>
		/// Adds the target.
		/// </summary>
		/// <param name="enemy">Enemy.</param>
		public void AddTarget (Transform enemy)
		{
				targets.Add (enemy);
		}

		private void TargetEnemy ()
		{
				if (targets.Count == 0)
						AddAllEnemies ();
				if (targets.Count > 0) {
						if (seclectedTarget == null) {
								SortTargetsByDistance ();
								seclectedTarget = targets [0];
						} else {
								int index = targets.IndexOf (seclectedTarget);
								if (index < targets.Count - 1)
										index++;
								else
										index = 0;
								DeseclectedTarget ();
								seclectedTarget = targets [index];
						} 
						SeclectedTarget ();
				}
		}

		private void SeclectedTarget ()
		{
				seclectedTarget.renderer.material.color = Color.red;

		}

		private void DeseclectedTarget ()
		{
				seclectedTarget.renderer.material.color = Color.white;
				seclectedTarget = null;
		}

		private void SortTargetsByDistance ()
		{
				targets.Sort (delegate(Transform enemy1, Transform enemy2) {
						return Vector3.Distance (enemy1.position, myTransform.position).CompareTo (Vector3.Distance (enemy2.position, myTransform.position));
				});
		}
}
