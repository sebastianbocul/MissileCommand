using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        Debug.Log("KAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("KAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK");
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        Debug.Log("collision name = " + collider.gameObject.name);
        if (collider.gameObject.name == "anti_missile_L(Clone)")
        {
            Destroy(gameObject);
            Debug.Log("KOLIZJAA CELOWNIK");
        }
    }

}
