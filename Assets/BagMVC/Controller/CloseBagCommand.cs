using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBagCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        BagProxy bagProxy=Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;  
        bagProxy.CloseBag();
    }
}
