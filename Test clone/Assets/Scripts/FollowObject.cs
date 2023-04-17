using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow; // objeto que será seguido
    public float distanceX = 1.0f; // distância em X que o objeto deve manter em relação ao objeto seguido
    public float distanceY = 1.0f; // distância em Y que o objeto deve manter em relação ao objeto seguido

    void Update()
    {
        Vector3 newPosition = objectToFollow.transform.position + new Vector3(distanceX, distanceY, 0f);
        transform.position = newPosition;
    }
}