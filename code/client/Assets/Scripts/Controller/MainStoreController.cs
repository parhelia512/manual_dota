using OurWorld.Dota.Models.Stores;
using UnityEngine;

public class MainStoreController
{
    private static MainStoreController _instance;

    public static MainStoreController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MainStoreController();
            }
            return _instance;
        }
    }

    public void Show()
    {
        InitPrefab();
        mModel.GetMainStoreDate();
        View.Init();
    }

    /// <summary>
    /// 展示商品详情
    /// </summary>
    public void ShowGoodsDetail()
    {
        View.ShowDetail();
    }

    public MainStoreView View
    {
        get { return _mView; }
    }

    private void InitPrefab()
    {
        GameObject uiObj = GameObject.Find("Canvas");
        GameObject viewObj = MonoBehaviour.Instantiate(Resources.Load("gui/MainStore/UI_shop")) as GameObject;
        RectTransform rt = viewObj.GetComponent<RectTransform>();
        rt.SetParent(uiObj.transform);
        rt.anchoredPosition = Vector3.zero;
        rt.localScale = Vector3.one;

        _mView = viewObj.GetComponent<MainStoreView>();
    }

    private MainStoreController()
    {
       
    }

    private MainStoreView _mView;
    private readonly MainStoreModel mModel = MainStoreModel.Instance;


}
