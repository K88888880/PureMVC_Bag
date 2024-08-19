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
    /// 显示全部
    /// </summary>
    private void All()
    {
        SendNotification(BagFacade.CLASSIFY, "全部");
    }
    /// <summary>
    /// 显示装备
    /// </summary>
    private void Equip()
    {
        SendNotification(BagFacade.CLASSIFY, "装备");
    }
    /// <summary>
    /// 显示药品
    /// </summary>
    private void Drug()
    {
        SendNotification(BagFacade.CLASSIFY, "药品");
    }
    /// <summary>
    /// 显示宝箱
    /// </summary>
    private void TreasureBox()
    {
        SendNotification(BagFacade.CLASSIFY, "宝箱");
    }

    /// <summary>
    /// 打开背包
    /// </summary>
    void OpenShop()
    {
        bagView.shop.SetActive(true);
    }
    /// <summary>
    /// 关闭背包
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
