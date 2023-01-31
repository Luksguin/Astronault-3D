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

        [SerializeField] private bool _hasArmor = false;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.tag == playerTag && _hasArmor == false)
            {
                _hasArmor = true;
                Collect();
                Invoke(nameof(RemoveArmor), duration);
            }
        }

        public void RemoveArmor()
        {
            _hasArmor = false;
        }

        protected virtual void Collect()
        {
            var setup = ArmorManager.instance.GetByType(armorType);
            Player.instance.UpdateArmor(setup, duration);

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

