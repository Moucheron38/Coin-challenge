using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnTriggerTips : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textTips;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            textTips.text = "Appuyez sur [E] pour activer !";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            textTips.text = TipsManager.instance.tipsList[Random.Range(0, TipsManager.instance.tipsList.Count)]; ;
        }
    }

}
