using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerGame : MonoBehaviour
{

    public GameObject pauseMenu, panelEnd;

    public bool isPaused;
    public void Restart()
    {
        // Redémarrer la partie
        panelEnd.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }



    void Start()
    {
        pauseMenu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }

            else
            {
                pauseGame();
            }
        }
    }

    public void pauseGame()

    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resumeGame()

    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        GameManager.instance.currentUser.score = 0;
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
