using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    public GameObject pausedMenu;
    public GameObject optionScreen;
    public string mainMenu;
    public string gameScene;
    private bool isPaused; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }
    public void PauseUnpause()
    {
        
        if (!isPaused)
        {
            pausedMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            pausedMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
    }
    public void ReGame()
    {
        SceneManager.LoadScene(gameScene);
        Time.timeScale = 1f;
    }
    public void PauseResume()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OpenOption()
    {
        optionScreen.SetActive(true);
    }
    public void QuitMain()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
