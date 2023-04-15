using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;

    [SerializeField] private float velocidade = 3f;
    [SerializeField] private float forcaDoPulo = 2f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        // Define a gravidade como duas vezes mais forte do que o padrão
        Physics.gravity = new Vector3(0, -20f, 0);
    }

    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("jump", true);
            character.Move(Vector3.up * forcaDoPulo);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        character.Move((transform.forward * inputs.magnitude * Time.deltaTime * velocidade));
        character.Move((Vector3.down * Time.deltaTime));

        if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 15);
        }
        else
        {
            animator.SetBool("andando", false);
        }
    }
}