using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTipCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        TipMediator tipMediator = Facade.RetrieveMediator(TipMediator.NAME) as TipMediator;
        if (tipMediator == null)
        {
            GameObject tip = GameObject.Instantiate(Resources.Load<GameObject>("BuyGoods"));
            tipMediator=new TipMediator(tip);
            Facade.RegisterMediator(tipMediator);
            SendNotification(BagFacade.TIPDATA, notification.Body);
        }

        
    }
}
