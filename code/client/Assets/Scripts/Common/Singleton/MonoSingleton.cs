// /***********************************************
//   MonoSingleton.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/27
//   Description: 
//          Generic MonoBehaviour singleton.
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/


using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
	
		private static T m_Instance = null;
    
		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static T instance {
				get {
						if (m_Instance == null) {
								m_Instance = GameObject.FindObjectOfType (typeof(T)) as T;
								if (m_Instance == null) {
										m_Instance = new GameObject ("Singleton of " + typeof(T).ToString (), typeof(T)).GetComponent<T> ();
										m_Instance.Init ();
								}
               
						}
						return m_Instance;
				}
		}

		private void Awake ()
		{
   
				if (m_Instance == null) {
						m_Instance = this as T;
				}
		}
 
		/// <summary>
		/// Init this instance.
		/// </summary>
		public virtual void Init ()
		{
		}

		private void OnApplicationQuit ()
		{
				m_Instance = null;
		}
}