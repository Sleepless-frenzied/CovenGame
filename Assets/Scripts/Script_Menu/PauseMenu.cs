using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    private Animator animator;
    void Start()
    {
        animator = PauseMenuUI.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //DontDestroyOnLoad(gameObject);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*if (!PauseMenuUI.activeSelf)
            {
                PauseMenuUI.SetActive(true);
            }
            else
            {
                animator.SetTrigger("Trigger");
                StartCoroutine(wait());
            }*/
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
        PauseMenuUI.SetActive(false);
        Time.timeScale = (1f);
        GameIsPaused = (false);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        //Time.timeScale = (0f);
        GameIsPaused = (true);
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.25f);
        PauseMenuUI.SetActive(false);
    }
    
    
}
