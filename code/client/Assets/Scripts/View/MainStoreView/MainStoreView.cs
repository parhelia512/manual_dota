using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Holoville.HOTween;
using OurWorld.Dota.Models.Stores;
using UnityEngine;
using UnityEngine.UI;

public class MainStoreView : MonoBehaviour
{
    public Image Head;
    public Button backbtn;
    public Button refreshBtnShow;
    public MainStoreItem GoodsItem;
    public Transform MyGridT;

    private Transform mTrans;
    private GameObject mobj;
    private GoodsDetail goodsDetail;
    private Text refreshtime;
    private Text tipstext;
    private Image tipsimage;

    private Transform refreshT;
    private Text refreshText;
    private Button refreshBtnCancel;
    private Button refreshBtnSure;

    protected void Awake()
    {
        mTrans = this.transform;
        mobj = this.gameObject;

        //初始化时隐藏详情界面
        goodsDetail = mTrans.Find("itemInfo_popUp").GetComponent<GoodsDetail>();
        goodsDetail.Init();

        refreshtime = mTrans.Find("shop_bg/nextTimeRefresh/refresh_title/refresh_time").GetComponent<Text>();
        tipstext = mTrans.Find("shop_bg/Tips/tipsText").GetComponent<Text>();
        tipsimage = mTrans.Find("shop_bg/Tips").GetComponent<Image>();
        
        refreshT = mTrans.Find("crystalRefresh");
        if(refreshT.gameObject.activeInHierarchy)
            refreshT.gameObject.SetActive(false);

        refreshText = refreshT.Find("refreshbackground/Text").GetComponent<Text>();
        refreshBtnCancel = refreshT.Find("refreshbackground/ButtonCancel").GetComponent<Button>();
        refreshBtnSure = refreshT.Find("refreshbackground/ButtonSure").GetComponent<Button>();
    }

    public void Init()
    {
        SetNextTimeRefresh(mModel.GetMainSoreVO.nextTimeRefresh);

        goodslist = mModel.GoodsItems.ToList();
        for (int i = 0; i < goodslist.Count; i++)
        {
            MainStoreItem goodsItem = Instantiate(GoodsItem) as MainStoreItem;
            goodsItem.GetComponent<RectTransform>().SetParent(MyGridT);
            goodsItem.transform.localScale = Vector3.one;
            goodsItem.mVO = goodslist[i];
            goodsItem.ItemUpdate();
        }

        backbtn.onClick.AddListener(OnBackBtnClick);

        refreshBtnShow.onClick.AddListener(OnRefreshBtnShowClick);
        refreshBtnCancel.onClick.AddListener(OnRefreshBtnCancelClick);

        EnterTips();
        EventTriggerListener.Get(Head.gameObject).onClick = ShowTips;
    }

    #region Tips    后续会重构本段代码

    string tip0 = "欢迎来到希娜的小店。$425";
    string tip1 = "你的手指真灵活，我很喜欢。$355";
    string tip2 = "轻一点，亲爱的。$475";
    string tip3 = "我会在每天9点，12点，18点和21点换上新的货物。$120";

    private void ShowTips(GameObject obj)
    {
        Debug.Log("xxxx");
        StartCoroutine(ReturnFadeTips());

        int number = UnityEngine.Random.Range(0,4);
        Debug.Log(number);
        if(number == 0)
            TipTemplateShow(tip0);
        if(number == 1)
            TipTemplateShow(tip1);
        if(number == 2)
            TipTemplateShow(tip2);
        if(number == 3)
            TipTemplateShow(tip3);
    }

