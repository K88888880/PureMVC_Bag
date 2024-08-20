using PureMVC.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMediator : PureMVC.Patterns.Mediator
{
    public new static string NAME = "BagMediator";

    public BagView bagView;
    BagProxy bagProxy;
    public BagMediator(object obj) : base(NAME)
    {
        //获取BagView
        bagView = ((GameObject)(obj)).GetComponent<BagView>();
        // bagProxy = Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;
        // bagProxy.AddBagCell(bagView.bagitemcellparent);
        // bagProxy.AddBagItem();
        //发消息给命令层
        bagView.close.onClick.AddListener(CloseBag);
        bagView.openbut.onClick.AddListener(OpenBag);
        SendNotification(BagFacade.CREATEBAG, bagView.bagitemcellparent);
        bagView.bagall.onClick.AddListener(All);
        bagView.bagequip.onClick.AddListener(Equip);
        bagView.bagdrug.onClick.AddListener(Durg);
        bagView.bagtreasureBox.onClick.AddListener(Box);
    }

    private void All()
    {
        SendNotification(BagFacade.BAGCLASSIFY, "1", "All");

    }

    private void Equip()
    {
        SendNotification(BagFacade.BAGCLASSIFY, "1", "Equip");

    }

    private void Durg()
    {
        SendNotification(BagFacade.BAGCLASSIFY, "1", "Durg");

    }

    private void Box()
    {
        SendNotification(BagFacade.BAGCLASSIFY, "1", "Box");
    }

    /// <summary>
    /// 关闭背包
    /// </summary>
    void CloseBag()
    {
        bagView.bag.gameObject.SetActive(false);
    }
    void OpenBag()
    {
        bagView.bag.gameObject.SetActive(true);
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(BagFacade.MODELCLOSEBAG);
        list.Add(BagFacade.BUYNUM);
        return list;
    }


    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        switch (notification.Name)
        {
            case BagFacade.MODELCLOSEBAG:
                bagView.bag.SetActive(false);
                break;
            case BagFacade.BUYNUM:
                //Debug.Log((notification.Body as List<object>)[0]);
                //Debug.Log(((notification.Body as List<object>)[1] as GoodsData).icon);
                SendNotification(BagFacade.LOADITEM, (notification.Body as List<object>));
                break;
        }
    }
}
