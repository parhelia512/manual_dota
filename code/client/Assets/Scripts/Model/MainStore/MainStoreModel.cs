//author : Declan (DC)
//date : 2015/1/3

namespace OurWorld.Dota.Models.Stores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// 首页商人业务模型
    /// </summary>
    public class MainStoreModel  
    {
        /// <summary>
        /// 获取商城业务模型唯一实例
        /// </summary>
        public static MainStoreModel Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 获取商城中所有商品信息。
        /// </summary>
        public IEnumerable<GoodsItemVO> GoodsItems
        {
            get { return _myMainStoreVo.goods; }
        }

        /// <summary>
        /// 获取商店状态信息
        /// </summary>
        public MainStoreVO GetMainSoreVO
        {
            get { return _myMainStoreVo; }
        }

        public void GetMainStoreDate(object dataobj = null)
        {
            _myMainStoreVo = new MainStoreVO();

            if (dataobj == null)        //TODO:由于目前没有后端，且我也还暂时来不及写数据解析，且也还没有智勇双全又有空的程序哥哥来写数据解析，所以目前伪数据暂时硬编码
            {
                //获取商品列表信息
                int length = 6;       
                Init(length);

                _myMainStoreVo.nextTimeRefresh = 21;        //TODO:后端给个时间戳之类的，本地TimeSpan转换
            }            
        }
        private void Init(int length)
        {
            if (length != 6)
            {
               throw new Exception("GoodsCount is not 6!!!");
            }

            GoodsItemVO[] goods = new GoodsItemVO[length];
            for (int i = 0; i < length; i++)
            {
                goods[i] = new GoodsItemVO();
            }

            #region 伪数据且硬编码。理由：缺策划配置表、后端数据逻辑、外加么有时间写数据解析<(￣3￣)> 
           
            goods[0].name = "灵魂石（术士）";
            goods[0].description = "收集80个灵魂石，可以召唤英雄术士。同时也是术士进化的必备材料。";
            goods[0].extraDescription = string.Empty;
            goods[0].goodsType = GoodsType.SoulStone;
            goods[0].goodsCostType = GoodsCostType.Crystal;
            goods[0].totalcost = 40;
            goods[0].cout = 3;
            goods[0].own = 0;
            goods[0].id = 10;               //没有英雄头像对应的id，所以这个数字是随便填的
            goods[0].quality = 2;           //商品品质，和后端约定好0到4，分别对应白、绿、篮、紫、金（橙）
            goods[0].chiptype = 0;

            goods[1].name = "短棍 x 3";
            goods[1].description = "物理攻击力+10\r\n物理暴击+5";
            goods[1].extraDescription = "短？短怎么了！短怎么了！！！";
            goods[1].goodsType = GoodsType.Equipment;
            goods[1].goodsCostType = GoodsCostType.Coin;
            goods[1].totalcost = 2700;
            goods[1].cout = 3;
            goods[1].own = 0;
            goods[1].id = 115;
            goods[1].quality = 1;           //商品品质，和后端约定好0到4，分别对应白、绿、篮、紫、金（橙） 
            goods[1].chiptype = 0;

            goods[2].name = "经验药水 x 5";
            goods[2].description = "吃了它可以获得60点英雄经验值。";
            goods[2].extraDescription = "每瓶药水中都困着一个鲜活的小萝莉";
            goods[2].goodsType = GoodsType.Medicine;
            goods[2].goodsCostType = GoodsCostType.Coin;
            goods[2].totalcost = 5000;
            goods[2].cout = 5;
            goods[2].own = 617;
            goods[2].id = 501;
            goods[2].quality = 0;           //商品品质，和后端约定好0到4，分别对应白、绿、篮、紫、金（橙）
            goods[2].chiptype = 0;

            goods[3].name = "攻击利爪";
            goods[3].description = "物理攻击力+9";
            goods[3].extraDescription = "曾经有位鬼魅般的刺客佩带过它，后来他在挠痒痒的时候把自己杀死了";
            goods[3].goodsType = GoodsType.Equipment;
            goods[3].goodsCostType = GoodsCostType.Coin;
            goods[3].totalcost = 450;
            goods[3].cout = 1;
            goods[3].own = 0;
            goods[3].id = 113;
            goods[3].quality = 0;           //商品品质，和后端约定好0到4，分别对应白、绿、篮、紫、金（橙）
            goods[3].chiptype = 0;

            goods[4].name = "长笛卷轴（碎片）";
            goods[4].description = "收集20个碎片，可以合成长笛卷轴。\r\n\r\n合成需要碎片：96/20";
            goods[4].extraDescription = string.Empty;
            goods[4].goodsType = GoodsType.Chip;
            goods[4].goodsCostType = GoodsCostType.Coin;
            goods[4].totalcost = 900;
            goods[4].cout = 1;
            goods[4].own = 0;
            goods[4].id = 233;
            goods[4].quality = 3;           //商品品质，和后端约定好0到4，分别对应白、绿、篮、紫、金（橙）
            goods[4].chiptype = 2;

            goods[5].name = "灵魂石（宙斯）";
            goods[5].description = "收集10个灵魂石，可以召唤英雄宙斯。同时也是宙斯进化的必备材料。";
            goods[5].extraDescription = string.Empty;
            goods[5].goodsType = GoodsType.SoulStone;
            goods[5].goodsCostType = GoodsCostType.Coin;
            goods[5].totalcost = 20000;
            goods[5].cout = 1;
            goods[5].own = 0;
            goods[5].id = 3;              //没有英雄头像对应的id，所以这个数字是随便填的 
            goods[5].quality = 2;           //商品品质，和后端约定好0到4，分别对应白、绿、篮、紫、金（橙）
            goods[5].chiptype = 0;
            
            #endregion

            _myMainStoreVo.goods = goods;
        }

        private static readonly MainStoreModel _instance = new MainStoreModel();
        private MainStoreVO _myMainStoreVo;
    }
}


