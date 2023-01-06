using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectilleBase projectillePrefab;
    public Transform positionShoot;
    public float timeBetweenShoot;

    private Coroutine _currentCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectille = Instantiate(projectillePrefab);
        projectille.transform.position = positionShoot.transform.position;
        projectille.transform.rotation = positionShoot.transform.rotation;
    }
}
