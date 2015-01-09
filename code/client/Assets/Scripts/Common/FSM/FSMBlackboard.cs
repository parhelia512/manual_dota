//
// /**************************************************************************
//
// FSMBlackboard.cs
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

public class FSMBlackboard
{
		protected Dictionary<string, object> values = new Dictionary<string, object> ();

		/// <summary>
		/// Add the specified key and param.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="param">Parameter.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		// public void add (string key, object param)
		public void add<T> (string key, T param)
		{
				if (values.ContainsKey (key))
						values [key] = param;
				else
						values.Add (key, param);
		}

		/// <summary>
		/// Remove the specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		public void remove (string key)
		{
				if (values.ContainsKey (key))
						values.Remove (key);
		}

		/// <summary>
		/// Removes all.
		/// </summary>
		public void removeAll ()
		{
				values.Clear ();
		}

		/// <summary>
		/// Get the specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T get<T> (string key)
		{
				if (values.ContainsKey (key))
						return (T)values [key];
				return default(T);
		}
}
