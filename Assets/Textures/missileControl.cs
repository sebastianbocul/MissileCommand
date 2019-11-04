using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileControl : MonoBehaviour
{
    public float timeKeeper = 0;
    public float fracDist = 0.01f;


    public Transform boomObj;
    public Vector3 testPosition = new Vector3(-5.76f, -4.4f, 0);

    //rotacja rakiety
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;


    // Start is called before the first frame update
    void Start()
    {
        GM.targetPosition = GM.objPosition;
        fracDist = 0.01f;


        //Rotacja rakiety
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -90;
        object_pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //staticRocket.transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = (Quaternion.Euler(0, 0, angle - 90));

        //  GetComponent<Transform>().eulerAngles = new Vector3(0, 0,0); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            timeKeeper += Time.deltaTime;

            if (timeKeeper > 0.05)
            {
                fracDist += 0.02f;
                timeKeeper = 0;
            }
            if (gameObject == null)
            {
                //  Debug.Log("Null Objcet");
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, GM.targetPosition, fracDist);
            }
        }


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "pointerRed2(Clone)")
        {
            Destroy(gameObject);
            Instantiate(boomObj, transform.position, boomObj.rotation);
            FindObjectOfType<GM>().rocketLive = false;
            FindObjectOfType<GM>().staticRocketL.SetActive(true);
            Destroy(gameObject);


        }
    }

}
