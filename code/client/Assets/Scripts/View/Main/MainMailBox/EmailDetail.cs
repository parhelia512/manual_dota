// /***********************************************
//   EmailDetail.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/27
//   Description: 
//          邮件详细内容Panel
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using OurWorld.Dota.Models.MailBox;
using Holoville.HOTween;

public class EmailDetail : MonoBehaviour 
{
	private Transform mTrans;
	private GameObject mObj;
	
	/// <summary>
	/// The curr selected V.
	/// </summary>
	public EmailItemVO currSelectedVO;
	/// <summary>
	/// The close button.
	/// </summary>
	public Button CloseBtn;
	/// <summary>
	/// The title text.
	/// </summary>
	public Text TitleText;
	/// <summary>
	/// The detail text.
	/// </summary>
	public Text DetailText;
	/// <summary>
	/// The tween panel.
	/// </summary>
	public Transform TweenPanel;

	private Tweener temp;
	private TweenParms parms;

	/// <summary>
	/// 当点击购买按钮后，详情关闭时触发此事件。
	/// </summary>
	//public event EventHandler CloseDetail;

	/// <summary>
	/// Init this instance.
	/// </summary>
	public void Init()
	{
		if (mTrans == null)
			mTrans = this.transform;
		
		if (mObj == null)
			mObj = this.gameObject;
		
		if (mObj.activeInHierarchy)
			mObj.SetActive(false);

		if (CloseBtn == null)
			CloseBtn = mTrans.Find("Panel_Tween/Button_CloseDetail").GetComponent<Button>();
		CloseBtn.onClick.AddListener(OnCloseBtnClick);

		if (TitleText == null)
			TitleText = mTrans.Find("Panel_Tween/Text_Title").GetComponent<Text>();

		if (DetailText == null)
			DetailText = mTrans.Find("Panel_Tween/Text_Detail").GetComponent<Text>();

		if (TweenPanel == null)
			TweenPanel = mTrans.Find ("Panel_Tween");
	}

	/// <summary>
	/// Shows the email detail.
	/// </summary>
	public void ShowEmailDetail()
	{
		Show();
		mObj.SetActive(true);
	}

	private void CloseEmailDetail()
	{
		temp.ApplyCallback(CallbackType.OnRewinded, MyComplete);
		temp.PlayBackwards();
	}

	private void Show()
	{
		//todo:根据数据初始化整个详情
		if (currSelectedVO != null)
		{
			TitleText.text = currSelectedVO.title;
			DetailText.text = currSelectedVO.content;
		}
		//Convert();
		
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

	/// <summary>
	/// 关闭详情按钮
	/// </summary>
	private void OnCloseBtnClick()
	{
		CloseEmailDetail();
		
		//todo: -=
		//if (CloseDetail != null)
		//	CloseDetail = null;
	}
}
