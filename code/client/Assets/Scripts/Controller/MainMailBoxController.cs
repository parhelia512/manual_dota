// /***********************************************
//   MainMailBoxController.cs
//   Author:      
//         XiaoHong <704872627@qq.com>
//   Date:         
//         2015/1/27
//   Description: 
//          Module function description
//
//   Copyright (c) 2015 XiaoHong
// **********************************************/

using UnityEngine;
using System.Collections;
using OurWorld.Dota.Models.MailBox;

public class MainMailBoxController  : Singleton<MainMailBoxController>
{
	private MailBoxView _mView;
	private readonly MainMailBoxModel _mModel = MainMailBoxModel.Instance;

	public void Show()
	{
		InitPrefab();
		_mModel.GetMailBoxData();
		_mView.Init();
	}

	public MailBoxView View
	{
		get { return _mView; }
	}

	public void ShowEmailDetail()
	{
		View.ShowEmailDetail ();
	}
	
	private void InitPrefab()
	{
		GameObject uiObj = GameObject.Find("Canvas");
		GameObject viewObj = MonoBehaviour.Instantiate(Resources.Load("gui/MainMailBox/UI_MailBox")) as GameObject;
		RectTransform rt = viewObj.GetComponent<RectTransform>();
		rt.SetParent(uiObj.transform);
		rt.anchoredPosition = Vector3.zero;
		rt.localScale = Vector3.one;
		
		_mView = viewObj.GetComponent<MailBoxView>();
	}
}
