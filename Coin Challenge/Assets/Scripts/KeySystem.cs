using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeySystem : MonoBehaviour, ICollectable
{
    public UnityEvent pickupKey;
    [SerializeField] int scoreValue;

    public bool isCollectable { get { return true; } }

    public void OnCollect()
    {
        pickupKey.Invoke();
        GameManager.instance.currentUser.score = GameManager.instance.currentUser.score + scoreValue;
        IHM.instance.UpdateIHM();

    }


}
