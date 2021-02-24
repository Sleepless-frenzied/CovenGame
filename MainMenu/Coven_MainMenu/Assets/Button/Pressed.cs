using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pressed : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus = new List<GameObject>();
    
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
            Go.SetActive(Go.name==obj);
        }
    }

    /*public void Test(int index)
    {
        for (int i = 0 ; i < menus.Count;i++)
            menus[i].SetActive((i==index));
    }*/ 
}
