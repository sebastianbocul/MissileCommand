﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "anti_missile_L(Clone)" || collider.gameObject.name == "anti_missile_R(Clone)")
        {
            Destroy(gameObject);
        }
        
    }
}
