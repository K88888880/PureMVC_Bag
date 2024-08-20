using PureMVC.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellHintMediator : PureMVC.Patterns.Mediator
{
    public new static string NAME = "SellHintMediator";
    SellHintView hintView;
    GoodsData goods1;
    public SellHintMediator(object obj,GoodsData goods):base(NAME)
    {
        hintView=((GameObject)obj).GetComponent<SellHintView>();
        hintView.selbut.onClick.AddListener(SellGoods);
        goods1 = goods;
    }

    private void SellGoods()
    {
        SendNotification(BagFacade.SELLGOODSGOLD, goods1);
        hintView.gameObject.SetActive(false);
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(BagFacade.ACTIVESELL);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        switch (notification.Name)
        {
            case BagFacade.ACTIVESELL:
                hintView.gameObject.SetActive(true);
                 goods1 =notification.Body as GoodsData;    
                break;
        }
    }
}
