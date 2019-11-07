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
        transform.rotation = (Quaternion.Euler(0, 0, angle - 90));

    }

    // Update is called once per frame
    private float speed = 7.5f;
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, GM.targetPosition, speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "pointerRed2(Clone)" || transform.position.Equals(GM.targetPosition))
        {
            Destroy(gameObject);
            Instantiate(boomObj, transform.position, boomObj.rotation);
            FindObjectOfType<GM>().rocketLive = false;
            FindObjectOfType<GM>().staticRocketL.SetActive(true);
            Destroy(gameObject);
        }
    }

}
