using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectable;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollectableBase coin = other.transform.GetComponent<CollectableBase>();
        if(coin != null)
        {
            coin.gameObject.AddComponent<CollectableMagnet>();
        }
    }
}
