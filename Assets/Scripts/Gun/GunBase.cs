using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectilleBase projectillePrefab;
    public Transform positionShoot;
    //public float timeToDestroyProjectille;
    public float timeBetweenShoot;

    protected Coroutine _currentCoroutine;
    private void Update()
    {
        //projectillePrefab.timeToDestroy = timeToDestroyProjectille;
    }

    protected virtual IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public virtual void Shoot()
    {
        var projectille = Instantiate(projectillePrefab);
        projectille.transform.position = positionShoot.transform.position;
        projectille.transform.rotation = positionShoot.transform.rotation;
    }

    public void InitShoot()
    {
        CancelShoot();
        _currentCoroutine = StartCoroutine(StartShoot());
    }

    public void CancelShoot()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }
}
