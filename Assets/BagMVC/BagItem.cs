using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItem : MonoBehaviour
{
    public Text num;
    public void Init(GoodsData goodsData,int n)
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + goodsData.icon);
        num .text= n.ToString();
    }
}
