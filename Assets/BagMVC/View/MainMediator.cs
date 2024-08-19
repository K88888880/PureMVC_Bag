using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMediator : PureMVC.Patterns.Mediator
{

    public new static string NAME = "MainMediator";

    BagView bagView;
  
    public MainMediator(object obj) : base(NAME)
    {
        bagView=((GameObject)(obj)).GetComponent<BagView>();
       
    }


    public override IList<string> ListNotificationInterests()
    {
      IList<string> list = new List<string>();
        list.Add(BagFacade.INITMAINGOLD);
        list.Add(BagFacade.INITMAINJEWEL);

        return list;

    }


    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        //UIœ‘ æ
        switch (notification.Name)
        {
            case BagFacade.INITMAINGOLD:
                bagView.gold.text= notification.Body.ToString();
                break;
            case BagFacade.INITMAINJEWEL:
                bagView.Jewel.text = notification.Body.ToString();
                break;
        }

    }
}
