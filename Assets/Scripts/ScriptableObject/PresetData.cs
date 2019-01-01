//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PresetData :  ScriptableObject
{
    public List<ColorStruct> colorList = new List<ColorStruct>();
    public List<BlockStruct> blockList = new List<BlockStruct>();
    public List<PosMark> cameraPosition = new List<PosMark>();

    public ColorStruct? FindColorByName(string name)
    {
        foreach (var item in colorList)
        {
            if (item.name == name)
                return item;
        }

        return null;
    }

    public BlockStruct? FindBlockByName(string name)
    {
        foreach (var item in blockList)
        {
            if (item.name == name)
                return item;
        }

        return null;
    }
}
