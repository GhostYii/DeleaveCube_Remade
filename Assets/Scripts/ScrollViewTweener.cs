//ORG: CyberBizkit & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(ScrollRect))]
public class ScrollViewTweener : MonoBehaviour
{
    public int rowCount = 1, colCount = 1;
    public RectTransform content;

    private ScrollRect scrollRect;

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(OnValueChanged);
    }

    public void OnValueChanged(Vector2 v)
    {
        print(v);        
    }

}
