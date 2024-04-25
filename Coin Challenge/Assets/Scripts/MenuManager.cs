using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private string SceneToLoad;
    public GameObject optionPanel;




    public void ChangeScene()

    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionMenu()

    {
        optionPanel.SetActive(true);
    }

    public void QuitOption()
    {
        optionPanel.SetActive(false);
    }

    




}

