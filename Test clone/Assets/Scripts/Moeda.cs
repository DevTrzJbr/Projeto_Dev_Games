using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public float amplitude = 0.5f; // amplitude da curva senoidal
    public float speed = 1f; // velocidade da flutua��o

    private float startY; // posi��o inicial em y da moeda

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y; // obtem a posi��o inicial em y da moeda
    }

    // Update is called once per frame
    void Update()
    {
        // atualiza a posi��o y da moeda usando a curva senoidal
        transform.position = new Vector3(transform.position.x, startY + amplitude * Mathf.Sin(Time.time * speed), transform.position.z);

        // adiciona uma rota��o lenta na moeda em seu pr�prio eixo
        transform.Rotate(Vector3.up, Time.deltaTime * 50f);
    }
}