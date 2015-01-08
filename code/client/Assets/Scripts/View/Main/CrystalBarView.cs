using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrystalBarView : MonoBehaviour {

    public Text CrystalText;
    public Button AddCrystalBtn;

    private Transform mTrans;

    void Start()
    {
        Init();

        AddCrystalBtn.onClick.AddListener(AddCrystalBtnClick);
    }

    private void Init()
    {
        mTrans = this.transform;

        if (CrystalText == null || AddCrystalBtn == null)
        {
            try
            {
                CrystalText = mTrans.Find("rmb_text").GetComponent<Text>();
                AddCrystalBtn = mTrans.Find("Button_plus").GetComponent<Button>();
            }
            catch (Exception)
            {
                string text = String.Format("The object can not find.Please check the Prefab:{0}", mTrans.name);
                throw new Exception(text);
            }
        }
    }

    /// <summary>
    /// 设置当前持有晶钻数量
    /// </summary>
    /// <param name="count"></param>
    public void SetCoinCount(int count)
    {
        CrystalText.text = count.ToString();
    }

    private void AddCrystalBtnClick()
    {
        //TODO:vip晶钻功能实现
    }
}
