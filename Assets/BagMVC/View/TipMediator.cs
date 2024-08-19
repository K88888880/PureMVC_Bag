using PureMVC.Core;
using PureMVC.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TipMediator : PureMVC.Patterns.Mediator
{
    public new static string NAME = "TipMediator";

    TipView tipView;
    GoodsData goodsData;
    TipModel model;
    public TipMediator(object obj) : base(NAME)
    {
        
        model = new TipModel();
        tipView = ((GameObject)(obj)).GetComponent<TipView>();
        tipView.close.onClick.AddListener(ClosePanel);
        tipView.addbut.onClick.AddListener(AddNum);
        tipView.subbut.onClick.AddListener(SubNum);
        tipView.confirm.onClick.AddListener(Buy);
    }

    private void Buy()
    {
        SendNotification(BagFacade.BUYGOODSNUM, goodsData,"D");
        tipView.buypanel.SetActive(false);

    }

    private void SubNum()
    {
        SendNotification(BagFacade.BUYGOODSNUM, goodsData,"Add");
    }

    private void AddNum()
    {
        SendNotification(BagFacade.BUYGOODSNUM, goodsData, "Sub");
    }

    void ClosePanel()
    {
        tipView.buypanel.SetActive(false);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(BagFacade.TIPDATA);
        list.Add(BagFacade.ADDGOODSNUM);
        list.Add(BagFacade.SUBGOODSNUM);
        list.Add(BagFacade.ACTIVETIP);
        list.Add(BagFacade.SHOWGOLD);
        return list;
    }



    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        switch (notification.Name)
        {
            case BagFacade.TIPDATA:
                goodsData = notification.Body as GoodsData;
                if (goodsData != null)
                {
                    tipView.icon.sprite = Resources.Load<Sprite>("icon/" + goodsData.icon);
                    tipView.Nmae.text = goodsData.name;
                }
                break;

            case BagFacade.ADDGOODSNUM:
                tipView.Num.text = notification.Body.ToString();
                break;

            case BagFacade.SUBGOODSNUM:
                tipView.Num.text = notification.Body.ToString();
                break;

            case BagFacade.ACTIVETIP:
                tipView.buypanel.SetActive(true);
                goodsData = notification.Body as GoodsData;
                if (goodsData != null)
                {
                    tipView.icon.sprite = Resources.Load<Sprite>("icon/" + goodsData.icon);
                    tipView.Nmae.text = goodsData.name;
                }
                break;
            case BagFacade.SHOWGOLD:
                tipView.goldnum.text= notification.Body.ToString(); 
                break;
        }
    }
}
