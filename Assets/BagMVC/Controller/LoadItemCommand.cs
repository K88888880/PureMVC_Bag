using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItemCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        BagProxy bagProxy = Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;
        
            bagProxy.AddGoods((int)(notification.Body as List<object>)[0], (notification.Body as List<object>)[1] as GoodsData);
         
    }
}
