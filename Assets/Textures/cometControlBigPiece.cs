﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometControlBigPiece : MonoBehaviour
{

    public Transform cometBigPiece;
    public Transform destroy_city;

    public int enemyTraj;
    public float randX;
    public float randY;
    public bool collision = false;


    public float timer = 0;




    void RocketsUpdate()
    {
        if (FindObjectOfType<GM>().rockets > 0)
        {
            FindObjectOfType<GM>().rockets--;
        }
    }



    // Start is called before the first frame update
    void Start()
    {

        randX = Random.Range(-200, 200);
        randX = randX / 100;
        randY = Random.Range(200, 201);
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
        if (timer > 1)
        {
            GetComponent<Collider2D>().enabled = true;
        }
        // GetComponent<ColliderDistance2D>().
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "boomNew(Clone)" && collision == true)
        {
            Vector3 collisionPosition = gameObject.transform.position;
            Destroy(gameObject);
            FindObjectOfType<GM>().score++;


        }

        foreach (string city in FindObjectOfType<GM>().cityNames)
        {
            if (collision.gameObject.name == city)
            {
                Destroy(gameObject);
                Instantiate(destroy_city, gameObject.transform.position, destroy_city.rotation);

            }
        }

        foreach (string city_destroy in FindObjectOfType<GM>().city_d)
            if (collision.gameObject.name == city_destroy)
            {
                Destroy(gameObject);
                RocketsUpdate();
                Instantiate(destroy_city, gameObject.transform.position, destroy_city.rotation);

            }
        if (collision.gameObject.name == "city08" || collision.gameObject.name == "city05_d(Clone)")
        {

            Destroy(gameObject);
            RocketsUpdate();
            Instantiate(destroy_city, gameObject.transform.position, destroy_city.rotation);
        }


    }
}
