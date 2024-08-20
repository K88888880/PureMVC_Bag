using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellGoodsCommand_ : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        MainProXY mainProXY = Facade.RetrieveProxy(MainProXY.NAME) as MainProXY;
        BagProxy bagProxy=Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;
        
        GoodsData goodsData = notification.Body as GoodsData;
        Debug.Log(goodsData.name);
        bagProxy.SellGoods(goodsData);
        int golad = int.Parse(goodsData.sale);
        mainProXY.AddGold(golad);
    }
}
