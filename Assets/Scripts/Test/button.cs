//ORG: CyberBizkit & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG;
using System;

public class button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //public Transform root;
    public RectTransform leftPos, midPos, rightPos;
    public GameObject leftPanel, rightPanel;

    private Vector2 orignLeft, orignRight;
    //private Transform orignParent;

    private void Start()
    {
        if (leftPos) orignLeft = leftPanel.GetComponent<RectTransform>().anchoredPosition;
        if (rightPos) orignRight = rightPanel.GetComponent<RectTransform>().anchoredPosition;
        //orignParent = transform.parent;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //transform.parent = root;

        if (leftPanel)
            leftPanel.GetComponent<RectTransform>().anchoredPosition = leftPos.anchoredPosition;
        if (rightPanel)
            rightPanel.GetComponent<RectTransform>().anchoredPosition = rightPos.anchoredPosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //transform.parent = orignParent;

        if (leftPanel)
            leftPanel.GetComponent<RectTransform>().anchoredPosition = orignLeft;
        if (rightPanel)
            rightPanel.GetComponent<RectTransform>().anchoredPosition = orignRight;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (leftPos)
        {

        }
    }
}
