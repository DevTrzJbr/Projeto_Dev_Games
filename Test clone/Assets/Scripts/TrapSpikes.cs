using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou no collider do pai!");
            foreach (Transform child in transform)
            {
                Spike spike = child.GetComponent<Spike>();
                if (spike != null)
                {
                    spike.LiftUp();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player saiu do collider do pai!");
            foreach (Transform child in transform)
            {
                Spike spike = child.GetComponent<Spike>();
                if (spike != null)
                {
                    Debug.Log("Player saiu");
                }
            }
        }
    }
}
