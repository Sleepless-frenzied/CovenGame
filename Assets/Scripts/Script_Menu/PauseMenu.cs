using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DontDestroyOnLoad(gameObject);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = (1f);
        GameIsPaused = (false);
    }

    void Pause()
    {
        PauseMenuUi.SetActive(true);
        //Time.timeScale = (0f);
        GameIsPaused = (true);
    }
    
}
