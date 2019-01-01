//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonLightGame;
using DG.Tweening;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public float duration = 1.5f;
    public RotationController rc;

    private Vector3 realPos = Vector3.zero;

    private void Start()
    {
        if (!rc)
        {
            MLLogger.Log("warning", "rotation controller not found.[STOP WILL BE TRUE]");
            rc.isStop = true;
        }
        realPos = GameManager.Instance.data.cameraPosition[BlockManager.Instance.level].position;
        transform.position = realPos;
    }

}