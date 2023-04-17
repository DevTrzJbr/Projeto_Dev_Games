using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour

{
   [SerializeField] private string NomeCena;
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere Final de Fase" && collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(NomeCena);
        }
    }
}
 
