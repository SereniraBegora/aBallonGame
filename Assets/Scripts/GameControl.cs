using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public UnityEngine.UI.Text timeText, ballonText;
    public GameObject explosion;
    public float timer = 10f;
    int expballon = 0;

    void Start()
    {
        ballonText.text = "Ballon: " + expballon;
    }

    void Update()
    {
        if (timer > 0) // Timer 0'ın altına düşerse zaman sayacı durur
        {
            timer -= Time.deltaTime;
            timeText.text = "Time: " + (int)timer;
        }
        else
        {
            timer = 0; // Negatif süreye düşmesini engeller
            timeText.text = "Time: 0";

            GameObject[] go = GameObject.FindGameObjectsWithTag ("ballon");
            for (int i=0; i<go.Length; i++){
                Instantiate(explosion,go[i].transform.position,go[i].transform.rotation);

                Destroy(go [i]);
            }
        }
    }

    public void AddBallon()
    {
        expballon += 1;
        ballonText.text = "Ballon: " + expballon;
    }
}
