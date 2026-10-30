using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ItemDetails : MonoBehaviour, ISelectHandler
{
    public int buttonIndex;
    public int price;
    private bool bought = false;

    private FishList fL;
    private ShopScript shop;

    [TextArea(3, 10)]
    public string ItemDesc;

    public TextMeshProUGUI displayText;

    private void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
        shop = GameObject.FindWithTag("shop").GetComponent<ShopScript>();
    }

    public void ButtonClick()
    {

        if (fL.fishCaught < price)
        {
            Debug.Log("brokie");
            return;            
        }
        else
        {
            fL.fishCaught = fL.fishCaught - price;

        }

        if (bought == false)
        {
            shop.ButtonEffect(buttonIndex);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        displayText.text = ItemDesc;
    }

}
