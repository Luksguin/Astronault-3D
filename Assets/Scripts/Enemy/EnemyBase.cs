using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBase : MonoBehaviour
{
    public int life;
    private int _currentLife;

    [Header("Animation")]
    public float duration;
    public Ease ease;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        ResetLife();
        StartAnimation();
    }

    private void ResetLife()
    {
        _currentLife = life;
    }

    private void Kill()
    {
        OnKill();
    }

    protected virtual void OnKill()
    {
        Destroy(gameObject);
    }

    protected virtual void OnDamage(int damage)
    {
        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }

    public void StartAnimation()
    {
        gameObject.transform.DOScale(0, duration).SetEase(ease).From();
    }
}
