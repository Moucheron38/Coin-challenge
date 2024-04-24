using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playerGO;
    bool GameHasEnded = false;

    private void Awake()
    {
        instance = this;
    }

    public User currentUser
    {
        get { return UserHolder.instance.user; }
    }

    void ScoreCount()
    {
        currentUser.score++;
    }

    void KillCount()
    {
        currentUser.enemyKillCount++;
    }

    public void TimeStop()
    {
        currentUser.elapsedTime = IHM.instance.elapsedTime;
    }

    public void EndGame()
    {
        if (GameHasEnded == false)

        {

            GameHasEnded = true;
            playerGO.SetActive(false);
            gameOverPanel.SetActive(true);
            //Invoke("RestartGame", 2f);
        }
    }

    public void RestartGame()
    {
        currentUser.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
