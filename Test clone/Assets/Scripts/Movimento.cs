using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController character; // Referência ao componente CharacterController do personagem
    private Animator animator; // Referência ao componente Animator do personagem
    private Vector3 inputs; // Vetor que armazena as entradas de movimento do jogador

    [SerializeField] private float velocidade = 2f; // Velocidade de movimento do personagem
    [SerializeField] private float forcaDoPulo = 5f; // Força do pulo do personagem

    void Start()
    {
        character = GetComponent<CharacterController>(); // Obtém a referência ao componente CharacterController do personagem
        animator = GetComponent<Animator>(); // Obtém a referência ao componente Animator do personagem
    }
    
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, 0); // Obtém as entradas de movimento do jogador, definindo a componente y como zero

        if (Input.GetKeyDown(KeyCode.W)) // Verifica se a tecla de W foi pressionada
        {
            animator.SetBool("jump", true);
            character.Move(Vector3.up * forcaDoPulo); // Adiciona uma força vertical ao personagem para simular o pulo
        }
        else
        {
            animator.SetBool("jump", false);
        }

        character.Move((transform.forward * inputs.magnitude * Time.deltaTime * velocidade)); // Move o personagem na direção do vetor de entrada
        character.Move((Vector3.down * Time.deltaTime)); // Aplica a gravidade ao personagem

        if (inputs != Vector3.zero) // Verifica se o vetor de entrada é diferente de zero
        {
            animator.SetBool("andando", true); // Define a variável "andando" do Animator como verdadeira para ativar a animação de caminhada
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 10); // Rotaciona o personagem na direção do vetor de entrada
        }
        else
        {
            animator.SetBool("andando", false); // Define a variável "andando" do Animator como falsa para desativar a animação de caminhada
        }
    }
}