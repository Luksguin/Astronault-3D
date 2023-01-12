using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<GunBase> guns;
    public Transform gunPosition;

    private GunBase _currentGun;
    private GunBase _selectedGun;

    protected override void Init()
    {
        base.Init();

        inputs.Gameplay.Shoot.performed += ctx => InitShoot();
        inputs.Gameplay.Shoot.canceled += ctx => StopShoot();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _selectedGun != guns[0])
        {
            _selectedGun = guns[0];
            CreateGun();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && _selectedGun != guns[1])
        {
            _selectedGun = guns[1];
            CreateGun();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && _selectedGun != guns[2])
        {
            _selectedGun = guns[2];
            CreateGun();
        }
    }

    public void CreateGun()
    {
        var actualGun = _currentGun;
        if (actualGun != null) Destroy(_currentGun.gameObject);

        _currentGun = Instantiate(_selectedGun, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.eulerAngles = Vector3.zero;
        _currentGun.transform.rotation = gunPosition.rotation;

        Debug.Log(_currentGun);
    }

    public void InitShoot()
    {
        if(_selectedGun != null)
            _currentGun.InitShoot();
    }

    public void StopShoot()
    {
        if (_selectedGun != null)
            _currentGun.CancelShoot();
    }
}