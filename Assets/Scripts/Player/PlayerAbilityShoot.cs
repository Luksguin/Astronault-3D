using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public GunBase gunBase;
    public Transform gunPosition;

    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();
        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => InitShoot();
        inputs.Gameplay.Shoot.canceled += ctx => StopShoot();
    }

    public void CreateGun()
    {
        _currentGun = Instantiate(gunBase, gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.eulerAngles = Vector3.zero;
    }

    public void InitShoot()
    {
        _currentGun.InitShoot();
    }

    public void StopShoot()
    {
        _currentGun.CancelShoot();
    }
}