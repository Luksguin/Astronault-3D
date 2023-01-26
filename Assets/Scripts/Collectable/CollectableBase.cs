using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectable
{
    public class CollectableBase : MonoBehaviour
    {
        public string playerTag;
        public ItenType itenType;

        [Header("Animations")]
        public ParticleSystem systemParticle;
        public Animator animator;
        public string setTrigger;
        
        [Header("Sounds")]
        public AudioSource audioClip;

        private void Awake()
        {
            if(systemParticle != null) systemParticle.transform.SetParent(null);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.transform.tag == playerTag)
            {
                Collect();
            }
        }

        protected virtual void Collect()
        {
            OnCollect();
        }

        protected virtual void OnCollect()
        {
            if (systemParticle != null) systemParticle.Play();
            if (audioClip != null) audioClip.Play();
            if(animator != null) animator.SetTrigger(setTrigger);
            CollectableManager.instance.AddByType(itenType);
            Destroy(gameObject);
        }
    }
}
