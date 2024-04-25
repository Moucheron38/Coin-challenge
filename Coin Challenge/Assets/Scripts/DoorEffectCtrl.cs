using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorEffectCtrl : MonoBehaviour
{
    [SerializeField]
    List<Renderer> m_Renderer;

    [SerializeField]
    TextMeshPro _text;

    MaterialPropertyBlock m_PropBlock;

    static List<DoorEffectCtrl> effectList;

    private void Awake()
    {
        if (effectList == null) effectList = new List<DoorEffectCtrl>();
    }

    private void OnEnable()
    {
        effectList.Add(this);
    }

    private void OnDisable()
    {
        effectList.Remove(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_PropBlock = new MaterialPropertyBlock();
        SetState();
    }

    void SetState()
    {
        Color _color = GameManager.instance.currentUser.score < 30 ? Color.red : Color.green;
        m_Renderer[0].GetPropertyBlock(m_PropBlock);
        m_PropBlock.SetColor("_Color", _color);
        foreach (Renderer r in m_Renderer)
        {
            r.SetPropertyBlock(m_PropBlock);
        }
        _text.text = GameManager.instance.currentUser.score.ToString() + "/ 30";

        _text.color = _color;
    }

    public static void UpdateState()
    {
        foreach(var item in effectList)
        {
            item.SetState();
        }
    }
}
