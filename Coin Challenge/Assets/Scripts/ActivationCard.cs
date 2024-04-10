using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationCard : MonoBehaviour, ICollectable
{
    [SerializeField] ActivationCardSO cardData;
    public bool isCollectable { get { return true; } }

    public void OnCollect()
    {
        cardData.isCollected = true;
        Destroy(this.gameObject);
    }
}
