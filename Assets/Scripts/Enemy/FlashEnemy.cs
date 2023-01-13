using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashEnemy : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Color endColor;
    public float duration;

    public void Flash()
    {
        meshRenderer.material.DOColor(endColor,"_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
