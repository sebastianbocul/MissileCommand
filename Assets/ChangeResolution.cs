using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour
{

    public GameObject prevRes;
    public GameObject nextRes;
    public GameObject resolution;
    public GameObject resText;

    void Start()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            prevRes.SetActive(false);
            nextRes.SetActive(false);
            resolution.GetComponent<TextMesh>().text = "";
            ResolutionText.GetComponent<TextMesh>().characterSize =0;

        }

        else
        {
            prevRes.SetActive(true);
            nextRes.SetActive(true);
            resolution.GetComponent<TextMesh>().text = "RESOLUTION";
            ResolutionText.GetComponent<TextMesh>().characterSize = 0.05f;
           // ResolutionText.GetComponent<TextMesh>().alignment = TextAnchor.MiddleCenter; 
        }

        //resolutionUnique = Screen.resolutions;
        resolutions = Screen.resolutions;
        //resolutions = resolutionUnique.Distinct().ToList();
        //int index_res=0;
        //    foreach(Resolution resUniq in resolutionUnique)
        //    {

        //    foreach (Resolution res in resolutions)
        //        {
        //        if (resUniq.Equals(res))
        //          {
        //            resolutions[index_res] = resUniq;

        //            index_res++;
        //            }
        //        }
        //    }

        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);
        //  resolutions = Screen.resolutions;
        SetResolutionText(resolutions[currentResolutionIndex]);

        currentDifficultyIndex = PlayerPrefs.GetInt(DIFFICULTY_PREF_KEY, 0);
        SetDifficultyText(currentDifficultyIndex);
        Debug.Log("current index: " + currentDifficultyIndex);



    }

    #region ChangeScene
    public void ChangeToScene(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
    #endregion

    #region Attributes

    #region Player pref key constants

    private const string RESOLUTION_PREF_KEY = "resolution";

    private const string DIFFICULTY_PREF_KEY = "difficulty";


    #endregion

    #region Resolution
    [SerializeField]
    public GameObject ResolutionText;

    public Text debug_text;
    public Resolution[] resolutions = null;
    //public Resolution[] resolutionUnique = null;

    private int currentResolutionIndex = 0;

    #endregion

    #region Difficulty
    [SerializeField]
    public GameObject DifficultyText;
    public int[] difficulty = { 0, 1, 2, 3, 4, 5 };
    public int currentDifficultyIndex = 1;
    //  private IList<object> Difficulty;


    #endregion

    #endregion

    #region Resolution Cycling

    private void SetResolutionText(Resolution resolution)
    {
        ResolutionText.GetComponent<TextMesh>().text = resolutions[currentResolutionIndex].ToString();

    }

    public void SetNextResolution()
    {
        currentResolutionIndex = GetNextWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);


    }

    public void SetPreviousResolution()
    {
        currentResolutionIndex = GetPreviousWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);

    }

    public void SetNextDifficulty()
    {



        if (currentDifficultyIndex < 2) currentDifficultyIndex++;
        Debug.Log("setNextDifficulty - current index: " + currentDifficultyIndex);

        SetDifficultyText(currentDifficultyIndex);

    }


    public void SetPreviousDifficulty()
    {



        if (currentDifficultyIndex > 0) currentDifficultyIndex--;
        Debug.Log("setPrevDifficulty - current index: " + currentDifficultyIndex);
        SetDifficultyText(currentDifficultyIndex);


    }

    private void SetDifficultyText(int difficulty_pref)
    {
        //  DifficultyText.GetComponent<TextMesh>().text = difficulty[currentDifficultyIndex].ToString();
        if (difficulty_pref == 0) DifficultyText.GetComponent<TextMesh>().text = "EASY";
        else if (difficulty_pref == 1) DifficultyText.GetComponent<TextMesh>().text = "MEDIUM";
        else DifficultyText.GetComponent<TextMesh>().text = "HARD";
    }

    #endregion

    #region Apply Resolution

    private void SetAndApplyResolution(int newResolutionIndex)
    {
        currentResolutionIndex = newResolutionIndex;
        ApplyCurrentResolution();
    }

    private void ApplyCurrentResolution()
    {
        ApplyResolution(resolutions[currentResolutionIndex]);
    }

    private void ApplyResolution(Resolution resolution)
    {
        SetResolutionText(resolution);

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION_PREF_KEY, currentResolutionIndex);
    }

    #endregion

    #region Misc Helpers

    #region Index Wrap Helpers
    private int GetNextWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        return (currentIndex + 1) % collection.Count;
        //if(collection.Count > currentIndex)
        //{
        //    currentIndex++;
        //    return currentIndex;
        //}
        //else
        //{
        //    return currentIndex;
        //}
    }

    private int GetPreviousWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        if ((currentIndex - 1) < 0) return collection.Count - 1;
        return (currentIndex - 1) % collection.Count;
        //if (collection.Count > 0)
        //{
        //    currentIndex--;
        //    return currentIndex;
        //}
        //else
        //{
        //    return currentIndex;
        //}

    }
    #endregion

    #endregion

    public void ApplyChanges()
    {
        SetAndApplyResolution(currentResolutionIndex);

        PlayerPrefs.SetInt(DIFFICULTY_PREF_KEY, currentDifficultyIndex);
    }
}