    private void EnterTips()
    {
       TipTemplateShow(tip0);
        #region Legacy

        //string[] list = tip0.Split(new[] { "$" }, StringSplitOptions.None);

        //tipstext.text = list[0];

        //float rightsize = float.Parse(list[1]);
        //RectTransform rtf = tipsimage.GetComponent<RectTransform>();

        //rtf.offsetMax = new Vector2(-rightsize, rtf.offsetMax.y);

        //StartCoroutine(CrossFadeTips());


        ////rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, -rightsize);

        //Debug.Log("AnchorsMin: " + rtf.anchorMin);
        //Debug.Log("AnchorsMax：" + rtf.anchorMax);

        //Debug.Log("AnchorsOffsetMin: " + rtf.offsetMin);
        //Debug.Log("AnchorsOffsetMax: " + rtf.offsetMax);


        //Debug.Log("left: " + rtf.rect.xMin);
        //Debug.Log("right: " + rtf.rect.xMax);
        //Debug.Log("top: " + rtf.rect.yMin);
        //Debug.Log("bottom: " + rtf.rect.yMax);
        ////rtf.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right,rightsize,rightsize);    

        //GUIStyle style = new GUIStyle();
        //style.stretchWidth = true;

        //Debug.Log("style border: " + style.border.right);
        //style.border.right = (int)rightsize;

        #endregion
    }

    private void TipTemplateShow(string text)
    {

        string[] list = text.Split(new[] { "$" }, StringSplitOptions.None);

        tipstext.text = list[0];

        float rightsize = float.Parse(list[1]);
        RectTransform rtf = tipsimage.GetComponent<RectTransform>();

        rtf.offsetMax = new Vector2(-rightsize, rtf.offsetMax.y);

        StartCoroutine(CrossFadeTips());
    }

    private IEnumerator CrossFadeTips()
    {
        yield return new WaitForSeconds(1f);
        tipsimage.CrossFadeAlpha(0f, 1f, true);
        tipstext.CrossFadeAlpha(0f, 1f, true);
    }

    private IEnumerator ReturnFadeTips()
    {
        yield return null;
        tipsimage.CrossFadeAlpha(1f, 0.1f, true);
        tipstext.CrossFadeAlpha(1f, 0.1f, true);
        //tipsimage.color = new Color(tipsimage.color.r,tipsimage.color.g,tipsimage.color.b,1f);
        //tipstext.color = new Color(tipstext.color.r,tipstext.color.g,tipstext.color.b,1f);
    }

    #endregion
    
    /// <summary>
    /// 打开刷新选择界面按钮
    /// </summary>
    private void OnRefreshBtnShowClick()
    {
        SetRefreshChoiceOpen();
    }

    /// <summary>
    /// 点击好的，消耗钻石，刷新所有商品
    /// </summary>
    private void OnRefreshBtnSureClick()
    {

    }

    /// <summary>
    /// 点击取消关闭刷新选择界面
    /// </summary>
    private void OnRefreshBtnCancelClick()
    {
        SetRefreshChoiceClose();
    }

    #region Animation
    private TweenParms parms;
    private Tweener temp;
    private void SetRefreshChoiceOpen()
    {
        refreshT.gameObject.SetActive(true);

        if (parms == null)
        {
            refreshT.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            parms = new TweenParms();
            parms.Prop("localScale", new Vector3(1f, 1f, 1f));
            parms.Ease(EaseType.EaseOutBack);
            parms.Delay(0.1f);
            parms.AutoKill(false);
            temp = HOTween.To(refreshT, 0.2f, parms);
        }
        temp.PlayForward();
    }
    private void SetRefreshChoiceClose()
    {
        temp.ApplyCallback(CallbackType.OnRewinded, MyComplete);
        temp.PlayBackwards();
    }
    private void MyComplete()
    {
        refreshT.gameObject.SetActive(false);
    }
    #endregion

    private void OnBackBtnClick()
    {
        GManger GameManger = GameObject.Find("GameManger").GetComponent<GManger>();
        GameManger.AllShow();
        HOTween.Kill();
        Destroy(mTrans.gameObject,0.1f);
    }

    public GoodsDetail MyGoodsDetail
    {
        get { return goodsDetail; }
    }

    /// <summary>
    /// 商品详情展示
    /// </summary>
    public void ShowDetail()
    {
       MyGoodsDetail.DetailShow();
    }

    /// <summary>
    /// 更新自动刷新时间
    /// </summary>
    /// <param name="nexttime"></param>
    public void SetNextTimeRefresh(int nexttime)
    {
        refreshtime.text = string.Format("今日{0}点",nexttime);
    }

    private readonly MainStoreModel mModel = MainStoreModel.Instance;
    private List<GoodsItemVO> goodslist;

}
