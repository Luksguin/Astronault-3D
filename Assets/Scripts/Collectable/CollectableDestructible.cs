using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableDestructible : MonoBehaviour
{
    public HealthBase healthBase;
    public GameObject coinPrefab;
    public Transform coinPosition;
    public int coinAmount;
    public float timeBetweenCoins;

    [Header("Animation")]
    public float shakeForce;
    public float shakeDuration;
    public Ease shakeEase;

    [Header("AnimationCoin")]
    public float durationCoinAnimation;
    public Ease easeCoin;

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
        StartCoroutine(SpawnCoinsCoroutine());
    }

    IEnumerator SpawnCoinsCoroutine()
    {
        for(int i = 0; i < coinAmount; i++)
        {
            var coin = Instantiate(coinPrefab, coinPosition);
            //coin.transform.position = coinPosition.position;
            coin.transform.parent = null;
            coin.transform.DOScale(0, durationCoinAnimation).SetEase(easeCoin).From();
            yield return new WaitForSeconds(timeBetweenCoins);
        }
    }
}
