using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableMagnet : MonoBehaviour
{
    private float timeCoin = .7f;

    private void Start()
    {
        Move();
    }

    public void Move()
    {
        transform.DOMove(Player.instance.transform.position, timeCoin);
    }
}
