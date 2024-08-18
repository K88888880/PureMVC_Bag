using PureMVC.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipProxy : PureMVC.Patterns.Proxy
{
    public new static string NAME = "TipProxy";

    TipModel model;
    public TipProxy(string name):base(NAME)
    {
        model=new TipModel();


    }


    public void AddNum(int n)
    {
         
        model.Num += n;
        model.Num = Mathf.Clamp(model.Num, 1, 10);
        SendNotification(BagFacade.ADDGOODSNUM, model.Num);
    }

    public void SubNum(int n)
    {
        
        model.Num -= n;
        model.Num = Mathf.Clamp(model.Num, 1, 10);
        SendNotification(BagFacade.SUBGOODSNUM, model.Num);
    }

}
