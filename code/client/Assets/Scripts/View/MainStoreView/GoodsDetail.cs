using System;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;
using OurWorld.Dota.Models.Stores;
using OurWorld.Dota.Models.VO;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoodsDetail : MonoBehaviour
{
    private Transform mTrans;
    private GameObject mObj;

    public GoodsItemVO currSelectedVO;

    /// <summary>
    /// 当点击购买按钮后，详情关闭时触发此事件。
    /// </summary>
    public event EventHandler Buy;

    public Animator MyAnimator;
    public GoodsCard goodsCard;
    public Button CloseBtn;
    public Button SureBtn;
    public Text Name;
    public Text Own;
    public Text Detail1;
    public Text Detail2;
    public Image CostImage;
    public Text Cost;
    public Text CostCount;

    private Tweener temp;
    private TweenParms parms;
    
    public void Init()
    {
        if (mTrans == null)
            mTrans = this.transform;

        if (mObj == null)
            mObj = this.gameObject;

        if (mObj.activeInHierarchy)
            mObj.SetActive(false);

        Bind();
    }

    public void DetailShow()
    {
        Show();
        mObj.SetActive(true);
    }

    private void DetailClose()
    {
        temp.ApplyCallback(CallbackType.OnRewinded, MyComplete);
        temp.PlayBackwards();
        #region Legacy
        //MyAnimator.StartPlayback();
        //MyAnimator.GetCurrentAnimatorStateInfo().length;
        ////MyAnimator;

        //Debug.Log("the 1: " + MyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //MyAnimator.speed = -1;
        //MyAnimator.Play(0);

        //Debug.Log("the 2: " + MyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //mObj.SetActive(false);
        #endregion      
    }

    private void Show()
    {      
        GoodsItemVO vo = currSelectedVO;
        
        //todo:根据数据初始化整个详情
        SetName(vo.name);
        SetOwn(vo.own);
        SetDetails(vo.description,vo.extraDescription);
        SetCost(vo.totalcost,vo.cout,vo.goodsCostType);
        Convert();

        if (temp == null)
        {
            this.mTrans.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            HOTween.Init();
            parms = new TweenParms();
            parms.Prop("localScale", new Vector3(1f, 1f, 1f));
            parms.Ease(EaseType.EaseOutBack);
            parms.Delay(0.1f);
            parms.AutoKill(false);
            temp = HOTween.To(this.mTrans, 0.2f, parms);
            temp.intId = 1;
        }
        temp.PlayForward();
    }

    /// <summary>
    /// 动画回调
    /// </summary>
    private void MyComplete()
    {
        mObj.SetActive(false);
    }

    private void Bind()
    {
        CloseBtn.onClick.AddListener(OnCloseBtnClick);
        SureBtn.onClick.AddListener(OnBuyBtnClick);
    }

    /// <summary>
    /// 关闭详情按钮
    /// </summary>
    private void OnCloseBtnClick()
    {
        DetailClose();
        
        //todo: -=
        if (Buy != null)
            Buy = null;
    }

    /// <summary>
    /// 确定购买按钮
    /// </summary>
    private void OnBuyBtnClick()
    {
        if (Buy != null)
            Buy(this, EventArgs.Empty);
        DetailClose();
    }


    /// <summary>
    /// 商品名字
    /// </summary>
    /// <param name="goodsname"></param>
    public void SetName(string goodsname)
    {
        Name.text = goodsname;
    }

    /// <summary>
    /// 当前拥有个数
    /// </summary>
    /// <param name="count"></param>
    public void SetOwn(int count)
    {
        if (count == 0)
            Own.text = string.Format("拥有<color=#ff0000>{0}</color>件", count);
        else
            Own.text = string.Format("拥有<color=#0000ffff>{0}</color>件", count);
    }

    /// <summary>
    /// 商品详情介绍
    /// </summary>
    /// <param name="detial1"></param>
    /// <param name="detial2">有的商品没有第二条详情</param>
    public void SetDetails(string detial1 = null, string detial2 = null)
    {
        Detail1.text = detial1;
        Detail2.text = detial2;
    }

    /// <summary>
    /// 花费消耗详情
    /// </summary>
    /// <param name="cost">消耗值</param>
    /// <param name="count">购买个数</param>
    /// <param name="costType">消耗的种类</param>
    public void SetCost(int cost,int count,GoodsCostType costType)
    {
        Cost.text = cost.ToString();
        CostCount.text = string.Format("购买<color=#0000ffff>{0}</color>件", count);

        string path = pathkind(costType);
        CostImage.overrideSprite = Resources.Load(path, typeof (Sprite)) as Sprite;
    }

    /// <summary>
    /// 寻找路径
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
        GoodsItemVO mVO = currSelectedVO;
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
}
