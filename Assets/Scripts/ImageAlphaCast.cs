//ORG: CyberBizkit & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageAlphaCast : MonoBehaviour
{
    [Range(0, 1)]
    public float minAlpha = 0.1f;

    private Image img;
    
    void Start()
    {
        img = GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = minAlpha;
    }

}
