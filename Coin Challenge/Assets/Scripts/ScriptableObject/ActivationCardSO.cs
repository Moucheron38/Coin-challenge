using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Activation Card Asset")]

public class ActivationCardSO : ScriptableObject
{
    
    public bool isCollected;

    public void ResetDefaultValue()
    {
        isCollected = false;
    }

}
