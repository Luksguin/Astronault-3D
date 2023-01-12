using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGun : GunBase
{
    public List<UIGun> uIGuns;

    public int maxAmount;
    public float timeOfReload;

    private int _currentAmount;
    private float _shootTime;
    private bool _isReloading = false;

    private void Awake()
    {
        GetAllUIs();
    }

    protected override IEnumerator StartShoot()
    {
        if (_isReloading == true) yield break;

        float timeSinceLastTime = Time.time - _shootTime;
        if (timeSinceLastTime < timeBetweenShoot)
        {
            yield return new WaitForSeconds(timeBetweenShoot - timeSinceLastTime);
        }

        while (true)
        {
            Shoot();
            _currentAmount++;
            CheckReload();
            _shootTime = Time.time;
            UpdateUI();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    
    public void CheckReload()
    {
        if (_currentAmount >= maxAmount)
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
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
        float time = 0f;
        while (time <= timeOfReload)
        {
            time += Time.deltaTime;
            uIGuns.ForEach(i => i.UpdateImage(time/timeOfReload));
            yield return new WaitForEndOfFrame();
        }

        _isReloading = false;
        _currentAmount = 0;
    }

    public void UpdateUI()
    {
        uIGuns.ForEach(i => i.UpdateValue(maxAmount, _currentAmount));
    }

    public void GetAllUIs()
    {
        uIGuns = GameObject.FindObjectsOfType<UIGun>().ToList();
    }
}