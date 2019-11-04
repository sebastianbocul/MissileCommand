using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartScores : MonoBehaviour
{

    public GameObject highScore;
    
    public void restartScore()
    {
      //  PlayerPrefs.DeleteKey("HighScores");
        PlayerPrefs.DeleteAll();
        highScore.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }
}
