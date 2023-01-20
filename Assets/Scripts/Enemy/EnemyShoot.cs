using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyShoot : EnemyBase
    {
        [Header("Shooter")]
        public GunBase gun;

        private void Start()
        {
            gun.InitShoot();
        }
    }
}
