using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometControlBig : MonoBehaviour
{

    public Transform cometBigPiece;

    public int enemyTraj;
    public float randX;
    public float randY;

    // Start is called before the first frame update
    void Start()
    {
        enemyTraj = Random.Range(1, 3);


        randX = Random.Range(-200, 200);
        randX = randX / 100;
        randY = Random.Range(-100, -300);
        randY = randY / 100;


        GetComponent<Rigidbody2D>().velocity = new Vector2(randX, randY);

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
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "boomNew(Clone)")
        {
            Vector3 collisionPosition = gameObject.transform.position;
            Destroy(gameObject);
            FindObjectOfType<GM>().rockets += 1;

          


            //  ContactPoint2D contact = collision.GetContacts[];
           // Vector3 collisionPosition = collision.transform.position;
            Instantiate(cometBigPiece, collisionPosition, cometBigPiece.rotation);
            Instantiate(cometBigPiece, collisionPosition, cometBigPiece.rotation);
            Instantiate(cometBigPiece, collisionPosition, cometBigPiece.rotation);
            Debug.Log("SPAWNING COMET PIECE");


        }
       
    }
}
