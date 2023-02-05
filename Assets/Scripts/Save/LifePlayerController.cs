using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class LifePlayerController : Singleton<LifePlayerController>
{
    public HealthBase healthBase;
    public float lifePlayer;

    private void Update()
    {
        lifePlayer = healthBase.CurrentLife;
    }
}
