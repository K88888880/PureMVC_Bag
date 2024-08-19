using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

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
        BagData bagData = new BagData();
        bagData.num = num;
        bagData.goodsData = goodsData;
        bagModel.GoodsDatas.Add(bagData);
        AddBagItem( );
    }

    public void AddBagCell(Transform bagcell)
    {

        for (int i = 0; i < bagModel.BagcellNum; i++)
        {
            GameObject cell = GameObject.Instantiate(Resources.Load<GameObject>("Cell"), bagcell);
            bagModel.Bagcells.Add(cell.transform);
        }
    }
    public void AddBagItem( )
    {
       
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
