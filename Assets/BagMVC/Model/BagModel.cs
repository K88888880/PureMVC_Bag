using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoodsData
{
    public string id;
    public string name;
    public string icon;
    public string inventoryType;
    public string equipType;
    public string sale;
    public string starLevel;
    public string quality;
    public string damage;
    public string hp;
    public string power;
    public string Des;
}

public class BagData
{
    public int num;
    public GoodsData goodsData=new GoodsData();
}
public class BagModel
{
    private int bagcellNum;
    private List<Transform> bagcells=new List<Transform>();
    private List<GameObject> bagitem=new List<GameObject>();
    private List<BagData> goodsDatas=new List<BagData>();
    public int BagcellNum { get => bagcellNum; set => bagcellNum = value; }
    public List<Transform> Bagcells { get => bagcells; set => bagcells = value; }
    public List<GameObject> Bagitem { get => bagitem; set => bagitem = value; }
    public List<BagData> GoodsDatas { get => goodsDatas; set => goodsDatas = value; }
}
