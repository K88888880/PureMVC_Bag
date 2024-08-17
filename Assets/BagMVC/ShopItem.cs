using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    
    public void Init(GoodsData goodsData)
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + goodsData.icon);
    }
}
