using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClassIfyCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        ShopProxy shopProxy=Facade.RetrieveProxy(ShopProxy.NAME) as ShopProxy;
        //�̳�װ������
        switch (notification.Body)
        {
            case "ȫ��":
                shopProxy.ShowAll( );
                break;
            case "װ��":
                shopProxy.Classify("װ��");
                break;
            case "ҩƷ":
                shopProxy.Classify("ҩƷ");
                break;
            case "����":
                shopProxy.Classify("����");
                break;
        }
    }
}
