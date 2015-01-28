// /***********************************************
//   MailBoxView.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/28
//   Description: 
//          单例异常
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/


public class SingletonException : System.Exception
{
		/// <summary>
		/// Initializes a new instance of the <see cref="SingletonException"/> class.
		/// </summary>
		/// <param name="msg">Message.</param>
		public SingletonException (string msg) : base(msg)
		{
		}
}
