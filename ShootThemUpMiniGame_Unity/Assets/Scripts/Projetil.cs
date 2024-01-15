using UnityEngine;
public class Projetil : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Muro")) 
        {
            Destroy(this.gameObject);
        }
    }
}
