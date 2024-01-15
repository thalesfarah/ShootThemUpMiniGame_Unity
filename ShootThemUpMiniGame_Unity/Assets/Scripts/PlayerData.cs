using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int XPtotalAmount, actualLevel;
    public int[] quantidadePowerUPs = new int[4];
    public PlayerData(GameController gc) 
    {
        //gc.xpTotal = GameController.gameController.xpTotal;
        XPtotalAmount = gc.xpTotal;
        actualLevel = gc.level;
        quantidadePowerUPs[0] = gc.quantidadePowerUP[0];
        quantidadePowerUPs[1] = gc.quantidadePowerUP[1];
        quantidadePowerUPs[2] = gc.quantidadePowerUP[2];
        quantidadePowerUPs[3] = gc.quantidadePowerUP[3];
    }
}
