using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometControl : MonoBehaviour
{

    public int enemyTraj;
    public int randX;
    public int randY;

    // Start is called before the first frame update
    void Start()
    {
        enemyTraj = Random.Range(1, 3);
        randX = Random.Range(-1, 2);
        randY = Random.Range(-1, -3);
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
}
