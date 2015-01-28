// /***********************************************
//   MailBoxView.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/27
//   Description: 
//          邮箱主界面
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Holoville.HOTween;
using UnityEngine;
using UnityEngine.UI;
using OurWorld.Dota.Models.MailBox;

public class MailBoxView : MonoBehaviour
{
	private readonly MainMailBoxModel mModel = MainMailBoxModel.Instance;
	private List<EmailItemVO> emailsVOlist;         //邮件数据列表.
	private List<MainMailBoxItem> EmailsCachList;   //邮件Item列表缓存.

	private Transform mTrans;
	private GameObject mObj;
	private EmailDetail emailDetail;    //邮件内容Panel.
	
	/// <summary>
	/// The back button.
	/// </summary>
	public Button backBtn;              //返回主菜单.
	/// <summary>
	/// The emails item.
	/// </summary>
	public MainMailBoxItem EmailsItem;  //邮件Item模板.
	/// <summary>
	/// My grid t.
	/// </summary>
	public Transform MyGridT;           //邮件列表布局

	protected void Awake()
	{
		mTrans = this.transform;
		mObj = this.gameObject;

		//初始化时隐藏详情界面
		emailDetail = mTrans.Find ("PanelDetail").GetComponent<EmailDetail> ();
		if(emailDetail == null)
			emailDetail = mTrans.Find ("PanelDetail").gameObject.AddComponent<EmailDetail> ();
		emailDetail.Init ();

		if (backBtn == null)
			backBtn = mTrans.Find ("").GetComponent<Button> ();
//		if (EmailsItem == null)
//			EmailsItem = Resources.Load<>(path);	
		if (MyGridT == null)
			MyGridT = mTrans.Find("");
	}
	
	/// <summary>
	/// Init this instance.
	/// </summary>
	public void Init()
	{
		EmailsCachList = new List<MainMailBoxItem>();

		//MyGridT.GetComponent<GridLayoutGroup> ();

		emailsVOlist = mModel.EmailsItems.ToList();
		for (int i = 0; i < emailsVOlist.Count; i++)
		{
			MainMailBoxItem emailsItem = Instantiate(EmailsItem) as MainMailBoxItem;
			emailsItem.GetComponent<RectTransform>().SetParent(MyGridT);
			emailsItem.transform.localScale = Vector3.one;
			emailsItem.mVO = emailsVOlist[i];
			emailsItem.ItemUpdate();         
			
			EmailsCachList.Add(emailsItem);       //缓存商品列表，用于后续点击刷新更新按钮刷新商品数据来更新
		}

		backBtn.onClick.AddListener(OnBackBtnClick);
	}


	/// <summary>
	/// Gets my email detail.
	/// 邮件内容panel
	/// </summary>
	/// <value>My email detail.</value>
	public EmailDetail MyEmailDetail
	{
		get{ return this.emailDetail; }
	}


	/// <summary>
	/// Shows the email detail.
	/// 显示邮件内容.
	/// </summary>
	public void ShowEmailDetail()
	{
		MyEmailDetail.ShowEmailDetail();  
	}

	private void OnBackBtnClick()
	{
		GManger GameManger = GameObject.Find("GameManger").GetComponent<GManger>();
		GameManger.AllShow();
		HOTween.Kill ();
		Destroy(mObj);
		//Destroy(mObj,0.1f);
	}

	
}
