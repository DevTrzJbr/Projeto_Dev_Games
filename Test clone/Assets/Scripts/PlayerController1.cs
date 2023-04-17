using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 10f;

    private Rigidbody rb;
    private Animator animator; // Refer�ncia ao componente Animator do personagem
    private bool playerDead = false; // verifica se o jogador morreu
    private bool isGrounded = true; // vari�vel para verificar se o jogador est� no ch�o
    private GameObject groundObject;

    private void Start()
    {
        //transform.position = new Vector3(15f, 2f, 2f); // posi��o inicial do boneco (comente para modo desenvolvimento)
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Obt�m a refer�ncia ao componente Animator do personagem
        groundObject = GameObject.FindGameObjectWithTag("Ground");
        TrapSpikes trapSpikes = FindObjectOfType<TrapSpikes>();
        if (trapSpikes != null)
        {
            trapSpikes.OnPlayerEnterTrap += OnEnterTrap;
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            animator.SetBool("andando", true);
            Quaternion rotation = Quaternion.LookRotation(movement);
            if (movement.x > 0)
            {
                rotation *= Quaternion.Euler(0f, 0.1f, 0f);
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10f * Time.deltaTime);
            rb.MovePosition(transform.position + movement);
        }
        else
        {
            animator.SetBool("andando", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded) // verifica se o jogador est� no ch�o antes de permitir o pulo
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                animator.SetBool("jump", true);
            }
            else if (Physics.Raycast(transform.position + Vector3.up * 1f, transform.forward, out RaycastHit hit, 1f) && hit.collider.CompareTag("Wall")) // verifica se o jogador est� colidindo com uma parede
            {
                Vector3 jumpDirection = new Vector3(-transform.forward.x, 1f, 0f).normalized; // calcula a dire��o do salto
                rb.AddForce(jumpDirection * wallJumpForce, ForceMode.Impulse); // adiciona uma for�a para fazer o jogador saltar na parede
                isGrounded = false;
                animator.SetBool("jump", true);
            }
        }
        Debug.DrawRay(transform.position + Vector3.up * 1f, transform.forward * 1f, Color.red); // desenha o raio do Raycast em vermelho

        if (transform.position.y < -20f) // se o jogador passar do position y -20
        {
            playerDead = true; // define que o jogador morreu
            Debug.Log("Player morreu"); // exibe mensagem de depura��o
            transform.position = new Vector3(15f, 2f, 2f); // move o jogador para a posi��o (15, 2, 2)
        }
    }

    // verifica se o jogador est� no ch�o
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("jump", false);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            // Fa�a algo quando o jogador colidir com uma parede
        }
        if (other.gameObject.CompareTag("Death") || other.gameObject.CompareTag("Trap"))
        {
            transform.position = new Vector3(15f, 2f, 2f); // move o jogador para a posi��o (15, 2, 2)
        }
    }

    // verifica se o jogador saiu do ch�o
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnEnterTrap(PlayerController player)
    {
        Debug.Log("O jogador entrou na armadilha!");
        // Fa�a algo quando o jogador entrar na armadilha
    }
}