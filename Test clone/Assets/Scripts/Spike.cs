using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private bool isMoving = false;
    private bool isUp = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    private float upTime = 1f;
    private float downTime = 1f;
    private float waitTime = 2f;

    private void Start()
    {
        upTime = Random.Range(0.1f, 0.25f);
        startPosition = transform.localPosition;
        targetPosition = new Vector3(startPosition.x, startPosition.y + 0.8f, startPosition.z);
        StartCoroutine(MoveSpike());
    }

    IEnumerator MoveSpike()
    {
        while (true)
        {
            isMoving = true;
            yield return new WaitForSeconds(waitTime);

            isUp = true;
            float t = 0f;
            while (t < upTime)
            {
                t += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t / upTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            isUp = false;
            t = 0f;
            while (t < downTime)
            {
                t += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(targetPosition, startPosition, t / downTime);
                yield return null;
            }

            isMoving = false;
        }
    }
}
