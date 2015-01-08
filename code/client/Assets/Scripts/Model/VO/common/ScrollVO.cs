using UnityEngine;
using System.Collections;

public class ScrollVO  {

    /// <summary>
    /// 获取模板编号
    /// </summary>
    public int ID
    {
        get { return id; }
    }

    /// <summary>
    /// 品质0到4，分别对应白、绿、篮、紫、金（橙）
    /// </summary>
    public int Quality
    {
        get { return quality; }
    }

    /// <summary>
    /// 拥有个数
    /// </summary>
    public int Own
    {
        get { return own; }
    }

    /// <summary>
    /// 价格
    /// </summary>
    public int Price
    {
        get { return price; }
    }

    /// <summary>
    ///名字 
    /// </summary>
    public string Name
    {
        get { return name; }
    }

    /// <summary>
    /// 详情
    /// </summary>
    public string Detail
    {
        get { return detail; }
    }

    /// <summary>
    /// 额外的详情
    /// </summary>
    public string ExtraDetail
    {
        get { return extradetail; }
    }

    public int id;
    public int own;
    public int price;
    public int quality;
    public string name;
    public string detail;
    public string extradetail;
}
