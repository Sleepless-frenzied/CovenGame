using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public TMP_Text progressTxt;

    public void LoadLevel(string SceneName)
    {
        StartCoroutine(LoadAsynchronously(SceneName));
    }

    IEnumerator LoadAsynchronously(string SceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01((operation.progress / .9f));

            slider.value = progress;
            progressTxt.text = progress * 100f+ "%";

            yield return null;
        }
        
    }
}
