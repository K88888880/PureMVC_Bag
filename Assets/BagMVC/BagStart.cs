using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BagFacade.GetInstance().Start();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
