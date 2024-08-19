using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyNumCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        TipProxy tipProxy = Facade.RetrieveProxy(TipProxy.NAME) as TipProxy;
        //�жϹ��������Ǽӻ��Ǽ�
        if (notification.Body.ToString() == "Add")
        {
            tipProxy.AddNum(1);

        }
        else if (notification.Body.ToString() == "Sub")
        {
            tipProxy.SubNum(1);
        }
        else
        {
            tipProxy.BuyGoodsNum(notification.Body as GoodsData);





        }
    }
}
