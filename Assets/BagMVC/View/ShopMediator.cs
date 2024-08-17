using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMediator : PureMVC.Patterns.Mediator
{
    public new static string NAME = "ShopMediator";
    BagView bagView;
    public ShopMediator(object obj) : base(NAME)
    {
        bagView=((GameObject)(obj)).GetComponent<BagView>();
        SendNotification(BagFacade.CREATESHOP, bagView.shopitemcellparent);
        bagView.shopbut.onClick.AddListener(OpenBag);
        bagView.shopclose.onClick.AddListener(CloseBag);
    }

    void OpenBag()
    {
        bagView.shop.SetActive(true);
    }
    void CloseBag()
    {
        bagView.shop.SetActive(false);
    }

    public override IList<string> ListNotificationInterests()
    {
        return base.ListNotificationInterests();
    }


    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);

    }
}
