using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f, rotateSpeed = 3f, minPlayerPosX, maxPlayerPosX, minPlayerPosZ, maxPlayerPosZ;
    private void Start()
    {
        minPlayerPosX = maxPlayerPosX * -1;
        minPlayerPosZ = maxPlayerPosZ * -1;
    }
    void Update()
    {

        Move();

    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        if (position.x >= maxPlayerPosX) 
        {
            position.x = minPlayerPosX;
            transform.position = position;

        }
        else if (position.x <= minPlayerPosX) 
        {
            position.x = maxPlayerPosX;
            transform.position = position;
        }
        if (position.z >= maxPlayerPosZ)
        {
            position.z = minPlayerPosZ;
            transform.position = position;
        } 
        else if (position.z <= minPlayerPosZ) 
        {
            position.z = maxPlayerPosZ;
            transform.position = position;
        }
    }
    void Move()
    {
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }
}
