using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class User
{
    [SerializeField] public int score;
    [SerializeField] public int life;
    [SerializeField] public int enemyKillCount;
    [SerializeField] public float elapsedTime;


    public User()
    {

        score = 0;
        elapsedTime = 0;
        enemyKillCount = 0;
        life = 6;
        
    }
}
