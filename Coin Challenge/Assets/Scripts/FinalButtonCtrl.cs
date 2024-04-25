using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Invoke("EndGame", 5f);


    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }

    private void Start()
    {
        foreach (var card in neededCards) card.ResetDefaultValue();
    }
}
