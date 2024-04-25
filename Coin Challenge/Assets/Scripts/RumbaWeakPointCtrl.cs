using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbaWeakPointCtrl : MonoBehaviour
{
    [SerializeField] GameObject rumba;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerFeet"))

        {
            GameManager.instance.currentUser.enemyKillCount++;
            Destroy(rumba);
        }
    }
}
