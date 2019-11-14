using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileControl : MonoBehaviour
{
    public float timeKeeper = 0;
    public float fracDist = 0.01f;
    public int ID = 0;


    public Transform boomObj;
    public Vector3 testPosition = new Vector3(-5.76f, -4.4f, 0);

    //rotacja rakiety
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;
    public Vector2 targetPosition;
    public Transform obj;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = FindObjectOfType<GM>().globalSpeed;

        targetPosition = FindObjectOfType<GM>().cursors_pos[FindObjectOfType<GM>().cursors_pos_index];
   //     Debug.Log(FindObjectOfType<GM>().cursors_pos[FindObjectOfType<GM>().cursors_pos_index]);
        FindObjectOfType<GM>().cursors_pos_index++;


     
        //Rotacja rakiety
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -90;
        object_pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;

        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = (Quaternion.Euler(0, 0, angle - 90));

       

    }

    // Update is called once per frame
  
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

    }
   
    void OnTriggerEnter2D(Collider2D collider)
    {

    if(collider.gameObject.name!= "pointerRed2(Clone)")
        {
            return;
        }
      //  Debug.Log(gameObject);
      //  Debug.Log(FindObjectOfType<GM>().cursors_pos_index-1);
      ////  obj = FindObjectOfType<GM>().pointer_pos[FindObjectOfType<GM>().cursors_pos_index-1];
      //  Debug.Log(obj);
        //int index = FindObjectOfType<GM>().cursors_pos_index - 1;

     //   Debug.Log(gameObject.GetComponent<control>().ID);
        //Debug.Log(ID);
        if (collider.gameObject.GetComponent<control>().ID == ID)
        {

            Instantiate(boomObj, transform.position, boomObj.rotation);
            FindObjectOfType<GM>().rocketLive = false;
            FindObjectOfType<GM>().staticRocketL.SetActive(true);
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    }

}
