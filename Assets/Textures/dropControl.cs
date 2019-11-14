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
        if (collision.gameObject.name == "boomNew(Clone)")
        {

            GetComponent<Collider2D>().enabled = false;

            FindObjectOfType<GM>().rockets += 10;
            FindObjectOfType<GM>().globalSpeed += 1f;
            FindObjectOfType<GM>().boomRange += 0f;

            //StartCoroutine(Nazwa());
            //Transform boom = Instantiate(boomObj, transform.position, boomObj.rotation);
            //boom.transform.localScale = FindObjectOfType<GM>().boomScale * 10;
            //Instantiate(boomObj, transform.position, boomObj.rotation);
            StartCoroutine(Nazwa());
            //boom.transform.localScale = FindObjectOfType<GM>().boomScale * 9;

            //timerBoom = 0;
            //if (timerBoom > 5f)
            //{
            //    Transform boom2 = Instantiate(boomObj, transform.position, boomObj.rotation);
            //    boom.transform.localScale = FindObjectOfType<GM>().boomScale * 10;
            //    timerBoom = 0;
            //}

         
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
