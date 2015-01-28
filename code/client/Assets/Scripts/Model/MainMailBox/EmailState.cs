// /***********************************************
//   EmailState.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/27
//   Description: 
//          Module function description
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/


namespace OurWorld.Dota.Models.MailBox
{
		//邮件状态.
		public enum EmailState
		{
				/// <summary>
				/// The read.
				/// </summary>
				Read,
				/// <summary>
				/// The un read.
				/// </summary>
				UnRead,
		}
		//邮件类型.
		public enum EmailType
		{
				/// <summary>
				/// The system.
				/// </summary>
				System,
				/// <summary>
				/// The common.
				/// </summary>
				Common,
				/// <summary>
				/// The fighting.
				/// </summary>
				Fighting,
		}
}

