using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileControl : MonoBehaviour
{
    public float timeKeeper = 0;
    public float fracDist = 0.01f;


    public Transform boomObj;
    public Vector3 testPosition = new Vector3(-5.76f, -4.4f, 0);




    // Start is called before the first frame update
    void Start()
    {
        GM.targetPosition = GM.objPosition;
        fracDist = 0.01f;
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -15); 
    }
   
    // Update is called once per frame
    void Update()
    {

        timeKeeper += Time.deltaTime;

        if (timeKeeper > 0.05)
        {
            fracDist += 0.02f;
            timeKeeper = 0;
        }
        if (gameObject == null)
        {
            Debug.Log("Null Objcet");
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, GM.targetPosition, fracDist);
        }
       

    }

   void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "pointerRed2(Clone)")
        {
            Destroy (gameObject);
            Instantiate(boomObj, transform.position, boomObj.rotation);
            FindObjectOfType<GM>().rocketLive = false;
      

        }
    }

}
