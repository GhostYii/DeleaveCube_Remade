//ORG: CyberBizkit & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class button : MonoBehaviour
{
    public Transform self;
    public Transform leftTrans;
    public Transform centerTrans;
    public Transform rightTrans;

    [Range(0.1f, 1f)]
    public float duration = 0.5f;

    public void UITweenR2C(GameObject target)
    {
        target.transform.position = leftTrans.position;
        Sequence seq = DOTween.Sequence();
        Tweener selfMoveTweener = self.DOMoveX(rightTrans.position.x, duration);
        selfMoveTweener.SetEase(Ease.OutBack);
        Tweener targetMoveTweener = target.transform.DOMoveX(centerTrans.position.x, duration);
        targetMoveTweener.SetEase(Ease.OutBack);

        seq.Append(selfMoveTweener);
        seq.Join(targetMoveTweener);
    }

    public void UITweenC2L(GameObject target)
    {
        target.transform.position = rightTrans.position;
        Sequence seq = DOTween.Sequence();
        Tweener targetMoveTweener = target.transform.DOMoveX(centerTrans.position.x, duration);
        targetMoveTweener.SetEase(Ease.OutBack);
        Tweener selfMoveTweener = self.DOMoveX(leftTrans.position.x, duration);
        selfMoveTweener.SetEase(Ease.OutBack);

        seq.Append(targetMoveTweener);
        seq.Join(selfMoveTweener);
        

    }
}
