using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellHintCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        SellHintMediator sellHintMediator = Facade.RetrieveMediator(SellHintMediator.NAME) as SellHintMediator;
        if (sellHintMediator == null)
        {
            GameObject sel = GameObjectUtility.Instance.CreateHint("SELL");
            sellHintMediator = new SellHintMediator(sel,notification.Body as GoodsData);
            
            Facade.RegisterMediator(sellHintMediator);
        }
        else
        {
             
            SendNotification(BagFacade.ACTIVESELL, notification.Body);
        }

    }
}
