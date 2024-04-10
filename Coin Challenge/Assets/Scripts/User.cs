using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class User
{
    [SerializeField] public int score;
    [SerializeField] public int life;


    public User()
    {
        
        score = 0;
        life = 6;
        
    }
}
