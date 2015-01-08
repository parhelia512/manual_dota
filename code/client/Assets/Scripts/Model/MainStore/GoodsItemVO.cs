//author : Declan (DC)
//date : 2015/1/3

namespace OurWorld.Dota.Models.Stores
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class GoodsItemVO
    {
        public string name;                         //商品名字
        public string description;                  //商品描述
        public string extraDescription;             //商品额外小描述
        public GoodsType goodsType;                 //商品类型
        public GoodsCostType goodsCostType;         //商品单价类型
        public int totalcost;                       //商品总价
        public int cout;                            //商品个数
        public int own;                             //拥有件数
        public int id;                              //商品id
        public int quality;                         //商品品质，和后端约定好0到4，分别对应白、绿、篮、紫、金（橙）

        public int chiptype;                        //如果是碎片的话，装备碎片类型为1，卷轴碎片类型为2，否则为0（这个一般前端和后端约定一下就好了，当然要文档备注好）
    }
}


