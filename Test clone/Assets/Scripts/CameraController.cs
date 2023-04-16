using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // referência para o jogador

    public float smoothSpeed = 0.125f; // velocidade de movimento da câmera
    public Vector3 offset; // distância da câmera em relação ao jogador
    public float minHeight = 0.5f; // altura mínima da câmera em relação ao jogador
    public float viewAngle = 30f; // Angulo de visão para o player
    [Range(0.5f, 2.5f)]
    public float cameraHeight = 1.5f; // altura da câmera em relação ao jogador

    void Update()
    {
        Vector3 desiredPosition = player.position + offset; // posição que a câmera deve estar

        if (player.position.y > minHeight) // se o jogador estiver no ar
        {
            desiredPosition.y = player.position.y + minHeight; // mantém a câmera a uma altura mínima em relação ao jogador
        }

        Vector3 cameraOffset = Quaternion.Euler(viewAngle, 0f, 0f) * offset; // adiciona uma rotação à câmera
        Vector3 desiredCameraPosition = player.TransformPoint(cameraOffset); // adiciona a rotação à posição desejada da câmera
        desiredCameraPosition += Vector3.up * cameraHeight; // adiciona a altura da câmera à posição desejada da câmera

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredCameraPosition, smoothSpeed); // suaviza o movimento da câmera
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // move a câmera
    }
}