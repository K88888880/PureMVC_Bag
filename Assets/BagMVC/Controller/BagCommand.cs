using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCommand : PureMVC.Patterns.SimpleCommand
{
    /// <summary>
    /// z÷¥––
    /// </summary>
    /// <param name="notification"></param>
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        BagMediator bagMediator = Facade.RetrieveMediator(BagMediator.NAME) as BagMediator;
        ShopMediator shopMediator = Facade.RetrieveMediator(ShopMediator.NAME) as ShopMediator;
        MainMediator mainPanel = Facade.RetrieveMediator(MainMediator.NAME) as MainMediator;
        if (bagMediator == null)
        {
            GameObject bag = GameObject.Instantiate(Resources.Load<GameObject>("MainPanel"));
            bagMediator = new BagMediator(bag);
            shopMediator = new ShopMediator(bag);
            mainPanel = new MainMediator(bag);
            Facade.RegisterMediator(bagMediator);
            Facade.RegisterMediator(shopMediator);
            Facade.RegisterMediator(mainPanel);
        }
    }
}
