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

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        curTips = tipsList[Random.Range(0, tipsList.Count)];
        textTips.text = curTips;
    }

    
    
}
