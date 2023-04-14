using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject[] spikes; // Array contendo as estacas
    public float spikeInterval = 1f; // Intervalo de tempo entre as estacas
    public float spikeSpeed = 1f; // Velocidade de movimento das estacas
    public float spikeHeight = 1f; // Altura m�xima que as estacas devem subir

    private bool isSpikesMoving = false; // Flag que indica se as estacas est�o se movendo

    // Start is called before the first frame update
    void Start()
    {
        // Inicia a repeti��o da fun��o MoveSpikes
        InvokeRepeating("MoveSpikes", spikeInterval, spikeInterval);
    }

    // Fun��o que move as estacas para cima
    void MoveSpikes()
    {
        // Verifica se as estacas j� est�o se movendo
        if (!isSpikesMoving)
        {
            // Inicia o movimento de cada estaca no array
            foreach (GameObject spike in spikes)
            {
                StartCoroutine(MoveSpike(spike));
            }
        }
    }

    // Fun��o que move uma estaca para cima
    IEnumerator MoveSpike(GameObject spike)
    {
        isSpikesMoving = true;

        // Move a estaca para cima at� atingir a altura m�xima
        while (spike.transform.position.y < spikeHeight)
        {
            spike.transform.Translate(Vector3.up * spikeSpeed * Time.deltaTime);
            yield return null;
        }

        // Aguarda um tempo antes de mover a estaca para baixo
        yield return new WaitForSeconds(1f);

        // Move a estaca para baixo at� a posi��o original
        while (spike.transform.position.y > transform.position.y)
        {
            spike.transform.Translate(Vector3.down * spikeSpeed * Time.deltaTime);
            yield return null;
        }

        isSpikesMoving = false;
    }
}