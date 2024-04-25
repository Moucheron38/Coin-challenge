using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenCtrl : MonoBehaviour
{
    [SerializeField] public TextMeshPro endTimeText;
    [SerializeField] public TextMeshPro endScoreText;
    [SerializeField] public TextMeshPro endKillCountText;
    void Start()
    {
        endScoreText.text = "Energie en surplus : " + GameManager.instance.currentUser.score;
        endKillCountText.text = "Enemies tués : " + GameManager.instance.currentUser.enemyKillCount;

        int minutes = Mathf.FloorToInt(GameManager.instance.currentUser.elapsedTime / 60);
        int seconds = Mathf.FloorToInt(GameManager.instance.currentUser.elapsedTime % 60);
        endTimeText.text = string.Format(" Terminé en :   {0:00} : {1:00}", minutes, seconds);
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) SceneManager.LoadScene("Menu");
    }


}
