using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIUpdater : MonoBehaviour
{
    public enum UIType
    { 
        LIFE,
        GUN
    }

    public UIType uiType;
    public Image image;
    public float duration;
    public Ease ease;

    private Tween _currTween;

    private void OnValidate()
    {
        if (image == null) image = GetComponent<Image>();
    }

    public void UpdateImage(float f)
    {
        image.fillAmount = f;
    }

    public void UpdateValue(float max, float current)
    {
        if (_currTween != null) _currTween.Kill();
        _currTween = image.DOFillAmount(1 - (current / max), duration).SetEase(ease);
    }
}
