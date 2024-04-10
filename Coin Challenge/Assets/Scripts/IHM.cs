using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IHM : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float remainingTime;
    [SerializeField] LifeSystem lifeSystem;

    public static IHM instance;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        UpdateIHM();
        UpdateLife(lifeSystem);

    }

    private void Update()
    {

    if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

    else if (remainingTime < 0)
        {
            remainingTime = 0;
            // GameOver
            timerText.color = Color.red;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format(" Temps Restant : {0:00} : {1:00}", minutes, seconds);
    }

    public void UpdateIHM()
    {
        scoreText.text = "Energie : " + GameManager.instance.currentUser.score;
        
    }

    public void UpdateLife(LifeSystem lifeSystem)
    {
        lifeText.text = "Vie : " + lifeSystem.life;
    }
}
