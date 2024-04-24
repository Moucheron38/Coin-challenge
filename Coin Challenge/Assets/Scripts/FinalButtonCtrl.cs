using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalButtonCtrl : MonoBehaviour, IActivable
{
    [SerializeField] List<ActivationCardSO> neededCards;
    [SerializeField] GameObject panelWin;
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

        panelWin.SetActive(true);
        GameManager.instance.TimeStop();

        //Charger la scène finale

    }

    private void Start()
    {
        foreach (var card in neededCards) card.ResetDefaultValue();
    }
}
