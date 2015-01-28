// /***********************************************
//   MainMailBoxItem.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/27
//   Description: 
//          邮件Item， 使用ItemUpdate刷新邮件状态。
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/

using System;
using UnityEngine;
using UnityEngine.UI;
using OurWorld.Dota.Models.MailBox;

public class MainMailBoxItem : MonoBehaviour
{	
	/// <summary>
	/// The m V.
	/// </summary>
	public EmailItemVO mVO;                 //邮件数据信息.

	/// <summary>
	/// The title text.
	/// </summary>
	public Text TitleText;                   //邮件标题.
	/// <summary>
	/// The sender text.
	/// </summary>
	public Text SenderText;                  //发件人.
	/// <summary>
	/// The time text.
	/// </summary>
	public Text TimeText;                    //发件时间.
	/// <summary>
	/// The icon image.
	/// </summary>
	public Image IconImage;                  //图标类型.
	/// <summary>
	/// The read background image.
	/// </summary>
	public Image ReadBgImage;                //已读背景.
	/// <summary>
	/// The un read background image.
	/// </summary>
	public Image UnReadBgImage;              //未读背景.

	private Transform mTrans;
	private GameObject mObj;
	private Button mBtn;

	void Awake()
	{
		mTrans = this.transform;
		mObj = this.gameObject;
		mBtn = mTrans.GetComponent<Button> ();

		TitleText = mTrans.Find ("Text_Title").GetComponent<Text>();
		SenderText = mTrans.Find ("Text_Sender").GetComponent<Text>();
		TimeText = mTrans.Find ("Text_Time").GetComponent<Text>();
		IconImage = mTrans.Find ("EmailIcon/full/full_mask/cardIcon").GetComponent<Image> ();
		ReadBgImage = mTrans.Find ("Image_Read").GetComponent<Image> ();
		UnReadBgImage = mTrans.Find ("Image_Unread").GetComponent<Image> ();
	}

	/// <summary>
	/// 显示更新具体邮件.
	/// </summary>
	public void ItemUpdate()
	{
		Init();
	}
	
	private void Init()
	{
		mBtn.onClick.RemoveAllListeners();
		mBtn.onClick.AddListener(OnBtnClick);

		if(mVO == null)
		{
			Debug.LogWarning("this EmailItemVO is null !!!");
			return;
		}

		TitleText.text = mVO.title;
		TimeText.text = mVO.time;
		SenderText.text = mVO.sender;

		RefreshImage ();
	}

	
	private void OnBtnClick()
	{
		MainMailBoxController.Instance.View.MyEmailDetail.currSelectedVO = mVO;
		MainMailBoxController.Instance.View.ShowEmailDetail();

		//设置邮件状态.
		if (mVO.state == EmailState.UnRead)
			mVO.state = EmailState.Read;

		RefreshImage ();
	}

	//刷新邮件状态.
	private void RefreshImage()
	{
		bool isRead = mVO.state == EmailState.Read;
		ReadBgImage.gameObject.SetActive (isRead);
		UnReadBgImage.gameObject.SetActive (!isRead);

		//邮件图标.
		string iconPath = GetIconName();
		iconPath = "UI_EmailIcon/" + iconPath;
		IconImage.sprite = LoadSprite(iconPath);
	}

	//根据邮件状态和类型，获取邮件图标.
	private string GetIconName()
	{
		string temp = "mailbox_maillist_letter_";
		if(mVO.state == EmailState.Read)
		{
			if(mVO.type == EmailType.Common)
				temp += "open_";
			else
				temp += "open_victory_";
		}
		else
		{
			if(mVO.type == EmailType.Common)
				temp += "";
			else
				temp += "victory_";
		}
		temp += "icon";
		if(mVO.type == EmailType.System)
			temp = "mailbox_maillist_letter_announce_icon";
		return temp;
	}

	//加载图标资源.
	private Sprite LoadSprite(string path)
	{
		string myPath = "ImagePrefabs/UI_IconForDynamic/" + path;
		//var t = Resources.Load(myPath);
		//var temp = Instantiate(Resources.Load(myPath));
		
		return Resources.Load<GameObject>(myPath).GetComponent<SpriteRenderer>().sprite;
	}
}
