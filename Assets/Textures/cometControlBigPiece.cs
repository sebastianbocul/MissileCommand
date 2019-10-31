using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometControlBigPiece : MonoBehaviour
{

    public Transform cometBigPiece;

    public int enemyTraj;
    public float randX;
    public float randY;
    public bool collision = false;


    public float timer=0;


    // Start is called before the first frame update
    void Start()
    {

        randX = Random.Range(-200, 200);
        randX = randX / 100;
        randY = Random.Range(200,201);
        randY = randY / 100;

        GetComponent<Rigidbody2D>().velocity = new Vector2(randX, randY);
        GetComponent<Rigidbody2D>().gravityScale = 0.25f;
        GetComponent<Collider2D>().enabled = false;




        //  GetComponent<Rigidbody2D>().velocity = new Vector2(randX, randY);

        /*
        if (enemyTraj == 1)
        {
           
        }
        else if (enemyTraj > 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, -1);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1)
        {
            GetComponent<Collider2D>().enabled = true ;
        }
        // GetComponent<ColliderDistance2D>().
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "boomNew(Clone)" && collision == true)
        {
            Vector3 collisionPosition = gameObject.transform.position;
            Destroy(gameObject);
            FindObjectOfType<GM>().rockets += 1;

     
        }
       
    }
}
