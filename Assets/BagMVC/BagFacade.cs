using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagFacade : PureMVC.Patterns.Facade
{
    public const string INITMAIN = "INITMAIN";
    public const string INITMAINGOLD = "INITMAINGOLD";
    public const string INITMAINJEWEL = "INITMAINJEWEL";
    public const string PLAYBAG = "PLAYBAG";
    public const string CREATEBAG = "CREATEBAG";
    public const string CLOSEBAG = "CLOSEBAG";
    public const string OPENBAG = "OPENBAG";
    public const string MODELCLOSEBAG = "MODELCLOSEBAG";
    public const string CREATESHOP = "CREATESHOP";
    public const string BUYSHOPGOODS = "BUYSHOPGOODS";
    public const string TIPDATA = "TIPDATA";
    public const string BUYGOODSNUMADD = "BUYGOODSNUMADD";
    public const string BUYGOODSNUMSUB = "BUYGOODSNUMSUB";
    public const string BUYGOODSNUMCON = "BUYGOODSNUMCON";
    public const string BUYGOODSNUM = "BUYGOODSNUM";

    public const string ADDGOODSNUM = "ADDGOODSNUM";
    public const string SUBGOODSNUM = "SUBGOODSNUM";
    public const string BUYNUM = "BUYNUM";
    public const string LOADITEM = "LOADITEM";
    public const string ACTIVETIP = "ACTIVETIP";
    public const string CLASSIFY = "CLASSIFY";
    public const string SHOWGOLD = "SHOWGOLD";
    public const string SHOWHINT = "SHOWHINT";
    public const string HINTACTIVE = "HINTACTIVE";
    public const string SHOWBAGGOODSHINT = "SHOWBAGGOODSHINT";
    public const string ACTIVESELL = "ACTIVESELL";
    public const string SELLGOODSGOLD = "SELLGOODSGOLD";
    public const string BAGCLASSIFY = "BAGCLASSIFY";



    




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
        SendNotification(INITMAIN);
         
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
        RegisterCommand(BUYSHOPGOODS, typeof(CreateTipCommand));
        RegisterCommand(BUYGOODSNUM, typeof(BuyNumCommand));
        RegisterCommand(LOADITEM, typeof(LoadItemCommand));
        RegisterCommand(CLASSIFY, typeof(ShopClassIfyCommand));
        RegisterCommand(INITMAIN, typeof(Main_Command));
        RegisterCommand(SHOWHINT, typeof(HintCommand));
        RegisterCommand(SHOWBAGGOODSHINT, typeof(SellHintCommand));
        RegisterCommand(SELLGOODSGOLD, typeof(SellGoodsCommand_));
        RegisterCommand(BAGCLASSIFY, typeof(BagClassifyCommand));
    }
    /// <summary>
    /// ×¢²áModel
    /// </summary>
    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new BagProxy(BagProxy.NAME));
        RegisterProxy(new ShopProxy(ShopProxy.NAME));
        RegisterProxy(new TipProxy(TipProxy.NAME));
        RegisterProxy(new MainProXY(MainProXY.NAME));

    }


    protected override void InitializeView()
    {
        base.InitializeView();
    }
}
