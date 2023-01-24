using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public UIUpdater uiUpdater;
    public List<Collider> colliders;
    public float life;
    //public float timeToDestroy;

    public Action<HealthBase> onDamage;
    public Action<HealthBase> onKill;

    private float _currentLife;

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
    }

    private void Kill()
    {
        colliders.ForEach(i => i.enabled = false);
        //Destroy(gameObject, timeToDestroy);

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