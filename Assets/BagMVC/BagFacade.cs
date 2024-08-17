using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagFacade : PureMVC.Patterns.Facade
{
    public const string PLAYBAG = "PLAYBAG";
    public const string CREATEBAG = "CREATEBAG";
    public const string CLOSEBAG = "CLOSEBAG";
    public const string OPENBAG = "OPENBAG";
    public const string MODELCLOSEBAG = "MODELCLOSEBAG";
    public const string CREATESHOP = "CREATESHOP";




    /// <summary>
    /// ¾²Ì¬³õÊ¼»¯
    /// </summary>
    static BagFacade()
    {
        m_instance = new BagFacade();
    }
    /// <summary>
    /// »ñÈ¡µ¥Àý
    /// </summary>
    /// <returns></returns>
    public static BagFacade GetInstance()
    {
        return m_instance as BagFacade; 
    }


    public void Start()
    {
        SendNotification(PLAYBAG);
    }

    /// <summary>
    /// ×¢²áÃüÁî
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(PLAYBAG, typeof(BagCommand));
        RegisterCommand(CREATEBAG, typeof(CreateCommand));
        RegisterCommand(CLOSEBAG, typeof(CloseBagCommand));
        RegisterCommand(CREATESHOP, typeof(CreateShopCommand));
    }
    /// <summary>
    /// ×¢²áModel
    /// </summary>
    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new BagProxy(BagProxy.NAME));
        RegisterProxy(new ShopProxy(ShopProxy.NAME));
    }


    protected override void InitializeView()
    {
        base.InitializeView();
    }
}
