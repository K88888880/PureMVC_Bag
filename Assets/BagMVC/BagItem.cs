using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class BagItem : MonoBehaviour,IPointerClickHandler
{
    public Text num;
    GoodsData goods;
    public void Init(GoodsData goodsData,int n)
    {
        goods=goodsData;    
        GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + goodsData.icon);
        num .text= n.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button==PointerEventData.InputButton.Right)
        {
            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Bag"))
            {
                BagFacade.GetInstance().SendNotification(BagFacade.SHOWBAGGOODSHINT, goods);
                
            }
             
        }
    }
}
