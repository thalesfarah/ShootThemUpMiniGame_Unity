using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EnemySpawner;
public class Player : MonoBehaviour
{
    public int vidaPlayer = 3;
    public static bool playerIsDead = false;
    public Text xpScore;
    public Text[] powerUPsQuantityText = new Text[4];
    bool escudoativado;
    public float tempoDoPowerUp = 5f, speedMultiplier = 3f;
    public Material playerMaterial;
    Color originalColor;
    public Slider vidaSlider;
    public GameObject defeatPanel;
    private void Start()
    {
        playerIsDead = false;
        xpScore.gameObject.SetActive(true);
        originalColor = playerMaterial.color;
    }
    private void FixedUpdate()
    {
        xpScore.text = GameController.gameController.xpInicio.ToString();
        
        if (vidaPlayer <= 0) 
        {
            vidaPlayer = 0;
            defeatPanel.SetActive(true);
            
            Destroy(this.gameObject);
            playerIsDead = true;
        }
        powerUPsQuantityText[0].text = GameController.gameController.quantidadePowerUP[0].ToString();
        powerUPsQuantityText[1].text = GameController.gameController.quantidadePowerUP[1].ToString();
        powerUPsQuantityText[2].text = GameController.gameController.quantidadePowerUP[2].ToString();
        powerUPsQuantityText[3].text = GameController.gameController.quantidadePowerUP[3].ToString();
        vidaSlider.value = vidaPlayer;
        AtivaPowerUp();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (escudoativado == false) 
        {
            if (other.gameObject.CompareTag("Inimigo"))
            {
                vidaPlayer--;
                StartCoroutine(DamageEffect());
                Debug.Log(vidaPlayer);
            }
        }   
    }
    public void AtivaPowerUp() 
    {
        if (EnemySpawner.waiting == true || EnemySpawner.couting == true) 
        {
            if (GameController.gameController.quantidadePowerUP[0] > 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Debug.Log("power up gasto, restante: " + GameController.gameController.quantidadePowerUP[0].ToString());
                    GameController.gameController.quantidadePowerUP[0]--;
                    StartCoroutine(Escudo());

                }
            }
            else if (GameController.gameController.quantidadePowerUP[1] > 0)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    GameController.gameController.quantidadePowerUP[1]--;
                    StartCoroutine(SpeedUp());

                }
            }
            else if (GameController.gameController.quantidadePowerUP[2] > 0)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    GameController.gameController.quantidadePowerUP[2]--;
                    StartCoroutine(HitKill());

                }

            }
            else if (GameController.gameController.quantidadePowerUP[3] > 0)
            {
                if (Input.GetKey(KeyCode.P))
                {
                    GameController.gameController.quantidadePowerUP[3]--;
                    StartCoroutine(DoublePoints());

                }
            }

        }
    }
    IEnumerator Escudo() 
    {
        escudoativado = true;
        Debug.Log("escudo ativado");
        yield return new WaitForSeconds(tempoDoPowerUp);
        escudoativado = false;
        Debug.Log("escudo desativado");
        yield break;
    }
    IEnumerator SpeedUp() 
    {
        float originalSpeed = GetComponent<PlayerMovement>().speed;
        float newSpeed = originalSpeed * speedMultiplier;
        GetComponent<PlayerMovement>().speed = newSpeed;
        Debug.Log("boost ativado");
        yield return new WaitForSeconds(tempoDoPowerUp * 0.5f);
        GetComponent<PlayerMovement>().speed = originalSpeed;
        Debug.Log("boost desativado");
        yield break;
    }
    IEnumerator DoublePoints() 
    {
        Debug.Log("double point activated");
        int originalScore = GameController.gameController.pointPerEnemy;
        GameController.gameController.pointPerEnemy *= 2;
        yield return new WaitForSeconds(tempoDoPowerUp * 2);
        GameController.gameController.pointPerEnemy = originalScore;
        yield break;
    }
    IEnumerator DamageEffect() 
    {
        if (vidaPlayer <= 0)
        {
            playerMaterial.color = originalColor;
        }
        else 
        {
            for (int i = 0; i < 3; i++)
            {
                playerMaterial.color = Color.black;
                yield return new WaitForSeconds(.1f);
                playerMaterial.color = Color.white;
                yield return new WaitForSeconds(.1f);
            }
            playerMaterial.color = originalColor;
        }
        
        yield break;
    }
    IEnumerator HitKill()
    {
        int originalVidaInimigo = GetComponent<Enemy>().vidaInimigo;
        GetComponent<Enemy>().vidaInimigo = 1;
        yield return new WaitForSeconds(tempoDoPowerUp * 2f);
        GetComponent<Enemy>().vidaInimigo = originalVidaInimigo;
        yield break;

    }

}
