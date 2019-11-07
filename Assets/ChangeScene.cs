﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    void Start()
    {
        resolutions = Screen.resolutions;

        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);

        SetResolutionText(resolutions[currentResolutionIndex]);
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



    #endregion

    #region Resolution
    [SerializeField]
    private GameObject ResolutionText;

    private Resolution[] resolutions;

    private int currentResolutionIndex = 0;

    #endregion

    #endregion

    #region Resolution Cycling

    private void SetResolutionText(Resolution resolution)
    {
        ResolutionText.GetComponent<TextMesh>().text = resolution.width + "x" + resolution.height;
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

    }

    private int GetPreviousWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        if ((currentIndex - 1) < 0) return collection.Count - 1;
        return (currentIndex - 1) % collection.Count;


    }
    #endregion

    #endregion

    public void ApplyChanges()
    {
        SetAndApplyResolution(currentResolutionIndex);
    }
}
