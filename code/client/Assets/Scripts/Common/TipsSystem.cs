using Holoville.HOTween;
using Holoville.HOTween.Plugins;
using Holoville.HOTween.Plugins.Core;
using UnityEngine;
using UnityEngine.UI;

public class TipsSystem
{
    private static TipsSystem _instance;

    public static TipsSystem Instance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new TipsSystem();
            }

            return _instance;
        }
    }

    public void ShowTips(string name)
    {
        string tips = string.Format("我是{0}妹纸，等着程序哥哥来开发，求抱走", name);     //TODO:后续从配置文件里取
        
        if(imageObj == null)
        {
            Init(tips);
        }
        else
        {
            GameObject.Destroy(imageObj);
            Init(tips);
        }
    }

    private void Init(string tip)
    {
        imageObj = MonoBehaviour.Instantiate(Resources.Load("Tips/TipsImage")) as GameObject;
        imageObj.GetComponent<RectTransform>().SetParent(tipParent);
        imageObj.transform.localPosition = new Vector3(0,-100,0);
 
        image = imageObj.GetComponent<Image>();
        imageforblack = image.transform.Find("for more black").GetComponent<Image>();
        text = imageforblack.transform.Find("my lable").GetComponent<Text>();

        text.text = tip;

        HOTween.Init();
        TweenParms parms = new TweenParms();
        parms.Prop("localPosition", new PlugVector3Y(50));
        parms.Ease(EaseType.EaseOutCubic);
        parms.Delay(0.1f);
        parms.OnComplete(MyComplete);
        HOTween.To(image.rectTransform, 1.5f, parms);

        #region Legacy DoTween
        //DOTween.Init();

        //Tweener tweener = image.rectTransform.DOMoveY(250f, 1f);
        //tweener.SetEase(Ease.Linear);

        //image.material.DOColor(Color.clear,1.5f);
        //text.material.DOColor(Color.clear, 1.5f);

        //tweener.OnComplete(MyComplete);
        #endregion    
    }

    /// <summary>
    /// 回调
    /// </summary>
    private void MyComplete()
    {
        #region legacy OriginalTest
        //Color oldColor = text.color;//text.material.color;
        //Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, 0f);
        //Color.Lerp(oldColor, newColor, 1f);

        //Debug.Log("old color:" + text.color);
        ////text.color = newColor;
        //Debug.Log("new color:" + text.color);


        //CrossFadeColor(toColor,1f,true,true);

        //image.CrossFadeColor();
        //imageforblack.CrossFadeAlpha();

        //Color oldColor = text.color;
        //Color toColor = new Color(oldColor.r,oldColor.g,oldColor.b,0f);
        #endregion

        text.CrossFadeAlpha(0f,1f,true);
        image.CrossFadeAlpha(0f, 1f, true);
        imageforblack.CrossFadeAlpha(0f, 1f, true);

        //HOTween.Kill();

        GameObject.Destroy(imageObj,1f);

        #region Legacy HoTween

        //TweenParms parms = new TweenParms();
        //parms.Prop("color", new PlugColor(toColor));
        //parms.Ease(EaseType.EaseOutCubic);
        //HOTween.To(text.color, 1f, parms);

        #endregion

        #region Legacy DoTween

        //image.material.DOColor(Color.white, 0.01f);
        //text.material.DOColor(Color.white, 0.01f);
        //DOTween.Clear();

        #endregion
    }

    private TipsSystem()
    {
        tipParent = GameObject.Find("Canvas_Tips").transform.Find("Tips_Panel");
        #region Legacy
        //if (image == null || text == null)
        //{
        //    image = tipParent.transform.Find("TipsImage").GetComponent<Image>();
        //    imageforblack = image.transform.Find("for more black").GetComponent<Image>();
        //    text = imageforblack.transform.Find("my lable").GetComponent<Text>();
        //}

        //if (image.gameObject.activeInHierarchy)
        //{
        //    image.gameObject.SetActive(false);
        //}
        #endregion     
    }

    private Transform tipParent;
    private GameObject imageObj;
    private Image image;
    private Image imageforblack;
    private Text text;
}
