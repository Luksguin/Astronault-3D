using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public Action<HealthBase> onDamage;
    public Action<HealthBase> onKill;

    public FlashColor flashColor;

    public int life;
    public float timeToDestroy;

    private float _currentLife;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    private void ResetLife()
    {
        _currentLife = life;
    }

    private void Kill()
    {
        Destroy(gameObject, timeToDestroy);

        onKill?.Invoke(this);
    }

    private void StartDamage(int damage)
    {
        if (flashColor != null) flashColor.Flash();
        _currentLife -= damage;

        onDamage?.Invoke(this);

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    #region INTERFACE
    void IDamageable.Damage(int damage) { }

    public void DamageVector(int damage, Vector3 dir)
    {
        StartDamage(damage);
    }
    #endregion 
}