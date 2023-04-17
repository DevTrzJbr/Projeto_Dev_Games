using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed = 10.0f; // velocidade de movimento do objeto

    private Rigidbody rb; // componente Rigidbody do objeto

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90f); // define a rotação z do gameObject para 90 graus
        rb = GetComponent<Rigidbody>(); // obtém o componente Rigidbody do objeto
        rb.velocity = transform.up * speed; // define a velocidade do objeto na direção para a frente
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Player"))
        {
            // Faça algo quando o jogador colidir com uma parede
            Destroy(gameObject); // destrói o objeto quando colide com outro objeto
        }
    }
}