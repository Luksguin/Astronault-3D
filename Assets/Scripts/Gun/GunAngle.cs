using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAngle : ReloadGun 
{
    public float shootAmount;
    public float angle;
    public float speed;

    public override void Shoot()
    {
        int mult = 0;

        for (int i = 0; i < shootAmount; i++)
        {
            if(i % 2 == 0)
            {
                mult++;
            }

            var projectille = Instantiate(projectillePrefab, positionShoot);

            projectille.transform.position = positionShoot.transform.position;
            projectille.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;

            projectille.speed = speed;
            projectille.transform.parent = null;
        }
    }
}