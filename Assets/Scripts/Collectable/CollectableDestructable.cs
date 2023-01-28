using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableDestructable : MonoBehaviour
{
    public HealthBase healthBase;
    public float shakeForce;
    public float shakeDuration;
    public Ease shakeEase;

    private void Awake()
    {
        healthBase.onDamage += OnDamage;
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        OnDamage(healthBase);
    }

    public void OnDamage(HealthBase h)
    {
        transform.DOScaleY(shakeForce, shakeDuration).SetEase(shakeEase).SetLoops(2, LoopType.Yoyo);
    }
}
