using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestItemCoin : ChestItemBase
{
    public GameObject coin;
    public int coinAmount;
    public Vector2 randomPosition = new Vector2();

    public float startAnimationDuration;
    public Ease startAnimationEase;

    private List<GameObject> _coins = new List<GameObject>();

    public override void ShowItem()
    {
        base.ShowItem();
        CreateCoin();
    }

    public void CreateCoin()
    {
        for(int i = 0; i < coinAmount; i++)
        {
            var item = Instantiate(coin, transform);
            item.transform.position = transform.position + Vector3.forward * Random.Range(randomPosition.x, randomPosition.y) + Vector3.right * Random.Range(randomPosition.x, randomPosition.y);
            item.transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
            _coins.Add(item);
        }
    }
}
