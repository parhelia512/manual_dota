using UnityEngine;
using UnityEngine.UI;

public class GoodsCard : MonoBehaviour
{
    public GameObject Chip;
    public GameObject Full;

    public Text Count;

    public Image FullFrame;
    public Image ChipFrame;

    public Image chipCardIcon;
    public Image chipKind;
    public Image fullCardIcon;

    //public void UpdateView(IGoodsVO vo)
    //{

    //}

    #region updateiamge

    public void updateEquipImage(EquipmentVO vo)
    {
        Chip.SetActive(false);
        Full.SetActive(true);

        //TODO:后续统一从资源管理器脚本类加载预设
        //品质外框
        string frame = FullQualityPath(vo.Quality);
        string qualitypath = "ChangeIcon/ImageIcon/qualityframe/" + frame;
        FullFrame.overrideSprite = Resources.Load(qualitypath, typeof(Sprite)) as Sprite;

        //装备图标
        string cardpath = "ChangeIcon/ImageIcon/equip/" + vo.ID;
        fullCardIcon.overrideSprite = Resources.Load(cardpath, typeof(Sprite)) as Sprite;
    }

    public void updateMedicineImage(MedicineVO vo)
    {
        Chip.SetActive(false);
        Full.SetActive(true);

        //TODO:后续统一从资源管理器脚本类加载预设
        //品质外框
        string frame = FullQualityPath(vo.Quality);
        string qualitypath = "ChangeIcon/ImageIcon/qualityframe/" + frame;
        FullFrame.overrideSprite = Resources.Load(qualitypath, typeof(Sprite)) as Sprite;

        //药品图标
        string cardpath = "ChangeIcon/ImageIcon/medicine/" + vo.ID;
        fullCardIcon.overrideSprite = Resources.Load(cardpath, typeof(Sprite)) as Sprite;
    }

    public void updateScrollImage(ScrollVO vo)
    {
        Chip.SetActive(false);
        Full.SetActive(true);

        //TODO:后续统一从资源管理器脚本类加载预设
        //品质外框
        string frame = FullQualityPath(vo.Quality);
        string qualitypath = "ChangeIcon/ImageIcon/qualityframe/" + frame;
        FullFrame.overrideSprite = Resources.Load(qualitypath, typeof(Sprite)) as Sprite;

        //卷轴图标
        string cardpath = "ChangeIcon/ImageIcon/scroll/" + vo.ID;
        fullCardIcon.overrideSprite = Resources.Load(cardpath, typeof(Sprite)) as Sprite;
    }

    public void updateSoulStoneImage(SoulStoneVO vo)
    {
        Chip.SetActive(true);
        Full.SetActive(false);

        //TODO:后续统一从资源管理器脚本类加载预设
        //品质外框
        string frame = ChipQualityPath(vo.Quality);
        string qualitypath = "ChangeIcon/ImageIcon/qualityframe/" + frame;
        ChipFrame.overrideSprite = Resources.Load(qualitypath, typeof (Sprite)) as Sprite;

        //灵魂石图标
        string kindpath = "ChangeIcon/ImageIcon/soulstone/equip_soulstone_ta";
        chipKind.overrideSprite = Resources.Load(kindpath, typeof(Sprite)) as Sprite;
        
        //英雄图标
        string cardpath = "ChangeIcon/ImageIcon/hero/" + vo.ID.ToString();
        chipCardIcon.overrideSprite = Resources.Load(cardpath, typeof(Sprite)) as Sprite;

    }

    public void updateChipImage(ChipVO vo)
    {
        Chip.SetActive(true);
        Full.SetActive(false);

        //TODO:后续统一从资源管理器脚本类加载预设
        //品质外框
        string frame = ChipQualityPath(vo.Quality);
        string qualitypath = "ChangeIcon/ImageIcon/qualityframe/" + frame;
        ChipFrame.overrideSprite = Resources.Load(qualitypath, typeof(Sprite)) as Sprite;

        //碎片图标
        string kindpath = "ChangeIcon/ImageIcon/chip/fragment_tag";
        chipKind.overrideSprite = Resources.Load(kindpath, typeof(Sprite)) as Sprite;

        //装备或卷轴图标
        string cardpath = string.Empty;
        if (vo.Type == 1)           //type为1则是装备碎片
        {
            cardpath = "ChangeIcon/ImageIcon/equip/";
        }
        else if(vo.Type ==2)        //type为2则是卷轴碎片
        {
            cardpath = "ChangeIcon/ImageIcon/scroll/";
        }
        else
        {
            Debug.LogWarning("there is sth wrong with chip type");
            return;
        }
        cardpath += vo.ID.ToString() + "+";
        
        chipCardIcon.overrideSprite = Resources.Load(cardpath, typeof(Sprite)) as Sprite;
    }

    #endregion


    #region 品质边框资源加载路径读取
    /// <summary>
    /// 完整物品的品质外框资源加载路径获取
    /// </summary>
    /// <param name="quality"></param>
    /// <returns></returns>
    private string FullQualityPath(int quality)
    {
        string path = "";
        switch (quality)
        {
            case 0: path = "equip_frame_white"; break;
            case 1: path = "equip_frame_green"; break;
            case 2: path = "equip_frame_blue"; break;
            case 3: path = "equip_frame_purple"; break;
            case 4: path = "equip_frame_orange"; break;
        }
        return path;
    }

    /// <summary>
    /// 碎片、灵魂石等物品的品质外框资源加载路径获取
    /// </summary>
    /// <param name="quality"></param>
    /// <returns></returns>
    private string ChipQualityPath(int quality)
    {
        string path = "";
        switch (quality)
        {
            case 0: path = "fragment_frame_white"; break;
            case 1: path = "fragment_frame_green"; break;
            case 2: path = "fragment_frame_bule"; break;
            case 3: path = "fragment_frame_purple"; break;
            case 4: path = "fragment_frame_orange"; break;
        }
        return path;
    }
    #endregion
}
