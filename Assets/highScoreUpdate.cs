using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScoreUpdate : MonoBehaviour
{

    public GameObject highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
