using PureMVC.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPanelMediator : PureMVC.Patterns.Mediator
{
    public new static string NAME = "HintPanelMediator";

    HintPanelView hintPanelView;
    public HintPanelMediator(object obj):base(NAME)
    {
        hintPanelView=((GameObject)obj).GetComponent<HintPanelView>();
        hintPanelView.confirm.onClick.AddListener(Close);
    }
    /// <summary>
    /// ¹Ø±Õµ¯´°
    /// </summary>
    private void Close()
    {
         hintPanelView.gameObject.SetActive(false); 
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(BagFacade.HINTACTIVE);
        return list;
    }



    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        switch (notification.Name)
        {
            case BagFacade.HINTACTIVE:
              hintPanelView.gameObject.SetActive(true);
                break;
        }
    }


}
