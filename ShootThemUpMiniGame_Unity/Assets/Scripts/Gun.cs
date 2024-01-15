using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gun : MonoBehaviour
{
    public GameObject projetil;
    public Transform arma;
    public float bulletSpeed, coolDown;
    bool canFire = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (canFire == true)
            {
                StartCoroutine(Atirar());
            }

        }
    }
    IEnumerator Atirar() 
    {
        GameObject bala = Instantiate(projetil, arma.transform.position, arma.transform.rotation);
        Rigidbody projetilRb = bala.GetComponent<Rigidbody>();
        projetilRb.AddForce(bala.gameObject.transform.forward * bulletSpeed);
        canFire = false;
        yield return new WaitForSeconds(coolDown);
        canFire = true;
    }
}
