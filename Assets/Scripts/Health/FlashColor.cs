using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinned;
    public Color endColor;
    public float duration;

    private Tween _currTween;

    private void OnValidate()
    {
        if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
        if (skinned == null) skinned = GetComponent<SkinnedMeshRenderer>();
    }

    public void Flash()
    {
        if(meshRenderer != null && !_currTween.IsActive())
            _currTween = meshRenderer.material.DOColor(endColor,"_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);

        if (skinned != null && !_currTween.IsActive())
            _currTween = skinned.material.DOColor(endColor, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
