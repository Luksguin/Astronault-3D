using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationEnemy;

namespace Enemy
{
    public class EnemyShoot : EnemyBase
    {
        [Header("Shooter")]
        public GunBase gun;

        private void Start()
        {
            Shoot();
        }

        public void Shoot()
        {
            gun.InitShoot();
            PlayAnimationByTrigger(AnimationType.ATTACK);
        }
        protected override void Update()
        {
            base.Update();

            if (currentLife <= 0) gun.CancelShoot();
        }
    }
}
