using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject[] Key;
    void Start()
    {
        Instantiate(Key[Random.Range(0, Key.Length)], transform.position, Quaternion.identity); ;
    }

    
}
