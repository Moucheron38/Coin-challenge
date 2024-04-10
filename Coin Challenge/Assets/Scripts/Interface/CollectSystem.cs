using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollectable CollectableObject = other.GetComponent<ICollectable>();

        if (CollectableObject == null) return;

        if (!CollectableObject.isCollectable) return;

        CollectableObject.OnCollect();
    }
}
