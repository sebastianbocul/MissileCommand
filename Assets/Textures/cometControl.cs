using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometControl : MonoBehaviour
{

    public float enemyTraj;
    public float randX;
    public float randY;

    public Transform destroy_city;

   

    // Start is called before the first frame update
    void Start()
    {
        enemyTraj = Random.Range(100, 300)/100;
        randX = Random.Range(-200, 200);
        randX = randX / 100;
        randY = Random.Range(-100, -300);
        randY = randY / 100;

        Debug.Log("randX:" + randX + "      randY:" + randY);

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
            Destroy(gameObject);
            FindObjectOfType<GM>().rockets += 1;
            FindObjectOfType<GM>().score++;
        }

        foreach (string city in FindObjectOfType<GM>().cityNames){
            if (collision.gameObject.name == city)
            {
                Destroy(gameObject);
                FindObjectOfType<GM>().score--;
                Instantiate(destroy_city, gameObject.transform.position, destroy_city.rotation);
                
                
            }
        }

        
       
    }
}
