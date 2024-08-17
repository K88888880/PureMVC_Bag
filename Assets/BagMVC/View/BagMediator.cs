using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMediator : PureMVC.Patterns.Mediator
{
    public new static string NAME = "BagMediator";

    public BagView bagView;
     BagProxy bagProxy;
    public BagMediator(object obj):base(NAME)
    {
        //��ȡBagView
        bagView = ((GameObject)(obj)).GetComponent<BagView>();
        // bagProxy = Facade.RetrieveProxy(BagProxy.NAME) as BagProxy;
        // bagProxy.AddBagCell(bagView.bagitemcellparent);
        // bagProxy.AddBagItem();
        //����Ϣ�������
        bagView.close.onClick.AddListener(CloseBag);
        bagView.openbut.onClick.AddListener(OpenBag);
        SendNotification(BagFacade.CREATEBAG, bagView.bagitemcellparent);
         
    }

    /// <summary>
    /// �رձ���
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
        return list;
    }


    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        switch(notification.Name)
        {
            case BagFacade.MODELCLOSEBAG:
                bagView.bag.SetActive(false);
                break;
        }
    }
}
