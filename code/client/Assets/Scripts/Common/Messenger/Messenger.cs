//
// /**************************************************************************
//
// Messenger.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Date: 14-12-24
//
// Description: 该事件系统来改自于 Hack_&_Slash 的视频教程 Hack_&_Slash_RPG_A_Unity3D_Game_Engine
//				该事件系统支持通用的 string Key 和 MessengerEventType Key
//				该事件系统支持，无参数，1个参数，2个参数，3个参数。更多参数需要再次扩展
//				该事件系统不支持参数返回，如需要使用需要扩展
//				该事件系统有BUG需要注意使用，此处不详细描述
//
// Copyright (c) 2014 xiaohong
//
// **************************************************************************/

// Messenger.cs v1.0 by Magnus Wolffelt, magnus.wolffelt@gmail.com

//
// Inspired by and based on Rod Hyde's Messenger:
// http://www.unifycommunity.com/wiki/index.php?title=CSharpMessenger
//
// This is a C# messenger (notification center). It uses delegates
// and generics to provide type-checked messaging between event producers and
// event consumers, without the need for producers or consumers to be aware of
// each other. The major improvement from Hyde's implementation is that
// there is more extensive error detection, preventing silent bugs.
//
// Usage example:
// Messenger<float>.AddListener("myEvent", MyEventHandler);
// ...
// Messenger<float>.Broadcast("myEvent", 1.0f);


using System;
using System.Collections.Generic;

public enum MessengerMode
{
		/// <summary>
		/// The DON t_ REQUIR e_ LISTENE.
		/// </summary>
		DONT_REQUIRE_LISTENER,
		/// <summary>
		/// The REQUIR e_ LISTENE.
		/// </summary>
		REQUIRE_LISTENER,
}

static internal class MessengerInternal
{
		/// <summary>
		/// The event table.
		/// </summary>
		static public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate> ();
		/// <summary>
		/// The DEFAUL t_ MOD.
		/// </summary>
		static public readonly MessengerMode DEFAULT_MODE = MessengerMode.REQUIRE_LISTENER;

	#region Messenger Internal Functions
		/// <summary>
		/// Raises the listener adding event.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="listenerBeingAdded">Listener being added.</param>
		static public void OnListenerAdding (string eventType, Delegate listenerBeingAdded)
		{
				if (!eventTable.ContainsKey (eventType)) {
						eventTable.Add (eventType, null);
				}

				Delegate d = eventTable [eventType];
				if (d != null && d.GetType () != listenerBeingAdded.GetType ()) {
						throw new ListenerException (string.Format ("Attempting to add listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being added has type {2}", eventType, d.GetType ().Name, listenerBeingAdded.GetType ().Name));
				}
		}

		/// <summary>
		/// Raises the listener removing event.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="listenerBeingRemoved">Listener being removed.</param>
		static public void OnListenerRemoving (string eventType, Delegate listenerBeingRemoved)
		{
				if (eventTable.ContainsKey (eventType)) {
						Delegate d = eventTable [eventType];

						if (d == null) {
								throw new ListenerException (string.Format ("Attempting to remove listener with for event type {0} but current listener is null.", eventType));
						} else if (d.GetType () != listenerBeingRemoved.GetType ()) {
								throw new ListenerException (string.Format ("Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}", eventType, d.GetType ().Name, listenerBeingRemoved.GetType ().Name));
						}
				} else {
						throw new ListenerException (string.Format ("Attempting to remove listener for type {0} but Messenger doesn't know about this event type.", eventType));
				}
		}

		/// <summary>
		/// Raises the listener removed event.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		static public void OnListenerRemoved (string eventType)
		{
				if (eventTable [eventType] == null) {
						eventTable.Remove (eventType);
				}
		}

		/// <summary>
		/// Raises the broadcasting event.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="mode">Mode.</param>
		static public void OnBroadcasting (string eventType, MessengerMode mode)
		{
				if (mode == MessengerMode.REQUIRE_LISTENER && !eventTable.ContainsKey (eventType)) {
						throw new MessengerInternal.BroadcastException (string.Format ("Broadcasting message {0} but no listener found.", eventType));
				}
		}

	#endregion

	#region Messenger Broadcast Exception

		/// <summary>
		/// Creates the broadcast signature exception.
		/// </summary>
		/// <returns>The broadcast signature exception.</returns>
		/// <param name="eventType">Event type.</param>
		static public BroadcastException CreateBroadcastSignatureException (string eventType)
		{
				return new BroadcastException (string.Format ("Broadcasting message {0} but listeners have a different signature than the broadcaster.", eventType));
		}

		public class BroadcastException : Exception
		{
				public BroadcastException (string msg)
            : base(msg)
				{
				}
		}

		public class ListenerException : Exception
		{
				public ListenerException (string msg)
            : base(msg)
				{
				}
		}
	#endregion
}


// No parameters
static public class Messenger
{
		private static Dictionary<string, Delegate> eventTable = MessengerInternal.eventTable;

