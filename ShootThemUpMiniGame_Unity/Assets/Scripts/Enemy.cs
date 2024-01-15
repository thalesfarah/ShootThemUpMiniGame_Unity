using System.Drawing;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Enemy : MonoBehaviour
{
    public int vidaInimigo = 3;
    
    private void FixedUpdate()
    {
        if (vidaInimigo <= 0) 
        {
            vidaInimigo = 0;
            GameController.gameController.xpInicio += GameController.gameController.pointPerEnemy;
            GameController.gameController.xpTotal += GameController.gameController.pointPerEnemy;
            Destroy(this.gameObject);
            

        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projetil"))
        {
            vidaInimigo--;
            StartCoroutine(EnemyDamageEffect());
            Destroy(collision.gameObject);
        }
    }
    IEnumerator EnemyDamageEffect() 
    {
        MeshRenderer enemyMeshRenderer = GetComponent<MeshRenderer>();
        for (int i = 0; i < 3; i++) 
        {
            enemyMeshRenderer.enabled = false;
            yield return new WaitForSeconds(.1f);
            enemyMeshRenderer.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
        yield break;
    }
}
