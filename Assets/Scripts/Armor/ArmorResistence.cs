using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Armor
{
    public class ArmorResistence : ArmorBase
    {
        [Header("Resistence")]
        public HealthBase playerHealth;

        protected override void Collect()
        {
            base.Collect();

            playerHealth.StartShield(duration);
        }
    }
}
