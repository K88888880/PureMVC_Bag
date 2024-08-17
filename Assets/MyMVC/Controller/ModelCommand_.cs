using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCommand_ : PureMVC.Patterns.SimpleCommand
{

    /// <summary>
    /// ִ��
    /// </summary>
    /// <param name="notification"></param>
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        PanelProxy_ panelProxy_=Facade.RetrieveProxy(PanelProxy_.NAME) as PanelProxy_;
        if (panelProxy_!=null)
        {
            //����Model����в���
            panelProxy_.SetTime();

        }

    }
}
