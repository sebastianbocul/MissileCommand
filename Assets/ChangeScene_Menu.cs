using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene_Menu : MonoBehaviour
{
    void Start()
    {

    }

   
    public void ChangeToScene(int sceneToChangeTo)
    {       
        SceneManager.LoadScene(sceneToChangeTo);
    }
  

   }
