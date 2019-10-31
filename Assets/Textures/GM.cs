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

    public float spawnTimer;
    public int randX;

    public bool rocketLive=false;
    public static int rockets = 15;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultTexture, hotSpot, curMode);
        //objPosition = Vector3.Lerp(-5.76f, -4.2f, 0);
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
        }
    }

    void enemySpawn()
    {
        spawnTimer += Time.deltaTime;
        randX = Random.Range(-7,7);
        if (spawnTimer > 1f)
        {
            spawnTimer = 0;
            Instantiate(enemyObj,new Vector2(randX,6f),enemyObj.rotation);

           // rocketLive = rocketLiveFun();
        }

    }



}
