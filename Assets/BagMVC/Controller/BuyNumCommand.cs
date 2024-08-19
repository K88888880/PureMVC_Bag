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
        MainProXY mainProXY = Facade.RetrieveProxy(MainProXY.NAME) as MainProXY;
        //判断购买数量是加还是减
        if (notification.Type.ToString() == "Add")
        {
            tipProxy.AddNum(1);
            GoodsData goodsData = notification.Body as GoodsData;
            int n = int.Parse(goodsData.sale) * tipProxy.model.Num;
            SendNotification(BagFacade.SHOWGOLD, n);
        }
        else if (notification.Type.ToString() == "Sub")
        {
            tipProxy.SubNum(1);
            GoodsData goodsData = notification.Body as GoodsData;
            int n = int.Parse(goodsData.sale) * tipProxy.model.Num;
            SendNotification(BagFacade.SHOWGOLD, n);
        }
        else
        {
            //购买时判断金币是否充足
            GoodsData goodsData = notification.Body as GoodsData;
            int n = int.Parse(goodsData.sale) * tipProxy.model.Num;
            if (mainProXY.model.Gold < n)
            {
                Debug.Log("金币不足");
                SendNotification(BagFacade.SHOWHINT);    
                return;
            }
            //金币充足时再执行购买逻辑
            tipProxy.BuyGoodsNum(notification.Body as GoodsData);
            mainProXY.SubGold(n);

        }

    }
}
