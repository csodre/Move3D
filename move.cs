using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    CharacterController controller;
    Vector3 eixoY;
    Vector3 eixoZ;
    Vector3 eixoX;
    float velMove =5.0f;

    float gravidade,velPulo,altMaxPulo,tempoAltPulo;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        altMaxPulo = 2.0f;
        tempoAltPulo = 0.5f;
        gravidade = (-2*altMaxPulo)/(tempoAltPulo*tempoAltPulo);
        velPulo = (2*altMaxPulo)/tempoAltPulo;

    }

    void Update()
    {
        float moveX= Input.GetAxis("Horizontal");
        float moveZ= Input.GetAxis("Vertical");

        eixoX = moveX * velMove * transform.right;
        eixoZ = moveZ * velMove * transform.forward;
        eixoY += gravidade * Time.deltaTime * Vector3.up;



        Vector3 velFinal = eixoY+eixoX+eixoZ;
        controller.Move(velFinal*Time.deltaTime);

        if (controller.isGrounded)
        {
            eixoY = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&controller.isGrounded)
        {
            eixoY = velPulo * Vector3.up;
        }
        if(eixoY.y > 0 &&(controller.collisionFlags & CollisionFlags.Above) !=0)
        {
            eixoY = Vector3.zero;
        }

    }
}
