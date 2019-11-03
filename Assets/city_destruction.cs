using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class city_destruction : MonoBehaviour
{
    public Transform city1_d;
    public Transform city2_d;
    public Transform city3_d;
    public Transform city4_d;
    public Transform city5_dd;
    public Transform city6_d;
    public Transform city7_d;


    // public Transform[] city_dd = { city1_d, city2_d, city3_d, city4_d, city5_d, city6_d,city7_d} ;
    public void spawnCity(int i)
    {


        switch (i)
        {
            case 49:
                {
                    Instantiate(city1_d, gameObject.transform.position, gameObject.transform.rotation);
                    break;
                }
            case 50:
                {
                    Instantiate(city2_d, gameObject.transform.position, gameObject.transform.rotation);
                    break;
                }
            case 51:
                {
                    Instantiate(city3_d, gameObject.transform.position, gameObject.transform.rotation);
                    break;
                }
            case 52:
                {
                    Instantiate(city4_d, gameObject.transform.position, gameObject.transform.rotation);
                    break;
                }
            case 53:
                {
                    Instantiate(city5_dd, gameObject.transform.position, gameObject.transform.rotation);
                    break;
                }

            case 54:
                {
                    Instantiate(city6_d, gameObject.transform.position, gameObject.transform.rotation);
                    break;
                }
            case 55:
                {
                    Instantiate(city7_d, gameObject.transform.position, gameObject.transform.rotation);
                    break;
                }

        }
        
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "cometT(Clone)")
        {
            Destroy(gameObject);
            char lastChar = gameObject.name[gameObject.name.Length - 1];
            int i = lastChar;
            spawnCity(i);

        }

        if (collision.gameObject.name == "cometBig(Clone)")
        {
            Destroy(gameObject);
            char lastChar = gameObject.name[gameObject.name.Length - 1];
            int i = lastChar;
            Debug.Log(i);

            spawnCity(i);

        }

        if (collision.gameObject.name == "cometBigPiece(Clone)")
        {
            Destroy(gameObject);
            char lastLChar = gameObject.name[gameObject.name.Length - 1];
            int i = lastLChar;
            Debug.Log(i);
            spawnCity(i);

            // if(gameObject.name.l(i))
            /*for (int i = 1; i <= 7; i++)
            {
                if (gameObject.name == "city0" + i)
                {
                }
            }*/
        }

    }
}
