using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    void RocketsUpdate()
    {
        if (FindObjectOfType<GM>().rockets > 0)
        {
            FindObjectOfType<GM>().rockets--;
        }
    }


}
