using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;

    // variável para verificar se o jogador está no chão
    private bool isGrounded = true;
    private bool isOnPlatform = false;
    private MovingPlatform currentPlatform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        TrapSpikes trapSpikes = FindObjectOfType<TrapSpikes>();
        if (trapSpikes != null)
        {
            trapSpikes.OnPlayerEnterTrap += OnEnterTrap;
        }
    }

    private void OnEnterTrap(PlayerController player)
    {
        Debug.Log("O jogador entrou na armadilha!");
        // Faça algo quando o jogador entrar na armadilha
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if (Input.GetButtonDown("Jump") && isGrounded) // verifica se o jogador está no chão antes de permitir o pulo
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Physics.Raycast(transform.position, transform.right, 1f))
        {
            rb.velocity = Vector3.zero;
        }
    }
    
    // verifica se o jogador está no chão
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        } 
        else if (other.gameObject.CompareTag("MovePlatform"))
        {
            isOnPlatform = true;
            currentPlatform = other.gameObject.GetComponent<MovingPlatform>();
            currentPlatform.AddPlayer(transform);
            Debug.Log("Player Entrou na plataforma");
        }
    }

    // verifica se o jogador saiu do chão
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        else if (other.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = false;
            currentPlatform.RemovePlayer();
            currentPlatform = null;
            Debug.Log("Player saiu da plataforma");
        }
    }
}
