using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileControl : MonoBehaviour
{


    public Vector3 testPosition = new Vector3(0, 0, -10);
    // Start is called before the first frame update
    void Start()
    {
        GM.targetPosition = GM.objPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position,GM.targetPosition, .01f);
    }
}
