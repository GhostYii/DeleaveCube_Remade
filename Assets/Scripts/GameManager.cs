//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonLightGame;

public class GameManager : MonoBehaviour 
{
    public PresetData data;    

    private static GameManager instance;
    public static GameManager Instance
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
            MLLogger.Log("ERROR", "gamemanager already exist." + instance.gameObject.name + "will be destory.");
            Destroy(instance.gameObject);
        }

    }

}
