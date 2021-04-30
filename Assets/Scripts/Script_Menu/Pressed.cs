using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pressed : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus = new List<GameObject>();

    public Animator MainButton;
    public Animator SoloButton;
    public Animator MultiButton;
    private static readonly int Highlighted = Animator.StringToHash("Highlighted");

    private void Update()
    {
        /*if (MainButton.GetBool("Highlighted") || SoloButton.GetBool("Highlighted") ||
            MultiButton.GetBool("Highlighted"))*/
        if (MainButton.GetBool(Highlighted) || SoloButton.GetBool(Highlighted) ||
            MultiButton.GetBool(Highlighted))
        {
            Invoke("activate",0.5f);
        }
        else
        {
            Invoke("desactivate",0f);
        }
    }

    public void activate()
    {
        SoloButton.gameObject.SetActive(true);
        MultiButton.gameObject.SetActive(true);
    }

    public void desactivate()
    {
        SoloButton.gameObject.SetActive(false);
        MultiButton.gameObject.SetActive(false);
    }

    public void Solo()
    {
        SceneManager.LoadScene("MAP");
        Scene apercu = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + apercu.name + "'.");
    }
    public void OpenPage(string url)
    {
        Application.OpenURL(url);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SwitchMenu(string obj)
    {
        foreach (var Go in menus)
        {
            Time.timeScale = (1f);
            Go.SetActive(Go.name==obj);
            PauseMenu.GameIsPaused = false;
        }
    }

    public void Button_Back()
    {
        if (SceneManager.GetActiveScene().name != "Main_Menu")
        {
            gameObject.SetActive(false);
        }
        else
        {
            SwitchMenu("MainMenu");
        }
    }

}
