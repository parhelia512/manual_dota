// /***********************************************
//   Singleton.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/27
//   Description: 
//          Generic C# singleton.
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/

using UnityEngine;

#region Singleton<> first version
//public abstract class Singleton<T> where T : class, new() {
//
//    public static readonly T Instance = new T();
//
//    public virtual void Init(){}
// 
//}
#endregion

#region Singleton<> second version
public abstract class Singleton<T> where T : class, new() {

	protected static T m_Instance = new T();
	
	protected Singleton()
	{
		if(null != m_Instance)
			throw new SingletonException("This " + (typeof(T)).ToString() + " Singleton Instance is not null !!!");
	}
	
	public static T Instance
	{
		get{ return m_Instance; }
	}
	
	public virtual void Init(){}
	
}
#endregion

#region Test Singleton<>

/*
//Use Singleton

public class TestSingleton1 : Singleton<TestSingleton1>
{
	public override void Init()
	{
		Debug.Log ("---------> TestSingleton1");
	}
}

public class TestSingleton2 : Singleton<TestSingleton2>
{

}

//////////////////////////////////////////////////////////
// Test Singleton
		TestSingleton1 TS1 = new TestSingleton1 ();

		TS1.Init ();

		TestSingleton1.Instance.Init ();

		TestSingleton2.Instance.Init ();

/////////////////////////////////////////////////////////
// OutPut

Singleton Instance is not null !!!
---------> TestSingleton1
---------> TestSingleton1
---------> Singleton<>
*/

#endregion