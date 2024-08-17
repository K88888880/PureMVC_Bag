using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMediator_ : PureMVC.Patterns.Mediator
{
    public new static string NAME = "PanelMediator_";


    PanelView_ panelView;
    public PanelMediator_(object obj) : base(NAME)
    {
        //��ȡ��ͼ��
        panelView = ((GameObject)(obj)).GetComponent<PanelView_>();
       //��ť����
        panelView.button.onClick.AddListener(() =>
        {
            SendNotification(StartFacade_.BUTSENDTIME);
        });
    }

    /// <summary>
    /// �¼�����
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        //�����Ϣ
        list.Add(StartFacade_.MODELSENDTIME);
        return list;    
    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        //���ݾ�����Ϣ����ʾ��Ӧ��UI
        switch(notification.Name)
        {
            case StartFacade_.MODELSENDTIME:
                panelView.text.text=notification.Body.ToString();   
                break;
        }
    }

}
