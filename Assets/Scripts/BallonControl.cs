using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonControl : MonoBehaviour
{
    public GameObject explosionPrefab;
    GameControl gameControlScript;

    void Start()
    {
        // GameControl script'ine doğru bir şekilde erişelim
        gameControlScript = GameObject.Find("_Scripts").GetComponent<GameControl>();
    }

    void OnMouseDown()
    {
        // Patlama efektini Instantiate edin
        GameObject exp = Instantiate(explosionPrefab, transform.position, transform.rotation);

        // Patlama efektini 2 saniye sonra yok et
        Destroy(exp, 0.30f);

        // Balonu yok et
        Destroy(this.gameObject);

        // GameControl üzerinden balon sayısını arttır
        gameControlScript.AddBallon();
    }
}
