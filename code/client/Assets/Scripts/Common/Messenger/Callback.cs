//
// /**************************************************************************
//
// Callback.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Date: 14-12-24
//
// Description: 自定义事件系统 Messenger 内使用的委托
//
// Copyright (c) 2014 xiaohong
//
// **************************************************************************/

// MessengerUnitTest.cs v1.0 by Magnus Wolffelt, magnus.wolffelt@gmail.com

//
// Delegates used in Messenger.cs.

public delegate void Callback ();

public delegate void Callback<T> (T arg1);

public delegate void Callback<T,U> (T arg1,U arg2);

public delegate void Callback<T,U,V> (T arg1,U arg2,V arg3);