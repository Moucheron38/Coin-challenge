using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHolder : MonoBehaviour
{
    public User user;
    public static UserHolder instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
}
