using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagClassifyCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        BagProxy bagProxy=Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;

        switch (notification.Type)
        {
            case "All":
                bagProxy.UpdataBag();
                break;
            case "Equip":
                bagProxy.Classiyf("×°±¸");
                break;
            case "Durg":
                bagProxy.Classiyf("Ò©Æ·");
                break;
            case "Box":
                bagProxy.Classiyf("±¦Ïä");
                break;
        }
    }
}
