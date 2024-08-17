using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame_ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Æô¶¯¿ò¼Ü
        StartFacade_.GetInstance().Start();
    }
}
