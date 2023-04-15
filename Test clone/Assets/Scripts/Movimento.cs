using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController character; // Refer�ncia ao componente CharacterController do personagem
    private Animator animator; // Refer�ncia ao componente Animator do personagem
    private Vector3 inputs; // Vetor que armazena as entradas de movimento do jogador

    [SerializeField] private float velocidade = 2f; // Velocidade de movimento do personagem
    [SerializeField] private float forcaDoPulo = 5f; // For�a do pulo do personagem

    void Start()
    {
        character = GetComponent<CharacterController>(); // Obt�m a refer�ncia ao componente CharacterController do personagem
        animator = GetComponent<Animator>(); // Obt�m a refer�ncia ao componente Animator do personagem
    }
    
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, 0); // Obt�m as entradas de movimento do jogador, definindo a componente y como zero

        if (Input.GetKeyDown(KeyCode.W)) // Verifica se a tecla de W foi pressionada
        {
            animator.SetBool("jump", true);
            character.Move(Vector3.up * forcaDoPulo); // Adiciona uma for�a vertical ao personagem para simular o pulo
        }
        else
        {
            animator.SetBool("jump", false);
        }

        character.Move((transform.forward * inputs.magnitude * Time.deltaTime * velocidade)); // Move o personagem na dire��o do vetor de entrada
        character.Move((Vector3.down * Time.deltaTime)); // Aplica a gravidade ao personagem

        if (inputs != Vector3.zero) // Verifica se o vetor de entrada � diferente de zero
        {
            animator.SetBool("andando", true); // Define a vari�vel "andando" do Animator como verdadeira para ativar a anima��o de caminhada
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 10); // Rotaciona o personagem na dire��o do vetor de entrada
        }
        else
        {
            animator.SetBool("andando", false); // Define a vari�vel "andando" do Animator como falsa para desativar a anima��o de caminhada
        }
    }
}