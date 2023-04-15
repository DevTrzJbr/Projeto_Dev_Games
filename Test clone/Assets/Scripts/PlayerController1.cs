using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;

    private CharacterController character; // Refer�ncia ao componente CharacterController do personagem
    private Animator animator; // Refer�ncia ao componente Animator do personagem
    private Vector3 inputs; // Vetor que armazena as entradas de movimento do jogador

    GameObject groundObject;


    // vari�vel para verificar se o jogador est� no ch�o
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        character = GetComponent<CharacterController>(); // Obt�m a refer�ncia ao componente CharacterController do personagem
        animator = GetComponent<Animator>(); // Obt�m a refer�ncia ao componente Animator do personagem

        groundObject = GameObject.FindGameObjectWithTag("ground");

        TrapSpikes trapSpikes = FindObjectOfType<TrapSpikes>();
        if (trapSpikes != null)
        {
            trapSpikes.OnPlayerEnterTrap += OnEnterTrap;
        }
    }

    private void OnEnterTrap(PlayerController player)
    {
        Debug.Log("O jogador entrou na armadilha!");
        // Fa�a algo quando o jogador entrar na armadilha
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if (Input.GetButtonDown("Jump") && isGrounded) // verifica se o jogador est� no ch�o antes de permitir o pulo
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("jump", true);
        }

        if (Physics.Raycast(transform.position, transform.right, 1f))
        {
            rb.velocity = Vector3.zero;
        }
    }
    
    // verifica se o jogador est� no ch�o
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // verifica se o jogador saiu do ch�o
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("jump", false);
        }
    }
}