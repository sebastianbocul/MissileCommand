using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(0   , -1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "boomNew(Clone)")
        {
            Destroy(gameObject);
            FindObjectOfType<GM>().rockets += 10;
            FindObjectOfType<GM>().globalSpeed += 1f;
            FindObjectOfType<GM>().boomRange += 1f;

        }

    }
}
