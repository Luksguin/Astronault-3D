using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunRocket : ReloadGun
{
    public ProjectilleBase projectilleBase;
    public float size;

    public override void Shoot()
    {
        var projectille = Instantiate(projectillePrefab, positionShoot);
        projectille.transform.localScale = Vector3.zero;

        projectille.transform.DOScale(size, projectilleBase.timeToDestroy);

        projectille.transform.position = positionShoot.transform.position;
        projectille.transform.parent = null;
    }
}
