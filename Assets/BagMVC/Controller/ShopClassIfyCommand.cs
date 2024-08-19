using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClassIfyCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        ShopProxy shopProxy=Facade.RetrieveProxy(ShopProxy.NAME) as ShopProxy;
        //商城装备分类
        switch (notification.Body)
        {
            case "全部":
                shopProxy.ShowAll( );
                break;
            case "装备":
                shopProxy.Classify("装备");
                break;
            case "药品":
                shopProxy.Classify("药品");
                break;
            case "宝箱":
                shopProxy.Classify("宝箱");
                break;
        }
    }
}
