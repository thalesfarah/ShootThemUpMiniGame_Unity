using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class GameController : MonoBehaviour
{
   
    public static GameController gameController;
    public bool jogoPausado = false;
    public int xpTotal, xpInicio = 0, level, pointPerEnemy = 10;
    public int [] quantidadePowerUP =  new int[4];
    public AudioSource musica;
    private void Awake()
    {

        if (gameController == null)
        {
            gameController = this;
        }
        else
        {
            Destroy(this);
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    private void FixedUpdate()
    {
        Debug.Log("incio: " + xpInicio.ToString());
        Debug.Log("total: " + xpTotal.ToString());
        
    }
    public void SaveGC() 
    {
        SaveSystem.SaveGame(this);
    }
    public void LoadGC() 
    {
        PlayerData data = SaveSystem.LoadPlayer();
        xpTotal = data.XPtotalAmount;
        level = data.actualLevel;
        quantidadePowerUP[0] = data.quantidadePowerUPs[0];
        quantidadePowerUP[1] = data.quantidadePowerUPs[1];
        quantidadePowerUP[2] = data.quantidadePowerUPs[2];
        quantidadePowerUP[3] = data.quantidadePowerUPs[3];

    }

}
