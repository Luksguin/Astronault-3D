using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthBase : MonoBehaviour, IDamageable
{
    public UIUpdater uiUpdater;
    public List<Collider> colliders;
    public float life;
    public float timeToDestroy;
    public bool destroy;

    public Action<HealthBase> onDamage;
    public Action<HealthBase> onKill;

    [Header("DeathAnimation")]
    public float duration;
    public Ease ease;
    public bool destroyAnimation = false;

    [SerializeField]private float _currentLife;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        _currentLife = life;
        if (uiUpdater != null)
            uiUpdater.UpdateImage((float)_currentLife / life);
    }

    private void Kill()
    {
        colliders.ForEach(i => i.enabled = false);
        if(destroyAnimation == true) transform.DOScale(0, duration).SetEase(ease);
        if(destroy == true) Destroy(gameObject, timeToDestroy);

        onKill?.Invoke(this);
    }

    public void StartDamage(int damage)
    {
        _currentLife -= damage;

        UiUpdate();
        onDamage?.Invoke(this);

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    public void UiUpdate()
    {
        if (uiUpdater != null)
            uiUpdater.UpdateImage((float)_currentLife / life);
    }

    #region INTERFACE
    void IDamageable.Damage(int damage) { }

    public void DamageVector(int damage, Vector3 dir)
    {
        StartDamage(damage);
    }
    #endregion 
}