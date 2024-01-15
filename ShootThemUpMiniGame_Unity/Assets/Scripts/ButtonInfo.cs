using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonInfo : MonoBehaviour
{
    public int itemID;
    public Text priceText, quantityText;
    public GameObject shopManager;

    private void Update()
    {
        priceText.text = shopManager.GetComponent<ShopManagerScript>().shopItens[2, itemID].ToString();
        quantityText.text = shopManager.GetComponent<ShopManagerScript>().shopItens[3, itemID].ToString();
    }
}
