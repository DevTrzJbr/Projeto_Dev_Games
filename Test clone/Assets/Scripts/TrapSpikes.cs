using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikes : MonoBehaviour
{
    public event Action<PlayerController> OnPlayerEnterTrap;
    public event Action<PlayerController> OnPlayerExitTrap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                Debug.Log("Player entrou na trap");
                OnPlayerEnterTrap?.Invoke(player);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                Debug.Log("Player saiu da trap");
                OnPlayerExitTrap?.Invoke(player);
            }
        }
    }
}