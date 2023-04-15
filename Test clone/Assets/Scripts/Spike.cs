using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Coroutine currentCoroutine;

    public void LiftUp()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0.4f, transform.localPosition.z);
        Debug.Log("Spike levantando");

        // Se já existe uma corrotina em andamento, cancela
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        // Agenda a execução da função LowerDown depois de 2 segundos
        currentCoroutine = StartCoroutine(LowerDownAfterDelay(2f));
    }

    private IEnumerator LowerDownAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.localPosition = new Vector3(transform.localPosition.x, -0.4f, transform.localPosition.z);
        Debug.Log("Spike abaixando");
        currentCoroutine = null;
    }
}
