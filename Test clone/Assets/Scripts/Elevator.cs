using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float maxHeight = 5f; // altura máxima do elevador
    public float minHeight = 0f; // altura mínima do elevador

    private bool isGoingUp = true; // variável que determina se o elevador está subindo ou descendo
    private Vector3 topPosition; // posição do topo do elevador
    private Vector3 bottomPosition; // posição da base do elevador
    private float speed; // velocidade de movimento do elevador

    void Start()
    {
        // define as posições do topo e da base do elevador
        topPosition = transform.position;
        bottomPosition = new Vector3(topPosition.x, minHeight, topPosition.z);

        // define a velocidade do elevador aleatoriamente entre 2 e 5
        speed = Random.Range(2f, 5f);
    }

    void Update()
    {
        // movimenta o elevador
        if (isGoingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= maxHeight)
            {
                isGoingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y <= minHeight)
            {
                isGoingUp = true;
            }
        }
    }
}
