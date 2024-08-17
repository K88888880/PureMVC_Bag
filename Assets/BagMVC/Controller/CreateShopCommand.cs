using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShopCommand : PureMVC.Patterns.SimpleCommand
{



    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        ShopProxy shopProxy=BagFacade.GetInstance().RetrieveProxy(ShopProxy.NAME)as ShopProxy;
        if (shopProxy!=null)
        {
            shopProxy.CreateShopCell(notification.Body as Transform);
            shopProxy.CretateItem();
        }
    }

}