	#region 使用 string 事件类型，通用事件类型
		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void AddListener (string eventType, Callback handler)
		{
				MessengerInternal.OnListenerAdding (eventType, handler);
				eventTable [eventType] = (Callback)eventTable [eventType] + handler;
		}

		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void RemoveListener (string eventType, Callback handler)
		{
				MessengerInternal.OnListenerRemoving (eventType, handler);   
				eventTable [eventType] = (Callback)eventTable [eventType] - handler;
				MessengerInternal.OnListenerRemoved (eventType);
		}

		/// <summary>
		/// Broadcast the specified eventType.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		static public void Broadcast (string eventType)
		{
				Broadcast (eventType, MessengerInternal.DEFAULT_MODE);
		}

		/// <summary>
		/// Broadcast the specified eventType and mode.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="mode">Mode.</param>
		static public void Broadcast (string eventType, MessengerMode mode)
		{
				MessengerInternal.OnBroadcasting (eventType, mode);
				Delegate d;
				if (eventTable.TryGetValue (eventType, out d)) {
						Callback callback = d as Callback;
						if (callback != null) {
								callback ();
						} else {
								throw MessengerInternal.CreateBroadcastSignatureException (eventType);
						}
				}
		}
	#endregion

	#region 使用统一事件类型，方便统一管理

		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void AddListener (MessengerEventType eventType, Callback handler)
		{
				AddListener (eventType.ToString (), handler);
		}

		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void RemoveListener (MessengerEventType eventType, Callback handler)
		{
				RemoveListener (eventType.ToString (), handler);
		}

		/// <summary>
		/// Broadcast the specified eventType.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		static public void Broadcast (MessengerEventType eventType)
		{
				Broadcast (eventType.ToString (), MessengerInternal.DEFAULT_MODE);
		}

		/// <summary>
		/// Broadcast the specified eventType and mode.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="mode">Mode.</param>
		static public void Broadcast (MessengerEventType eventType, MessengerMode mode)
		{
				Broadcast (eventType.ToString (), mode);
		}

		#endregion
}

// One parameter
static public class Messenger<T>
{
		private static Dictionary<string, Delegate> eventTable = MessengerInternal.eventTable;

	#region 使用 string 事件类型，通用事件类型
		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void AddListener (string eventType, Callback<T> handler)
		{
				MessengerInternal.OnListenerAdding (eventType, handler);
				eventTable [eventType] = (Callback<T>)eventTable [eventType] + handler;
		}

		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void RemoveListener (string eventType, Callback<T> handler)
		{
				MessengerInternal.OnListenerRemoving (eventType, handler);
				eventTable [eventType] = (Callback<T>)eventTable [eventType] - handler;
				MessengerInternal.OnListenerRemoved (eventType);
		}

		/// <summary>
		/// Broadcast the specified eventType and arg1.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		static public void Broadcast (string eventType, T arg1)
		{
				Broadcast (eventType, arg1, MessengerInternal.DEFAULT_MODE);
		}

		/// <summary>
		/// Broadcast the specified eventType, arg1 and mode.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="mode">Mode.</param>
		static public void Broadcast (string eventType, T arg1, MessengerMode mode)
		{
				MessengerInternal.OnBroadcasting (eventType, mode);
				Delegate d;
				if (eventTable.TryGetValue (eventType, out d)) {
						Callback<T> callback = d as Callback<T>;
						if (callback != null) {
								callback (arg1);
						} else {
								throw MessengerInternal.CreateBroadcastSignatureException (eventType);
						}
				}
		}
	#endregion
	
	#region 使用统一事件类型，方便统一管理
	
		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void AddListener (MessengerEventType eventType, Callback<T> handler)
		{
				AddListener (eventType.ToString (), handler);
		}
	
		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void RemoveListener (MessengerEventType eventType, Callback<T> handler)
		{
				RemoveListener (eventType.ToString (), handler);
		}
	
		/// <summary>
		/// Broadcast the specified eventType and arg1.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		static public void Broadcast (MessengerEventType eventType, T arg1)
		{
				Broadcast (eventType.ToString (), arg1, MessengerInternal.DEFAULT_MODE);
		}
	
		/// <summary>
		/// Broadcast the specified eventType, arg1 and mode.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="mode">Mode.</param>
		static public void Broadcast (MessengerEventType eventType, T arg1, MessengerMode mode)
		{
				Broadcast (eventType.ToString (), arg1, mode);
		}
	
	#endregion
}


// Two parameters
static public class Messenger<T, U>
{
		private static Dictionary<string, Delegate> eventTable = MessengerInternal.eventTable;

	#region 使用 string 事件类型，通用事件类型
		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void AddListener (string eventType, Callback<T, U> handler)
		{
				MessengerInternal.OnListenerAdding (eventType, handler);
				eventTable [eventType] = (Callback<T, U>)eventTable [eventType] + handler;
		}

		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void RemoveListener (string eventType, Callback<T, U> handler)
		{
				MessengerInternal.OnListenerRemoving (eventType, handler);
				eventTable [eventType] = (Callback<T, U>)eventTable [eventType] - handler;
				MessengerInternal.OnListenerRemoved (eventType);
		}

