using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{

    public Texture2D defaultTexture;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Vector2 mousePosition;

    public static Vector2 objPosition = new Vector2(-5.76f, -4.4f);
    public static Vector2 targetPosition;

    public KeyCode fireMissile;

    public Transform missileObj;

    public Transform lockOnTarget;
    public Transform countText;
    public Transform enemyObj;
    public Transform enemyObjBig;
    public GameObject staticRocket;


    public float spawnSmallCometTimer;
    public float spawnBigCometTimer;

    public int randX;

    public bool rocketLive=false;
    public int rockets = 15;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultTexture, hotSpot, curMode);
        //objPosition = Vector3.Lerp(-5.76f, -4.2f, 0);
        staticRocket.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawn();
        countText.GetComponent<TextMesh>().text = rockets.ToString() ;
        mousePosition = new Vector2(Input.mousePosition.x+16, Input.mousePosition.y-16);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetKeyDown(fireMissile) == true && rockets>0 && rocketLive==false)
        {
            Instantiate(missileObj, new Vector2(-5.76f, -4.2f),missileObj.rotation);
            Instantiate(lockOnTarget, objPosition, lockOnTarget.rotation);
            rockets--;
            rocketLive = true;

            staticRocket.SetActive(false);

        }
    }

    void enemySpawn()
    {
        spawnSmallCometTimer += Time.deltaTime;
        spawnBigCometTimer += Time.deltaTime;

        randX = Random.Range(-8,8);



        //small comet spawner
        if (spawnSmallCometTimer > 1f)
        {
            spawnSmallCometTimer = 0;
            Instantiate(enemyObj,new Vector2(randX,6f),enemyObj.rotation);

           // rocketLive = rocketLiveFun();
        }


        //big comet spawner
        if (spawnBigCometTimer > 1f)
        {
            spawnBigCometTimer = 0;
            Instantiate(enemyObjBig, new Vector2(randX, 6f), enemyObjBig.rotation);

           
   
        }

    }



}
