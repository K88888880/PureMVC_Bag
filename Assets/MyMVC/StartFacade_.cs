using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFacade_ : PureMVC.Patterns.Facade
{
    public const string PLAY = "PLAY";
    public const string BUTSENDTIME = "BUTSENDTIME";
    public const string MODELSENDTIME = "MODELSENDTIME";





    /// <summary>
    /// ��̬��ʼ�� 
    /// </summary>
    static StartFacade_()
    {
        m_instance = new StartFacade_();
    }
    /// <summary>
    /// ��ȡ����
    /// </summary>
    public static StartFacade_ GetInstance()
    {
        return m_instance as StartFacade_;  
    }


    public void Start()
    {
        //ͨ��command����������Ϸ
        SendNotification(PLAY);
    }
    /// <summary>
    /// ע�����(������Ϣ ����Ʋ���Ķ�Ӧ��ϵ��������)
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(PLAY,typeof(PanelCommand_));
        RegisterCommand(BUTSENDTIME, typeof(ModelCommand_));
    }
    /// <summary>
    /// ע��Model
    /// </summary>
    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new PanelProxy_(PanelProxy_.NAME));
        
    }
    /// <summary>
    /// ע���Ӳ�
    /// </summary>
    protected override void InitializeView()
    {
        base.InitializeView();

    }
    /// <summary>
    /// ע��Proxy
    /// </summary>
    protected override void InitializeFacade()
    {
        base.InitializeFacade();
    }
}
