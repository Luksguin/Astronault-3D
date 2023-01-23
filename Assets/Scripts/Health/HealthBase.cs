using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public List<Collider> colliders;

    public Action<HealthBase> onDamage;
    public Action<HealthBase> onKill;

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
        colliders.ForEach(i => i.enabled = false);
        Destroy(gameObject, timeToDestroy);

        onKill?.Invoke(this);
    }

    private void StartDamage(int damage)
    {
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