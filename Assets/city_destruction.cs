using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class city_destruction : MonoBehaviour
{
    public static Transform city1_d;
    public static Transform city2_d;
    public static Transform city3_d;
    public static Transform city4_d;
    public static Transform city5_d;
    public static Transform city6_d;
    public static Transform city7_d;
    

   public Transform[] city_dd = { city1_d, city2_d, city3_d, city4_d, city5_d, city6_d,city7_d} ;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "cometT(Clone)")
        {
            Destroy(gameObject);
            for(int i=0;i<=6;i++)
            {
                if (gameObject.name == "city0"+i)
                {
                    //Instantiate(city_dd[i], gameObject.transform.position, gameObject.transform.rotation);

                }
            }
        }

        if (collision.gameObject.name == "cometBig(Clone)")
        {
            Destroy(gameObject);
            for (int i = 0; i <= 6; i++)
            {
                if (gameObject.name == "city0" + i)
                {
                    //Instantiate(city_dd[i], gameObject.transform.position, gameObject.transform.rotation);

                }
            }
        }

        if (collision.gameObject.name == "cometBigPiece(Clone)")
        {
            Destroy(gameObject);
            for (int i = 0; i <= 6; i++)
            {
                if (gameObject.name == "city0" + i)
                {
                    //Instantiate(city_dd[i], gameObject.transform.position, gameObject.transform.rotation);

                }
            }
        }

    }
}
