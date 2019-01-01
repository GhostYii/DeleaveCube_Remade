//ORG: CyberBizkit & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoonLightGame;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    public static UIController Instance
    {
        get
        {
            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    public Image colorTip;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
        {
            MLLogger.Log("ERROR", "uicontroller already exist." + instance.gameObject.name + "will be destory.");
            Destroy(instance.gameObject);
        }
    }

    private void Update()
    {
        if (colorTip)
            colorTip.color = BlockManager.Instance.currentSelected ? BlockManager.Instance.currentSelected.color : Color.clear;
    }
}
