using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Armor
{
    public class ArmorSpeed : ArmorBase 
    {
        [Header("Speed")]
        //public ArmorPlayer armorPlayer;
        //public ArmorSetup setup;
        public float speed;
        public float duration;

        protected override void Collect()
        {
            base.Collect();

            var setup = ArmorManager.instance.GetByType(armorType);

            Player.instance.UpdateArmor(setup, duration);
            Player.instance.UpSpeed(speed, duration);

            //armorPlayer.ChangeArmor(type);
        }
    }
}
