using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ebac.Core.Singleton;

public class HealthBase : Singleton<HealthBase>, IDamageable
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

    //[Header("Save")]
    //public bool isPlayer = false;

    protected override void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
        SaveLife();
    }

    #region PLAYER
    public void ResetLife()
    {
        _currentLife = life;
        UiUpdate(_currentLife, life);
    }

    public void StartShield(float duration)
    {
        StartCoroutine(ShieldCoroutine(duration));
    }

    IEnumerator ShieldCoroutine(float duration)
    {
        var normalLife = _currentLife;
        _currentLife = 100;
        yield return new WaitForSeconds(duration);
        _currentLife = normalLife;
    }

    #region SAVE
    public void SaveLife()
    {
        SaveManager.instance.Setup.lifePlayer = _currentLife;
        Debug.Log(SaveManager.instance.Setup.lifePlayer);
    }

    public void ReadLife()
    {
        UiUpdate(SaveManager.instance.Setup.lifePlayer, life);
    }

    public float CurrentLife
    {
        get { return _currentLife; }
    }
    #endregion
    #endregion

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

        UiUpdate(_currentLife, life);
        onDamage?.Invoke(this);

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    public void UiUpdate(float currLife, float life)
    {
        if (uiUpdater != null)
            uiUpdater.UpdateImage((float)currLife / life);
    }

    #region INTERFACE
    void IDamageable.Damage(int damage) { }

    public void DamageVector(int damage, Vector3 dir)
    {
        StartDamage(damage);
    }
    #endregion 
}