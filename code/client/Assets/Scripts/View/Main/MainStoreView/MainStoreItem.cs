using System;
using OurWorld.Dota.Models.Stores;
using OurWorld.Dota.Models.VO;
using UnityEngine;
using UnityEngine.UI;

public class MainStoreItem : MonoBehaviour
{
    public GameObject SoldOutImageObj;      //售罄

    public GoodsItemVO mVO;                 //商品数据信息

    public GoodsCard goodsCard;             //物品图标信息

    public Text Name;                       //商品名称
    public Text Cost;                       //价格

    public Image CostTypeImage;                  //价格类型

    private Transform _mTrans;
    private Button _mBtn;

    /// <summary>
    /// 显示更新具体商品
    /// </summary>
    public void ItemUpdate()
    {
        Init();
        //goodsCard.UpdateView(mVO);
    }

    private void Init()
    {
        if(SoldOutImageObj.activeInHierarchy)
            SoldOutImageObj.SetActive(false);       //隐藏售罄贴图

        _mTrans = this.transform;
        _mBtn = _mTrans.GetComponent<Button>();

        _mBtn.onClick.AddListener(OnBtnClick);

        if (mVO == null)
        {
            Debug.LogWarning("the GoodsItemVO is null!!!");
            return;
        }
        Name.text = mVO.name;
        Cost.text = mVO.totalcost.ToString();

        //todo:后续统一从资源加载控制脚本获取
        string pathCostType = pathkind(mVO.goodsCostType);
        CostTypeImage.overrideSprite = Resources.Load(pathCostType, typeof(Sprite)) as Sprite;

        updateGoodsCard();
    }

    /// <summary>
    /// 更新商品图标
    /// </summary>
    private void updateGoodsCard()
    {
        Convert();
    }

    private void OnBtnClick()
    {
        MainStoreController.Instance.View.MyGoodsDetail.currSelectedVO = mVO;
        MainStoreController.Instance.ShowGoodsDetail();
        MainStoreController.Instance.View.MyGoodsDetail.Buy += onBuy;
    }

    private void onBuy(object sender, EventArgs e)
    {
        _mBtn.interactable = false;         //不响应点击事件
        SoldOutImageObj.SetActive(true);    //显示售罄贴图

        MainStoreController.Instance.View.MyGoodsDetail.Buy -= onBuy;
    }

    /// <summary>
    /// 寻找路径        //todo:后续统一从资源加载控制脚本获取
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private string pathkind(GoodsCostType type)
    {
        string path = string.Empty;
        switch (type)
        {
            case GoodsCostType.Coin: path = "ChangeIcon/CostIcon/shop_gold_ico"; break;
            case GoodsCostType.Crystal: path = "ChangeIcon/CostIcon/shop_token_ico"; break;
            case GoodsCostType.Action: path = "ChangeIcon/CostIcon/task_vit_icon_"; break;
            case GoodsCostType.FighterCoin: path = "ChangeIcon/CostIcon/money_arenatoken_smal"; break;
            case GoodsCostType.DragonCoin: path = "ChangeIcon/CostIcon/money_dragonscale_smal"; break;
            case GoodsCostType.BrothersCoin: path = "ChangeIcon/CostIcon/money_guildtoken_smal"; break;
        }
        return path;
    }


    private void Convert()
    {
        //todo:暂时写法，后续会对数据读取解析进行不断优化
        switch (mVO.goodsType)
        {
            case GoodsType.Equipment:
                var evo = new EquipmentVO();
                evo.id = mVO.id;
                evo.own = mVO.own;
                evo.price = mVO.totalcost;
                evo.quality = mVO.quality;
                evo.name = mVO.name;
                evo.detail = mVO.description;
                evo.extradetail = mVO.extraDescription;
                goodsCard.updateEquipImage(evo);
                break;

            case GoodsType.Medicine:
                var mvo = new MedicineVO();
                mvo.id = mVO.id;
                mvo.own = mVO.own;
                mvo.price = mVO.totalcost;
                mvo.quality = mVO.quality;
                mvo.name = mVO.name;
                mvo.detail = mVO.description;
                mvo.extradetail = mVO.extraDescription;
                goodsCard.updateMedicineImage(mvo);
                break;

            case GoodsType.Scroll:
                var svo = new ScrollVO();
                svo.id = mVO.id;
                svo.own = mVO.own;
                svo.price = mVO.totalcost;
                svo.quality = mVO.quality;
                svo.name = mVO.name;
                svo.detail = mVO.description;
                svo.extradetail = mVO.extraDescription;
                goodsCard.updateScrollImage(svo);
                break;

            case GoodsType.SoulStone:
                var ssvo = new SoulStoneVO();
                ssvo.id = mVO.id;
                ssvo.own = mVO.own;
                ssvo.price = mVO.totalcost;
                ssvo.quality = mVO.quality;
                ssvo.name = mVO.name;
                ssvo.detail = mVO.description;
                ssvo.extradetail = mVO.extraDescription;
                goodsCard.updateSoulStoneImage(ssvo);
                break; 

            case GoodsType.Chip:
                var cvo = new ChipVO();
                cvo.type = mVO.chiptype;
                cvo.id = mVO.id;
                cvo.own = mVO.own;
                cvo.price = mVO.totalcost;
                cvo.quality = mVO.quality;
                cvo.name = mVO.name;
                cvo.detail = mVO.description;
                cvo.extradetail = mVO.extraDescription;
                goodsCard.updateChipImage(cvo);
                break; 
        }
    }

    //private IGoodsVO Convert()
    //{
    //    switch (mVO.goodsType)
    //    {
    //        case GoodsType.Equipment:
    //            return new 
    //            break;
    //        case GoodsType.Medicine:
    //            break;
    //        case GoodsType.Scroll:
    //            break;
    //        case GoodsType.SoulStone:
    //            break;
    //        case GoodsType.Chip:
    //            break;
    //    }
    //}

    //private  GoodsKinds 
}