		/// <summary>
		/// Broadcast the specified eventType, arg1 and arg2.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		static public void Broadcast (string eventType, T arg1, U arg2)
		{
				Broadcast (eventType, arg1, arg2, MessengerInternal.DEFAULT_MODE);
		}

		/// <summary>
		/// Broadcast the specified eventType, arg1, arg2 and mode.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		/// <param name="mode">Mode.</param>
		static public void Broadcast (string eventType, T arg1, U arg2, MessengerMode mode)
		{
				MessengerInternal.OnBroadcasting (eventType, mode);
				Delegate d;
				if (eventTable.TryGetValue (eventType, out d)) {
						Callback<T, U> callback = d as Callback<T, U>;
						if (callback != null) {
								callback (arg1, arg2);
						} else {
								throw MessengerInternal.CreateBroadcastSignatureException (eventType);
						}
				}
		}
	#endregion

	
	#region 使用统一事件类型，方便统一管理
	
		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void AddListener (MessengerEventType eventType, Callback<T, U> handler)
		{
				AddListener (eventType.ToString (), handler);
		}
	
		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void RemoveListener (MessengerEventType eventType, Callback<T, U> handler)
		{
				RemoveListener (eventType.ToString (), handler);
		}
	
		/// <summary>
		/// Broadcast the specified eventType, arg1 and arg2.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		static public void Broadcast (MessengerEventType eventType, T arg1, U arg2)
		{
				Broadcast (eventType.ToString (), arg1, arg2, MessengerInternal.DEFAULT_MODE);
		}
	
		/// <summary>
		/// Broadcast the specified eventType, arg1, arg2 and mode.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		/// <param name="mode">Mode.</param>
		static public void Broadcast (MessengerEventType eventType, T arg1, U arg2, MessengerMode mode)
		{
				Broadcast (eventType.ToString (), arg1, arg2, mode);
		}
	
	#endregion
}


// Three parameters
static public class Messenger<T, U, V>
{
		private static Dictionary<string, Delegate> eventTable = MessengerInternal.eventTable;

	#region 使用 string 事件类型，通用事件类型
		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void AddListener (string eventType, Callback<T, U, V> handler)
		{
				MessengerInternal.OnListenerAdding (eventType, handler);
				eventTable [eventType] = (Callback<T, U, V>)eventTable [eventType] + handler;
		}

		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void RemoveListener (string eventType, Callback<T, U, V> handler)
		{
				MessengerInternal.OnListenerRemoving (eventType, handler);
				eventTable [eventType] = (Callback<T, U, V>)eventTable [eventType] - handler;
				MessengerInternal.OnListenerRemoved (eventType);
		}

		/// <summary>
		/// Broadcast the specified eventType, arg1, arg2 and arg3.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		/// <param name="arg3">Arg3.</param>
		static public void Broadcast (string eventType, T arg1, U arg2, V arg3)
		{
				Broadcast (eventType, arg1, arg2, arg3, MessengerInternal.DEFAULT_MODE);
		}

		/// <summary>
		/// Broadcast the specified eventType, arg1, arg2, arg3 and mode.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		/// <param name="arg3">Arg3.</param>
		/// <param name="mode">Mode.</param>
		static public void Broadcast (string eventType, T arg1, U arg2, V arg3, MessengerMode mode)
		{
				MessengerInternal.OnBroadcasting (eventType, mode);
				Delegate d;
				if (eventTable.TryGetValue (eventType, out d)) {
						Callback<T, U, V> callback = d as Callback<T, U, V>;
						if (callback != null) {
								callback (arg1, arg2, arg3);
						} else {
								throw MessengerInternal.CreateBroadcastSignatureException (eventType);
						}
				}
		}

	#endregion 
	
	#region 使用统一事件类型，方便统一管理
	
		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void AddListener (MessengerEventType eventType, Callback<T, U, V> handler)
		{
				AddListener (eventType.ToString (), handler);
		}
	
		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="handler">Handler.</param>
		static public void RemoveListener (MessengerEventType eventType, Callback<T, U, V> handler)
		{
				RemoveListener (eventType.ToString (), handler);
		}
	
		/// <summary>
		/// Broadcast the specified eventType, arg1, arg2 and arg3.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		/// <param name="arg3">Arg3.</param>
		static public void Broadcast (MessengerEventType eventType, T arg1, U arg2, V arg3)
		{
				Broadcast (eventType.ToString (), arg1, arg2, arg3, MessengerInternal.DEFAULT_MODE);
		}
	
		/// <summary>
		/// Broadcast the specified eventType, arg1, arg2, arg3 and mode.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		/// <param name="arg1">Arg1.</param>
		/// <param name="arg2">Arg2.</param>
		/// <param name="arg3">Arg3.</param>
		/// <param name="mode">Mode.</param>
		static public void Broadcast (MessengerEventType eventType, T arg1, U arg2, V arg3, MessengerMode mode)
		{
				Broadcast (eventType.ToString (), arg1, arg2, arg3, mode);
		}
	
	#endregion
}