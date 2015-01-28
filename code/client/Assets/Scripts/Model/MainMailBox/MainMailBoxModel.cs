// /***********************************************
//   MainMailBoxModel.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/27
//   Description: 
//          首页邮箱业务模型
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/


namespace OurWorld.Dota.Models.MailBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// 首页邮箱业务模型
    /// </summary>
    public class MainMailBoxModel : Singleton<MainMailBoxModel>
    {
		private MainMailBoxVO _myMainMailBoxVO;

        /// <summary>
        /// 获取商城中所有商品信息。
        /// </summary>
        public IEnumerable<EmailItemVO> EmailsItems
        {
			get { return _myMainMailBoxVO.emails; }
        }

        /// <summary>
        /// 获取商店状态信息
        /// </summary>
		public MainMailBoxVO GetMainMailBoxVO
		{
			get { return _myMainMailBoxVO; }
		}
		
		/// <summary>
        /// 进入商店向服务器请求当前出售的各个商品的业务逻辑
        /// </summary>
        /// <param name="dataobj"></param>
        public void GetMailBoxData(object dataobj = null)
        {
			_myMainMailBoxVO = new MainMailBoxVO();

            if (dataobj == null)        //TODO:由于目前没有后端，且我也还暂时来不及写数据解析，且也还没有智勇双全又有空的程序哥哥来写数据解析，所以目前伪数据暂时硬编码
            {
                //获取商品列表信息
                int length = 3;       
                Init(length);

				_myMainMailBoxVO.nextTimeRefresh = 21;        //TODO:后端给个时间戳之类的，本地TimeSpan转换
            }            
        }

        /// <summary>
        /// 点击刷新按钮，并点击“好的”按钮后，向服务器请求刷新商品的业务逻辑
        /// </summary>
        /// <param name="dataobj"></param>
        public void RefreshMailBoxData(object dataobj = null)
        {
			if (_myMainMailBoxVO != null)
            {
                int length = 3;
                Refresh(length);
            }
        }


        private void Init(int length)
        {
            if (length != 3)
            {
               throw new Exception("GoodsCount is not 6!!!");
            }

			EmailItemVO[] emails = new EmailItemVO[length];
			for (int i = 0; i < length; i++)
			{
				emails[i] = new EmailItemVO();
			}
			#region 伪数据且硬编码。理由：缺策划配置表、后端数据逻辑、外加么有时间写数据解析<(￣3￣)> .

			emails[0].sender = "XiaoMing";
			emails[0].state = EmailState.UnRead;
			emails[0].type = EmailType.Common;
			emails[0].title = "TestEmail1";
			emails[0].time = "2015-01-21";
			emails[0].content = "收集80个灵魂石，可以召唤英雄术士。同时也是术士进化的必备材料。";

			emails[1].sender = "灵魂石（术士";
			emails[1].state = EmailState.UnRead;
			emails[1].type = EmailType.Fighting;
			emails[1].title = "TestEmail2";
			emails[1].time = "2015-11-21";
			emails[1].content = "短？短怎么了！短怎么了！！！";

			emails[2].sender = "system";
			emails[2].state = EmailState.UnRead;
			emails[2].type = EmailType.System;
			emails[2].title = "TestEmail3";
			emails[2].time = "2014-01-21";
			emails[2].content = "收集80个灵魂石，可以召唤英雄术士。";

            #endregion

			_myMainMailBoxVO.emails = emails;
        }

        private void Refresh(int length)
        {
            if (length != 3)
            {
                throw new Exception("GoodsCount is not 6!!!");
            }
			EmailItemVO[] emails = new EmailItemVO[length];
			for (int i = 0; i < length; i++)
			{
				emails[i] = new EmailItemVO();
			}

			#region 伪数据且硬编码。理由：缺策划配置表、后端数据逻辑、外加么有时间写数据解析<(￣3￣)> .
			
			emails[0].sender = "XiaoMing";
			emails[0].state = EmailState.UnRead;
			emails[0].type = EmailType.Common;
			emails[0].title = "TestEmail1";
			emails[0].time = "2015-01-21";
			emails[0].content = "收集80个灵魂石，可以召唤英雄术士。同时也是术士进化的必备材料。";
			
			emails[1].sender = "灵魂石（术士";
			emails[1].state = EmailState.UnRead;
			emails[1].type = EmailType.Fighting;
			emails[1].title = "TestEmail2";
			emails[1].time = "2015-11-21";
			emails[1].content = "短？短怎么了！短怎么了！！！";
			
			emails[2].sender = "system";
			emails[2].state = EmailState.UnRead;
			emails[2].type = EmailType.System;
			emails[2].title = "TestEmail3";
			emails[2].time = "2014-01-21";
			emails[2].content = "收集80个灵魂石，可以召唤英雄术士。";
			
			#endregion
			
			_myMainMailBoxVO.emails = emails;
		}
	}
}


