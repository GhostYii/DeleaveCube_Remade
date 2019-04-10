//ORG: CyberBizkit & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Button))]
public class ButtonTweener : MonoBehaviour
{
    public Transform self;
    public Transform target;
    public UIAnimType animationType = UIAnimType.None;
    public Ease ease = Ease.OutBack;
    [Range(0f, 2f)]
    public float duration = 0.35f;

    private Button uiElem;

    private void Start()
    {
        uiElem = GetComponent<Button>();
        switch (animationType)
        {
            case UIAnimType.None:
                break;
            case UIAnimType.R2C:               
                uiElem.onClick.AddListener(delegate () { Right2Center(target); });
                break;
            case UIAnimType.C2L:
                uiElem.onClick.AddListener(delegate () { Center2Left(target); });
                break;
            case UIAnimType.C2R:
                uiElem.onClick.AddListener(delegate () { Center2Right(target); });
                break;
            case UIAnimType.L2C:
                uiElem.onClick.AddListener(delegate () { Left2Center(target); });
                break;
            default:
                break;
        }
    }

    public void Right2Center(Transform target)
    {
        target.position = UIController.Instance.leftTrans.position;
        Sequence seq = DOTween.Sequence();
        Tweener selfMoveTweener = self.DOMoveX(UIController.Instance.rightTrans.position.x, duration);
        selfMoveTweener.SetEase(ease);
        Tweener targetMoveTweener = target.DOMoveX(UIController.Instance.centerTrans.position.x, duration);
        targetMoveTweener.SetEase(ease);

        seq.Append(selfMoveTweener);
        seq.Join(targetMoveTweener);
    }

    public void Center2Left(Transform target)
    {
        target.position = UIController.Instance.rightTrans.position;
        Sequence seq = DOTween.Sequence();
        Tweener targetMoveTweener = target.DOMoveX(UIController.Instance.centerTrans.position.x, duration);
        targetMoveTweener.SetEase(ease);
        Tweener selfMoveTweener = self.DOMoveX(UIController.Instance.leftTrans.position.x, duration);
        selfMoveTweener.SetEase(ease);

        seq.Append(targetMoveTweener);
        seq.Join(selfMoveTweener);
    }

    public void Center2Right(Transform target)
    {
        target.position = UIController.Instance.leftTrans.position;
        Sequence seq = DOTween.Sequence();
        Tweener targetMoveTweener = target.DOMoveX(UIController.Instance.centerTrans.position.x, duration);
        targetMoveTweener.SetEase(ease);
        Tweener selfMoveTweener = self.DOMoveX(UIController.Instance.rightTrans.position.x, duration);
        selfMoveTweener.SetEase(ease);

        seq.Append(targetMoveTweener);
        seq.Join(selfMoveTweener);
    }

    public void Left2Center(Transform target)
    {
        target.position = UIController.Instance.centerTrans.position;
        Sequence seq = DOTween.Sequence();
        Tweener selfMoveTweener = self.DOMoveX(UIController.Instance.centerTrans.position.x, duration);
        selfMoveTweener.SetEase(ease);
        Tweener targetMoveTweener = target.DOMoveX(UIController.Instance.rightTrans.position.x, duration);
        targetMoveTweener.SetEase(ease);

        seq.Append(selfMoveTweener);
        seq.Join(targetMoveTweener);
    }
}

[System.Serializable]
public enum UIAnimType
{
    None,
    L2C,
    R2C,
    C2L,
    C2R,
}
