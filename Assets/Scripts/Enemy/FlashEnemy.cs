using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashEnemy : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Color endColor;
    public float duration;

    private Color defaultColor;
    private Tween _currTween;

    private void Update()
    {
        defaultColor = meshRenderer.material.GetColor("_EmissionColor");
    }

    public void Flash()
    {
        if(!_currTween.IsActive())
            meshRenderer.material.DOColor(endColor,"_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
