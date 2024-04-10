using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trap : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTrap;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            textTrap.text = "Ne croyez pas tout ce qui est écrit.";
        }
    }

}
