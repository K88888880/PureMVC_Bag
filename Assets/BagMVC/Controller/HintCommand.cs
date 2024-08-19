using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCommand : PureMVC.Patterns.SimpleCommand
{
    GameObject g;
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        HintPanelMediator hintPanelMediator = Facade.RetrieveMediator(HintPanelMediator.NAME) as HintPanelMediator;
        if (hintPanelMediator == null)
        {
            g = GameObjectUtility.Instance.CreateHint("HintPanel", null);
            hintPanelMediator = new HintPanelMediator(g);
            Facade.RegisterMediator(hintPanelMediator);

        }
        else
        {
            SendNotification(BagFacade.HINTACTIVE);
        }
         


    }
}
