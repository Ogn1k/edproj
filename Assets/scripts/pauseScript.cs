using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject menuObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void Resume()
    {
        menuObj.SetActive((false));
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void pause()
    {
        menuObj.SetActive((true));
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
