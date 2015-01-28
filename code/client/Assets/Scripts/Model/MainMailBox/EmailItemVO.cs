// /***********************************************
//   EmailItemVO.cs
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
	public class EmailItemVO
	{
		public EmailState state;             //邮件状态.
		public EmailType type;               //邮件类型.
		public string sender;                //邮件发送者.
		public string time;                  //邮件发送时间.
		public string title;                 //邮件标题.
		public string content;               //邮件内容.
	}
}

