using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGun : GunBase
{
    public int maxAmount;
    public float timeOfReload;

    private int _currentAmount;
    private bool _isReloading = false;

    protected override IEnumerator StartShoot()
    {
        if (_isReloading == true) yield break;

        while (true)
        {
            Shoot();
            _currentAmount++;
            CheckReload();
            yield return new WaitForSeconds(timeBetweenShoot);
        }

    }

    public void CheckReload()
    {
        if (_currentAmount >= maxAmount)
        {
            StopCoroutine(StartShoot());
            StartReload();
        }
    }

    public void StartReload()
    {
        _isReloading = true;
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        var time = 0f;
        while (time <= timeOfReload)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _isReloading = false;
        _currentAmount = 0;
    }
}
