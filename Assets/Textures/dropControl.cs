using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropControl : MonoBehaviour
{
    public float timerBoom = 0;

    public Transform boomObj;

    // Start is called before the first frame update
    void Start()
    {
        timerBoom = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0   , -1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        timerBoom += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("KOLIZJA Z " + gameObject.name);
        if (collision.gameObject.name == "boomNew(Clone)")
        {

            GetComponent<Collider2D>().enabled = false;
            if (gameObject.name == "dropAmmo(Clone)")
            {
                FindObjectOfType<GM>().rockets += 10;
                Destroy(gameObject);
            }
            if (gameObject.name == "drupGas(Clone)")
            {
                FindObjectOfType<GM>().globalSpeed += 1f;
                Destroy(gameObject);
            }
            if (gameObject.name == "drupFire(Clone)")
            {
                FindObjectOfType<GM>().boomRange += 0.5f;
                Destroy(gameObject);
            }
            if (gameObject.name == "drupSkull(Clone)")
            {
                StartCoroutine(Nazwa());
            }

            

      
         
        }

    }

    private IEnumerator Nazwa()
    {
        Transform boom = Instantiate(boomObj, transform.position, boomObj.rotation);
        boom.transform.localScale = FindObjectOfType<GM>().boomScale * 10;
        GetComponent<Renderer>().enabled = false;
       
        yield return new WaitForSecondsRealtime(0.3f);
        Transform boom2 = Instantiate(boomObj, transform.position, boomObj.rotation);
        boom2.transform.localScale = FindObjectOfType<GM>().boomScale * 5;
        Destroy(gameObject);
    }
}
