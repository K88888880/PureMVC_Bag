using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopProxy : PureMVC.Patterns.Proxy
{
    public new static string NAME = "ShopProxy";

    ShopModel model;
    public ShopProxy(string name) : base(NAME)
    {
        model = new ShopModel();
        model.GoodsData = JsonConvert.DeserializeObject<List<GoodsData>>(Resources.Load<TextAsset>("inventoryConfig").text);
    }

    public void CreateShopCell(Transform tran)
    {
        for (int i = 0; i < model.GoodsData.Count; i++)
        {
            GameObject cell = GameObject.Instantiate(Resources.Load<GameObject>("ShopCell"), tran);
            model.Cells.Add(cell.transform);
        }
    }


    public void CretateItem()
    {
        
        for (int i = 0; i < model.Cells.Count; i++)
        {
            GameObject item = GameObject.Instantiate(Resources.Load<GameObject>("ShopItem"), model.Cells[i]);
            item.GetComponent<ShopItem>().Init(model.GoodsData[i]);
        }
    }

    public void Classify(string str)
    {
        List<GoodsData> goodsDatas = new List<GoodsData>();
        foreach (var item in model.GoodsData)
        {
            if (item.inventoryType==str)
            {
                
                goodsDatas.Add(item);
            }
        }

        UpDateShop(goodsDatas);
    }

    public void UpDateShop(List<GoodsData> goodsDatas)
    {
        
        for (int i = 0; i < model.Cells.Count; i++)
        {
            if (model.Cells[i].childCount>0)
            {
                GameObject.DestroyImmediate(model.Cells[i].GetChild(0).gameObject);
            }
        }
        for (int i = 0; i < goodsDatas.Count; i++)
        {
            GameObject item = GameObject.Instantiate(Resources.Load<GameObject>("ShopItem"), model.Cells[i]);
            item.GetComponent<ShopItem>().Init(goodsDatas[i]);
        }
    }

    public void ShowAll()
    {
        UpDateShop(model.GoodsData);
    }







}
