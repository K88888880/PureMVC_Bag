using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class ShopItem : MonoBehaviour,IPointerClickHandler
{
    public Image image;
    GoodsData goods;
    public void Init(GoodsData goodsData)
    {
        goods= goodsData;   
        GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + goodsData.icon);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag=="Shop")
        {
           
            BagFacade.GetInstance().SendNotification(BagFacade.BUYSHOPGOODS, goods);
        }
    }
}
