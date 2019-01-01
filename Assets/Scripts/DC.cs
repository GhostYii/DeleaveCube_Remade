//ORG: ghostyii & MOONLIGHTGAME
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum RotationType
{
    Free,
    Fixed,
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}

[Serializable]
public class OnXXXEvent : UnityEvent { }

[Serializable]
public struct BlockStruct
{
    public string name;
    public GameObject model;
    public Texture texture;
    public Texture normalTexture;

    public void Init()
    {
        Renderer r = model.GetComponent<Renderer>();
        if (texture)
            r.sharedMaterial.SetTexture(Shader.PropertyToID("_MainTex"), texture);

        r.sharedMaterial.SetTexture(Shader.PropertyToID("_BumpMap"), normalTexture);
    }
}

[Serializable]
public struct ColorStruct
{
    public string name;
    public string flag;
    public Color[] colors;
}

[Serializable]
public struct PosMark
{
    public int level;
    public Vector3 position;
}

public static class DCExtentions
{
    public static Vector3 ToRatateAxis(this Direction dir)
    {
        switch (dir)
        {
            case Direction.Left:
                return Vector3.up;
            case Direction.Right:
                return Vector3.down;
            case Direction.Up:
                return Vector3.right;
            case Direction.Down:
                return Vector3.left;
            default:
                return Vector3.zero;
        }
    }
}