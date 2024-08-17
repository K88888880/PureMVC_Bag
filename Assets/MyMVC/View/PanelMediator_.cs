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
        //获取视图层
        panelView = ((GameObject)(obj)).GetComponent<PanelView_>();
       //按钮侦听
        panelView.button.onClick.AddListener(() =>
        {
            SendNotification(StartFacade_.BUTSENDTIME);
        });
    }

    /// <summary>
    /// 事件监听
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        //添加消息
        list.Add(StartFacade_.MODELSENDTIME);
        return list;    
    }

    /// <summary>
    /// 监听消息
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        //根据具体消息来显示相应的UI
        switch(notification.Name)
        {
            case StartFacade_.MODELSENDTIME:
                panelView.text.text=notification.Body.ToString();   
                break;
        }
    }

}
