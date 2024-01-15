using UnityEngine;
public class EnemyMovimentation : MonoBehaviour
{
    public GameObject target;
    public float velocidade;
    void Start()
    {
        if (target == null)
        {
            if (Player.playerIsDead == false)
            {
                target = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                return;
            }
        }
    }
    void FixedUpdate()
    {

        CharacterController controller = GetComponent<CharacterController>();
        transform.LookAt(target.transform.position);
        Vector3 direcao = target.transform.position - transform.position;
        direcao.y = 0f;
        direcao = direcao.normalized;
        controller.SimpleMove(direcao * velocidade);

    }
}
