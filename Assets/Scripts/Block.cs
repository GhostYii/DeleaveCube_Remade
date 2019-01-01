//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MoonLightGame;
using System;

[DisallowMultipleComponent]
public class Block : MonoBehaviour
{
    public bool clickable = true;
    public Color color = Color.white;
    //public OnXXXEvent onClick;

    private Material mater;
    private bool isSelected = false;
    public bool IsSelected
    { get { return isSelected; } }

    private void Start()
    {
        mater = GetComponent<Renderer>().material;
        mater.color = color;
    }

    public Material GetMaterial()
    {
        if (!mater)
            mater = GetComponent<Renderer>().material;

        return mater;
    }

    public void SetCilick(bool isClicked)
    {
        if (!clickable)
            return;

        if (isClicked)
        {
            BlockManager.Instance.currentSelected = this;
            mater.EnableKeyword("_EMISSION");
        }
        else
            mater.DisableKeyword("_EMISSION");

    }
    public void SetCilickAuto()
    {
        if (!clickable)
            return;

        isSelected = !isSelected;
        if (isSelected)
        {
            BlockManager.Instance.currentSelected = this;
            mater.EnableKeyword("_EMISSION");
        }
        else
        {
            BlockManager.Instance.currentSelected = null;
            mater.DisableKeyword("_EMISSION");
        }

    }

    private void OnDestroy()
    {
        BlockManager.Instance.blocks.Remove(this);
    }

    //private void OnMouseUpAsButton()
    //{
    //    if (!clickable)
    //        return;

    //    isSelected = !isSelected;
    //    if (isSelected)
    //    {
    //        BlockManager.Instance.currentSelected = this;
    //        mater.EnableKeyword("_EMISSION");
    //    }
    //    else
    //        mater.DisableKeyword("_EMISSION");

    //    onClick.Invoke();
    //}




}
