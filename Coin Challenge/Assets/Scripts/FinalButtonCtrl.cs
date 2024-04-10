using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalButtonCtrl : MonoBehaviour, IActivable
{
    [SerializeField] List<ActivationCardSO> neededCards;
    private bool isActivable
    {
        get
        {
            foreach (var card in neededCards)
            {
                if (!card.isCollected) return false;
            }

            return true;
        }
    }


    public void OnActivated()
    {
        if (!isActivable) return;

    }

    private void Start()
    {
        foreach (var card in neededCards) card.ResetDefaultValue();
    }
}
