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

    public KeyCode fireMissileL;
    public KeyCode fireMissileR;

    public Transform missileObj;
    public Transform missileObjR;

    public Transform lockOnTarget;
    public Transform countText;
    public Transform enemyObj;
    public Transform enemyObjBig;
    public GameObject staticRocketL;
    public GameObject staticRocketR;


    public float spawnSmallCometTimer;
    public float spawnBigCometTimer;

    public int randX;

    public bool rocketLive=false;
    public int rockets = 15;

    public float rotationSpeed = 0.1f;

    public float h;
    public float v;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    //rotacja rakiety
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultTexture, hotSpot, curMode);
        //objPosition = Vector3.Lerp(-5.76f, -4.2f, 0);
        staticRocketL.SetActive(true);
        staticRocketR.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


        enemySpawn();
        countText.GetComponent<TextMesh>().text = rockets.ToString() ;
        mousePosition = new Vector3(Input.mousePosition.x+16, Input.mousePosition.y-16, Input.mousePosition.z - transform.position.z);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);


        /*
        //Rotacja rakiety
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -90;
        object_pos = Camera.main.WorldToScreenPoint(staticRocket.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //staticRocket.transform.rotation = Quaternion.Euler(0, 0, angle);
        staticRocket.transform.rotation = (Quaternion.Euler(0, 0, angle-90));
        */


        //Launching rockets
        if (Input.GetKeyDown(fireMissileL) == true && rockets>0 && rocketLive==false)
        {
            Instantiate(missileObj, new Vector2(-5.76f, -4.2f),missileObj.rotation);
            Instantiate(lockOnTarget, objPosition, lockOnTarget.rotation);
            rockets--;
            rocketLive = true;

            staticRocketL.SetActive(false);
          

        }

        if (Input.GetKeyDown(fireMissileR) == true && rockets > 0 && rocketLive == false)
        {
            Instantiate(missileObjR, new Vector2(6.4f, -4.2f), missileObjR.rotation);
            Instantiate(lockOnTarget, objPosition, lockOnTarget.rotation);
            rockets--;
            rocketLive = true;
            staticRocketR.SetActive(false);

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
        if (spawnBigCometTimer > 3f)
        {
            spawnBigCometTimer = 0;
            Instantiate(enemyObjBig, new Vector2(randX, 6f), enemyObjBig.rotation);

           
   
        }

    }



}
