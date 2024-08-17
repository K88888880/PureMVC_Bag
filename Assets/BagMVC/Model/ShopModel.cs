using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel
{
   private List<GoodsData> goodsData=new List<GoodsData>();
    private List<Transform> cells= new List<Transform>();
    private List<GameObject> objects= new List<GameObject>();

    public List<GoodsData> GoodsData { get => goodsData; set => goodsData = value; }
    public List<Transform> Cells { get => cells; set => cells = value; }
    public List<GameObject> Objects { get => objects; set => objects = value; }
}
