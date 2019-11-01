using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    // Change To Scene
    public void ChangeToScene(int sceneToChangeTo)
    {

      ///  Application.LoadLevel(sceneToChangeTo);
       
        SceneManager.LoadScene(sceneToChangeTo);

    }
}
