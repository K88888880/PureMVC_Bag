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
        if (bagMediator == null)
        {
            GameObject bag = GameObject.Instantiate(Resources.Load<GameObject>("BagPanel"));
            bagMediator = new BagMediator(bag);
            Facade.RegisterMediator(bagMediator);
        }
    }
}
