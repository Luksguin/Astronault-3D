using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunRocket : ReloadGun
{
    public ProjectileBase projectilleBase;
    public float size;

    public override void Shoot()
    {
        var projectile = Instantiate(projectillePrefab, positionShoot);
        projectile.transform.localScale = Vector3.zero;

        projectile.transform.DOScale(size, projectilleBase.timeToDestroy);

        projectile.transform.position = positionShoot.transform.position;
        projectile.transform.parent = null;
    }
}
