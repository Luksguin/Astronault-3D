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
        public float timeToDestroy;
        public string playerTag;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.tag == playerTag)
            {
                Collect();
            }
        }

        protected virtual void Collect()
        {
            DestroyObject();
        }

        public void DestroyObject()
        {
            Destroy(myCollider);
            Destroy(meshRenderer);
            Destroy(gameObject, timeToDestroy);
        }
    }
}

