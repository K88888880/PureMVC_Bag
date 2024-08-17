using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCommand_ : PureMVC.Patterns.SimpleCommand
{
    /// <summary>
    /// 执行方法
    /// </summary>
    /// <param name="notification"></param>
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        PanelMediator_ panelMediator_ = Facade.RetrieveMediator(PanelMediator_.NAME) as PanelMediator_;
        if (panelMediator_ == null)
        {
            //创建UI
            GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>("Canvas"));
            panelMediator_ = new PanelMediator_(panel);
            Facade.RegisterMediator(panelMediator_);
        }
    }
}
