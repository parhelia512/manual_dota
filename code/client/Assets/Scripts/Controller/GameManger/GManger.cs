using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GManger : MonoBehaviour
{
    public GameObject PlayerHeadObje;
    public GameObject BtnsObjForHide;
    public GameObject BtncrusadeObjForHide;
    public ParallaxScrolling scriptForIgnore;

    public Image Crusade;           //燃烧远征
    public Image Treasure;          //宝藏地穴
    public Image Rank;              //排行榜
    public Image PredictionPool;    //预言之池
    public Image TimeCave;          //时光之穴
    public Image MailBox;           //信箱
    public Image Battle;            //战役（pve）
    public Image TopPvP;            //巅峰竞技场
    public Image Tavern;            //召唤师法阵（酒馆，抽包的坑）
    public Image Arena;             //竞技场（pvp）
    public Image Shop;              //商店
    public Image Awake;             //洗练（觉醒）
    public Image Exercise;          //英雄试炼
    public Image Enhance;           //装备附魔（强化）
    public Image Guild;             //公会

	void Start () 
    {
        Init();
    }

    private void Init()
    {
        if (Crusade != null)
        {
            EventTriggerListener.Get(Crusade.gameObject).onClick = CrusadeBtnClick;
        }

        #region Same
        if (Treasure != null)
        {
            EventTriggerListener.Get(Treasure.gameObject).onClick = TreasureBtnClick;
        }

        if (Rank != null)
        {
            EventTriggerListener.Get(Rank.gameObject).onClick = RankBtnClick;
        }

        if (PredictionPool != null)
        {
            EventTriggerListener.Get(PredictionPool.gameObject).onClick = PredictionPoolBtnClick;
        }

        if (TimeCave != null)
        {
            EventTriggerListener.Get(TimeCave.gameObject).onClick = TimeCaveBtnClick;
        }

        if (MailBox != null)
        {
            EventTriggerListener.Get(MailBox.gameObject).onClick = MailBoxBtnClick;
        }

        if (Battle != null)
        {
            EventTriggerListener.Get(Battle.gameObject).onClick = BattleBtnClick;
        }

        if (TopPvP != null)
        {
            EventTriggerListener.Get(TopPvP.gameObject).onClick = TopPvPBtnClick;
        }

        if (Tavern != null)
        {
            EventTriggerListener.Get(Tavern.gameObject).onClick = TavernBtnClick;
        }

        if (Arena != null)
        {
            EventTriggerListener.Get(Arena.gameObject).onClick = ArenaBtnClick;
        }

        if (Shop != null)
        {
            EventTriggerListener.Get(Shop.gameObject).onClick = ShopBtnClick;
        }

        if (Awake != null)
        {
            EventTriggerListener.Get(Awake.gameObject).onClick = AwakeBtnClick;
        }

        if (Exercise != null)
        {
            EventTriggerListener.Get(Exercise.gameObject).onClick = ExerciseBtnClick;
        }

        if (Enhance != null)
        {
            EventTriggerListener.Get(Enhance.gameObject).onClick = EnhanceBtnClick;
        }

        if (Guild != null)
        {
            EventTriggerListener.Get(Guild.gameObject).onClick = GuildBtnClick;
        }	 
        #endregion      
    }

    /// <summary>
    /// 打开某个功能按钮后，隐藏首页的其他按钮，以及忽略视差滚动
    /// </summary>
    private void AllHide()
    {
        PlayerHeadObje.SetActive(false);
        BtncrusadeObjForHide.SetActive(false);
        BtnsObjForHide.SetActive(false);
        scriptForIgnore.enabled = false;
    }

    /// <summary>
    /// 关闭某个功能视图后，显示首页的所有按钮，以及激活视差滚动
    /// </summary>
    public void AllShow()
    {
        PlayerHeadObje.SetActive(true);
        BtncrusadeObjForHide.SetActive(true);
        BtnsObjForHide.SetActive(true);
        scriptForIgnore.enabled = true;
        scriptForIgnore.ShutDownDraggedOnce();
    }

    /// <summary>
    /// 燃烧远征
    /// </summary>
    /// <param name="obj"></param>
    private void CrusadeBtnClick(GameObject obj)
    {
        string tt = "燃烧远征";             //TODO：后续根据点击的按钮名字，从配置文件读取
        TipsSystem.Instance.ShowTips(tt);
    }

    /// <summary>
    /// 藏宝地穴
    /// </summary>
    /// <param name="obj"></param>
    private void TreasureBtnClick(GameObject obj)
    {
        string tt = "藏宝地穴";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }

    /// <summary>
    /// 排行榜
    /// </summary>
    /// <param name="obj"></param>
    private void RankBtnClick(GameObject obj)
    {
        string tt = "排行榜";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }

    /// <summary>
    /// 预言之池
    /// </summary>
    /// <param name="obj"></param>
    private void PredictionPoolBtnClick(GameObject obj)
    {
        string tt = "预言之池";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }

    /// <summary>
    /// 时光之穴
    /// </summary>
    /// <param name="obj"></param>
    private void TimeCaveBtnClick(GameObject obj)
    {
        string tt = "时光之穴";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }

    /// <summary>
    /// 信箱
    /// </summary>
    /// <param name="obj"></param>
    private void MailBoxBtnClick(GameObject obj)
    {
		//        string tt = "信箱";             //TODO：同上
		//        TipsSystem.Instance.ShowTips(tt);
		
		MainMailBoxController.Instance.Show();
		AllHide();
    }

    /// <summary>
    /// 战役
    /// </summary>
    /// <param name="obj"></param>
    private void BattleBtnClick(GameObject obj)
    {
        string tt = "战役";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }

    /// <summary>
    /// 巅峰竞技场
    /// </summary>
    /// <param name="obj"></param>
    private void TopPvPBtnClick(GameObject obj)
    {
        string tt = "巅峰竞技场";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }

    /// <summary>
    /// 召唤法阵
    /// </summary>
    /// <param name="obj"></param>
    private void TavernBtnClick(GameObject obj)
    {
        string tt = "召唤法阵";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }
    /// <summary>
    /// 竞技场
    /// </summary>
    /// <param name="obj"></param>
    private void ArenaBtnClick(GameObject obj)
    {
        string tt = "竞技场";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }

    /// <summary>
    /// 商人
    /// </summary>
    /// <param name="obj"></param>
    private void ShopBtnClick(GameObject obj)
    {
        //string tt = "商人";             //TODO：同上
        //TipsSystem.Instance.ShowTips(tt);

        MainStoreController.Instance.Show();
        AllHide();
    }

    /// <summary>
    /// 洗练
    /// </summary>
    /// <param name="obj"></param>
    private void AwakeBtnClick(GameObject obj)
    {
        string tt = "洗练";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    }
    
    /// <summary>
    /// 英雄试炼
    /// </summary>
    /// <param name="obj"></param>
    private void ExerciseBtnClick(GameObject obj)
    {
        string tt = "英雄试炼";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    } 
    
    /// <summary>
    /// 装备附魔
    /// </summary>
    /// <param name="obj"></param>
    private void EnhanceBtnClick(GameObject obj)
    {
        string tt = "装备附魔";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    } 
    
    /// <summary>
    /// 公会
    /// </summary>
    /// <param name="obj"></param>
    private void GuildBtnClick(GameObject obj)
    {
        string tt = "公会";             //TODO：同上
        TipsSystem.Instance.ShowTips(tt);
    } 
    

}
