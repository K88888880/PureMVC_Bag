using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEditor;

public class BagProxy : PureMVC.Patterns.Proxy
{
    public new static string NAME = "BagProxy";
    BagModel bagModel;
    public BagProxy(string name) : base(NAME)
    {
        bagModel = new BagModel();
        //  bagModel.GoodsDatas = JsonConvert.DeserializeObject<List<GoodsData>>(Resources.Load<TextAsset>("inventoryConfig").text);
        bagModel.GoodsDatas = new List<BagData>();
        bagModel.BagcellNum = 10;

    }

    public void AddGoods(int num, GoodsData goodsData)
    {
        for (int i = 0; i < bagModel.GoodsDatas.Count; i++)
        {
            if (bagModel.GoodsDatas[i].goodsData.name == goodsData.name)
            {
                bagModel.GoodsDatas[i].num++;
                AddBagItem();
                return;
            }
        }
        BagData bagData = new BagData();
        bagData.num = num;
        bagData.goodsData = goodsData;
        bagModel.GoodsDatas.Add(bagData);
        AddBagItem();
    }

    public void Classiyf(string type)
    {
        List<BagData> goodsData = new List<BagData>();
        foreach (var item in bagModel.GoodsDatas)
        {
            if (item.goodsData.inventoryType == type)
            {
                goodsData.Add(item);
            }
        }
        UpdateBag(goodsData);
    }
    public void AddBagCell(Transform bagcell)
    {

        for (int i = 0; i < bagModel.BagcellNum; i++)
        {
            GameObject cell = GameObject.Instantiate(Resources.Load<GameObject>("Cell"), bagcell);
            bagModel.Bagcells.Add(cell.transform);
        }
    }
    public void AddBagItem()
    {
        for (int i = 0; i < bagModel.GoodsDatas.Count; i++)
        {
            GameObject item = GameObject.Instantiate(Resources.Load<GameObject>("Item"), bagModel.Bagcells[i]);
            item.GetComponent<BagItem>().Init(bagModel.GoodsDatas[i].goodsData, bagModel.GoodsDatas[i].num);
            // item.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + bagModel.GoodsDatas[i].goodsData.icon);
            bagModel.Bagitem.Add(item);
        }


    }
    public void SellGoods(GoodsData goodsData)
    {
        for (int i = 0; i < bagModel.GoodsDatas.Count; i++)
        {
            if (bagModel.GoodsDatas[i].goodsData.name == goodsData.name)
            {

                if (bagModel.GoodsDatas[i].num > 1)
                {

                    bagModel.GoodsDatas[i].num--;
                    Debug.Log("ÊýÁ¿");
                }
                else
                {
                    GameObject.Destroy(bagModel.Bagitem[i].gameObject);
                    bagModel.GoodsDatas.Remove(bagModel.GoodsDatas[i]);
                }

            }
        }
        UpdataBag();
        Debug.Log(bagModel.GoodsDatas.Count);
    }



    public void UpdateBag(List<BagData> goodsDatas)
    {
        for (int i = 0; i < bagModel.Bagcells.Count; i++)
        {
            if (bagModel.Bagcells[i].childCount !=0)
            {
                GameObject.Destroy(bagModel.Bagcells[i].GetChild(0).gameObject); 
            }
        }
        //if (goodsDatas.Count>0)
        //{
        //    for (int i = 0; i < goodsDatas.Count; i++)
        //    {
        //        GameObject item = GameObject.Instantiate(Resources.Load<GameObject>("Item"), bagModel.Bagcells[i]);
        //        item.GetComponent<BagItem>().Init(goodsDatas[i].goodsData, goodsDatas[i].num);
        //        bagModel.Bagitem.Add(item);
        //    }
        //}
        
    }
    public void UpdataBag()
    {
        for (int i = 0; i < bagModel.Bagcells.Count; i++)
        {
            if (bagModel.Bagcells[i].childCount > 0)
            {
                GameObject.Destroy(bagModel.Bagcells[i].GetChild(0).gameObject);
            }
        }

        for (int i = 0; i < bagModel.GoodsDatas.Count; i++)
        {
            GameObject item = GameObject.Instantiate(Resources.Load<GameObject>("Item"), bagModel.Bagcells[i]);
            item.GetComponent<BagItem>().Init(bagModel.GoodsDatas[i].goodsData, bagModel.GoodsDatas[i].num);
            // item.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + bagModel.GoodsDatas[i].goodsData.icon);
            bagModel.Bagitem.Add(item);
        }
    }
    public void CloseBag()
    {
        SendNotification(BagFacade.MODELCLOSEBAG);
    }
}
