using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon: MonoBehaviour
{
public GameObject balon;

    float balonOlusturmaSuresi = 1f;
    float timer = 0f;
    GameControl gcScript;

    // Start is called before the first frame update
    void Start()
    {
        gcScript = GameObject.Find("_Scripts").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gcScript.timer > 0) // Timer 0'ın altına düştüyse balon üretme
        {
            timer -= Time.deltaTime;
            int coefficient = (int)(gcScript.timer/10) -6;
            coefficient *=-1; //zaman ilerledikçe fazla balon üreticek

            if (timer < 0)
            {
                // Yeni balon yarat
                GameObject go = Instantiate(balon, new Vector3(Random.Range(-2.75f, 2.75f), -6f, 0), Quaternion.Euler(0, 0, 0));
                go.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, Random.Range(30f*coefficient, 80f*coefficient), 0));
                timer = balonOlusturmaSuresi;
            }
        }
    }
}