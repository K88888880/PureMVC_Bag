using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelProxy_ : PureMVC.Patterns.Proxy
{
    public new static string NAME = "PanelProxy_";

    private string time;
    public string Time { get => time; }
    public PanelProxy_(string name):base(NAME)
    {

    }
    /// <summary>
    /// …Ë÷√ ±º‰
    /// </summary>
    public void SetTime()
    {
        time=System.DateTime.Now.ToString();
        SendNotification(StartFacade_.MODELSENDTIME, time); 
    }

}
