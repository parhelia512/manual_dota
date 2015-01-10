/**
* Copyright (c) 2012,广州维动网络科技有限公司
* All rights reserved.
* 
* 文件名称：ShowFps.cs
* 简    述：用于显示FPS。
* 创建标识：Lorry  2012/10/25
* 修改描述：none
* 修改标识：Lorry  2012/11/02
*/
@script ExecuteInEditMode

private var gui : GUIText;

private var updateInterval = 1.0;
private var lastInterval : double; // Last interval end time
private var frames = 0; // Frames over current interval

function Start()
{
    lastInterval = Time.realtimeSinceStartup;
    frames = 0;
    Application.targetFrameRate = -1;
}

function OnDisable ()
{
	if (gui)
		DestroyImmediate (gui.gameObject);
}

function Update()
{
    ++frames;
    var timeNow = Time.realtimeSinceStartup;
    if (timeNow > lastInterval + updateInterval)
    {
		if (!gui)
		{
			var go : GameObject = GameObject.Find("FPS Display");
			if(go == null)
				go = new GameObject("FPS Display", GUIText);
			go.hideFlags = HideFlags.HideAndDontSave;
			go.transform.position = Vector3(0,0,0);
			gui = go.guiText;
			gui.color = Color.red;
			gui.fontSize = 12;
			gui.pixelOffset = Vector2(10,20);
		}
        var fps : float = frames / (timeNow - lastInterval);
		var ms : float = 1000.0f / Mathf.Max (fps, 0.00001);
		gui.text = ms.ToString("f1") + "ms " + fps.ToString("f2") + "FPS" ;
        frames = 0;
        lastInterval = timeNow;
    }
}
