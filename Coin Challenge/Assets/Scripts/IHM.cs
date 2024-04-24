using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IHM : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    //[SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public float elapsedTime;
    [SerializeField] LifeSystem lifeSystem;

    public static IHM instance;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        UpdateIHM();
        //UpdateLife(lifeSystem);

    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format(" Temps écoulé : {0:00} : {1:00}", minutes, seconds);
    }

    public void UpdateIHM()
    {
        scoreText.text = "Energie : " + GameManager.instance.currentUser.score;

    }

    
}
