using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Armor
{
    public class ArmorBase : MonoBehaviour
    {
        public ArmorType armorType;
        public Collider myCollider;
        public MeshRenderer meshRenderer;
        public string playerTag;
        public float duration;

        public ArmorType lastType;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.tag == playerTag)
            {
                Collect();
            }
        }

        protected virtual void Collect()
        {
            var setup = ArmorManager.instance.GetByType(armorType);
            Player.instance.UpdateArmor(setup, duration);

            lastType = setup.armorType;

            DestroyObject();
        }

        public void DestroyObject()
        {
            Destroy(myCollider);
            Destroy(meshRenderer);
            Destroy(gameObject, duration);
        }
    }
}

