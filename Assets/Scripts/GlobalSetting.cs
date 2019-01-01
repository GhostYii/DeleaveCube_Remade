//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonLightGame;

public class GlobalSetting : MonoBehaviour 
{
    private static GlobalSetting instance;
    public static GlobalSetting Instance
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

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
        {
            MLLogger.Log("ERROR", "globalsetting already exist." + instance.gameObject.name + "will be destory.");
            Destroy(instance.gameObject);
        }

    }
}
