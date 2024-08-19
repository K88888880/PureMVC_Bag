using PureMVC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MainProXY : PureMVC.Patterns.Proxy
{
    public new static string NAME = "MainProXY";
  public  MainModel model;
    public MainProXY(string name):base(NAME)
    {
        model = new MainModel();
        model.Gold = 10000;
        model.Jewel1 = 10000;
    }
    /// <summary>
    /// �ӽ��
    /// </summary>
    /// <param name="n"></param>
    public void AddGold(int n)
    {
        model.Gold += n;
        SendNotification(BagFacade.INITMAINGOLD, model.Gold);
    }
    /// <summary>
    /// �����
    /// </summary>
    /// <param name="n"></param>
    public void SubGold(int n)
    {
        model.Gold -= n;
        SendNotification(BagFacade.INITMAINGOLD, model.Gold);
    }
    /// <summary>
    /// ����ʯ
    /// </summary>
    /// <param name="n"></param>
    public void AddJewel(int n)
    {
        model.Jewel1 += n;

        SendNotification(BagFacade.INITMAINGOLD, model.Jewel1);
       
         
    }
    /// <summary>
    /// ����ʯ
    /// </summary>
    /// <param name="n"></param>
    public void SubJewel(int n)
    {
        model.Jewel1 -= n;
        SendNotification(BagFacade.INITMAINJEWEL, model.Jewel1);
    }
}
