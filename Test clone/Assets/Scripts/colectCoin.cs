using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colectCoin : MonoBehaviour
{
    public Text scoreTxt;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();
    }

   private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Coin") == true)
        {
            score++;
            Destroy(col.gameObject);
        }
    }
}
