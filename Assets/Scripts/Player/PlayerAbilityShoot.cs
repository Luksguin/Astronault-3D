using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public GunBase gunBase;

    protected override void Init()
    {
        base.Init();

        inputs.Gameplay.Shoot.performed += ctx => InitShoot();
        inputs.Gameplay.Shoot.canceled += ctx => StopShoot();
    }

    public void InitShoot()
    {
        gunBase.InitShoot();
    }

    public void StopShoot()
    {
        gunBase.CancelShoot();
    }
}