using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinBarView : MonoBehaviour {

    public Text CoinText;
    public Button AddCoinBtn;

    private Transform mTrans;

    void Start()
    {
        Init();

        AddCoinBtn.onClick.AddListener(AddCoinBtnClick);
    }

    private void Init()
    {
        mTrans = this.transform;

        if (CoinText == null || AddCoinBtn == null)
        {
            try
            {
                CoinText = mTrans.Find("gold_text").GetComponent<Text>();
                AddCoinBtn = mTrans.Find("Button_plus").GetComponent<Button>();
            }
            catch (Exception)
            {
                string text = String.Format("The object can not find.Please check the Prefab:{0}", mTrans.name);
                throw new Exception(text);
            }
        }
    }

    /// <summary>
    /// 设置当前持有金币数量
    /// </summary>
    /// <param name="count"></param>
    public void SetCoinCount(int count)
    {
        CoinText.text = count.ToString();
    }

    private void AddCoinBtnClick()
    {
        //TODO:点金手功能实现
    }
}
