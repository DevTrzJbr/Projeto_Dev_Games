using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow; // objeto que ser� seguido
    public float distanceX = 1.0f; // dist�ncia em X que o objeto deve manter em rela��o ao objeto seguido
    public float distanceY = 1.0f; // dist�ncia em Y que o objeto deve manter em rela��o ao objeto seguido

    void Update()
    {
        Vector3 newPosition = objectToFollow.transform.position + new Vector3(distanceX, distanceY, 0f);
        transform.position = newPosition;
    }
}