using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItens = new int[5, 5];
    public Text XpAvaibleText;
    private void FixedUpdate()
    {
        XpAvaibleText.text = "XP Avaible: " + GameController.gameController.xpTotal.ToString();
        // ID's
        shopItens[1, 1] = 1;
        shopItens[1, 2] = 2;
        shopItens[1, 3] = 3;
        shopItens[1, 4] = 4;
        // Price
        //int price_ = GetComponent<ButtonInfo>().price;

        shopItens[2, 1] = 5;
        shopItens[2, 2] = 10;
        shopItens[2, 3] = 15;
        shopItens[2, 4] = 20;
        //Quantity
        //int quantity_ = GetComponent<ButtonInfo>().quantidade;
        shopItens[3, 1] = GameController.gameController.quantidadePowerUP[0];
        shopItens[3, 2] = GameController.gameController.quantidadePowerUP[1];
        shopItens[3, 3] = GameController.gameController.quantidadePowerUP[2]; 
        shopItens[3, 4] = GameController.gameController.quantidadePowerUP[3];
    }
    
    public void BuyItens() 
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (GameController.gameController.xpTotal >= shopItens[2, buttonRef.GetComponent<ButtonInfo>().itemID]) 
        {
            GameController.gameController.xpTotal -= shopItens[2, buttonRef.GetComponent<ButtonInfo>().itemID];
            shopItens[3, buttonRef.GetComponent<ButtonInfo>().itemID]++;
            XpAvaibleText.text = "XP Avaible: " + GameController.gameController.xpTotal.ToString();
            buttonRef.GetComponent<ButtonInfo>().quantityText.text = shopItens[3, buttonRef.GetComponent<ButtonInfo>().itemID].ToString();
            GameController.gameController.quantidadePowerUP[0] = GetComponent<ShopManagerScript>().shopItens[3, 1];
            GameController.gameController.quantidadePowerUP[1] = GetComponent<ShopManagerScript>().shopItens[3, 2];
            GameController.gameController.quantidadePowerUP[2] = GetComponent<ShopManagerScript>().shopItens[3, 3];
            GameController.gameController.quantidadePowerUP[3] = GetComponent<ShopManagerScript>().shopItens[3, 4];

            //comprouItem = true;
            //return true;
        }
        
        //return false;
    }
}
