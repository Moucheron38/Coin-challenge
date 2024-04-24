using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipsManager : MonoBehaviour
{
    public List<string> tipsList;
    [SerializeField] TextMeshProUGUI textTips;
    [SerializeField] string curTips;
    public static TipsManager instance;

    public TipsManager(List<string> tipsList)
    {
        this.tipsList = tipsList;

    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        textTips.text = tipsList[Random.Range(0, 4)];

    }





}
