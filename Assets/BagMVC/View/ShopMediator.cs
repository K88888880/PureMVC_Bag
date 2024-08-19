using PureMVC.Interfaces;
using System;
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
        bagView.shopbut.onClick.AddListener(OpenShop);
        bagView.shopclose.onClick.AddListener(CloseShop);
        bagView.all.onClick.AddListener(All);
        bagView.equip.onClick.AddListener(Equip);
        bagView.drug.onClick.AddListener(Drug);
        bagView.treasureBox.onClick.AddListener(TreasureBox);
    }
    /// <summary>
    /// ��ʾȫ��
    /// </summary>
    private void All()
    {
        SendNotification(BagFacade.CLASSIFY, "ȫ��");
    }
    /// <summary>
    /// ��ʾװ��
    /// </summary>
    private void Equip()
    {
        SendNotification(BagFacade.CLASSIFY, "װ��");
    }
    /// <summary>
    /// ��ʾҩƷ
    /// </summary>
    private void Drug()
    {
        SendNotification(BagFacade.CLASSIFY, "ҩƷ");
    }
    /// <summary>
    /// ��ʾ����
    /// </summary>
    private void TreasureBox()
    {
        SendNotification(BagFacade.CLASSIFY, "����");
    }

    /// <summary>
    /// �򿪱���
    /// </summary>
    void OpenShop()
    {
        bagView.shop.SetActive(true);
    }
    /// <summary>
    /// �رձ���
    /// </summary>
    void CloseShop()
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
