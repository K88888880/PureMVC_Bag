using PureMVC.Core;
using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Command : PureMVC.Patterns.SimpleCommand
{

    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        MainProXY mainProXY=Facade.RetrieveProxy(MainProXY.NAME) as  MainProXY;
        SendNotification(BagFacade.INITMAINGOLD, mainProXY. model.Gold);
        SendNotification(BagFacade.INITMAINJEWEL, mainProXY.model.Jewel1);
        
    }
}
