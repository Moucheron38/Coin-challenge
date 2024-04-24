using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject _light;
    private void OnTriggerEnter(Collider other)
    {
        _light.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        _light.SetActive(true);
    }
}
