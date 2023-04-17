using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBala : MonoBehaviour
{
    public float velocidade = 10f; // velocidade do projetil

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }
}
