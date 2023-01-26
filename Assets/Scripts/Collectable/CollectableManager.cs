using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class CollectableManager : Singleton<CollectableManager>
{
    public SOInt currentCoins;
    public SOInt specialCoins;
    public TextMeshProUGUI coinAmount;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        currentCoins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        //coinAmount.text = currentCoins.value.ToString();
        currentCoins.value += amount;
    }
}
