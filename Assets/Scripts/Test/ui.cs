//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour 
{
    public void 充钱(Text text)
    {
        text.text = "充钱";
    }

    public void 开始(Text text)
    {
        text.text = "开始";
    }

    public void Print(string str)
    {
        print(str);
    }

}
