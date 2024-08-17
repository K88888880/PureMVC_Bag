using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFacade_ : PureMVC.Patterns.Facade
{
    public const string PLAY = "PLAY";
    public const string BUTSENDTIME = "BUTSENDTIME";
    public const string MODELSENDTIME = "MODELSENDTIME";





    /// <summary>
    /// 静态初始化 
    /// </summary>
    static StartFacade_()
    {
        m_instance = new StartFacade_();
    }
    /// <summary>
    /// 获取单例
    /// </summary>
    public static StartFacade_ GetInstance()
    {
        return m_instance as StartFacade_;  
    }


    public void Start()
    {
        //通过command命令启动游戏
        SendNotification(PLAY);
    }
    /// <summary>
    /// 注册控制(命令消息 与控制层类的对应关系，建立绑定)
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(PLAY,typeof(PanelCommand_));
        RegisterCommand(BUTSENDTIME, typeof(ModelCommand_));
    }
    /// <summary>
    /// 注册Model
    /// </summary>
    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new PanelProxy_(PanelProxy_.NAME));
        
    }
    /// <summary>
    /// 注册视层
    /// </summary>
    protected override void InitializeView()
    {
        base.InitializeView();

    }
    /// <summary>
    /// 注册Proxy
    /// </summary>
    protected override void InitializeFacade()
    {
        base.InitializeFacade();
    }
}
