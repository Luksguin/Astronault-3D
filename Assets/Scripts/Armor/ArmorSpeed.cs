using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Armor
{
    public class ArmorSpeed : ArmorBase 
    {
        [Header("Speed")]
        public float newSpeed;

        protected override void Collect()
        {
            base.Collect();

            Player.instance.UpdateSpeed(newSpeed, duration);
        }
    }
}
