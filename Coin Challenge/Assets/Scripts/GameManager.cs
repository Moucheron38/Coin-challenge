using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public User currentUser;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playerGO;
    bool GameHasEnded = false;

    private void Awake()
    {
        instance = this;
    }

    void ScoreCount()
    {
        currentUser.score++;
    }

    public void EndGame()
    {
        if (GameHasEnded == false)

        {

            GameHasEnded = true;
            playerGO.SetActive(false);
            gameOverPanel.SetActive(true);
            Invoke("RestartGame", 2f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
