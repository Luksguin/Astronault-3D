using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Collectable
{
    public class CollectableBase : MonoBehaviour
    {
        public CollectableType itenType;
        public Collider myCollider;
        public MeshRenderer meshRenderer;
        public string playerTag;
        public float timeToDestroy;

        [Header("Animator")]
        public Animator animator;
        public string setTrigger;

        [Header("Message")]
        public GameObject message;
        public float messageDuration;
        public float messageAnimationDuration;
        public Ease messageEase;
        
        [Header("Others")]
        public ParticleSystem systemParticle;
        //public AudioSource audioClip;

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
            //if (audioClip != null) audioClip.Play();
            if(animator != null) animator.SetTrigger(setTrigger);
            StartCoroutine(ShowMessage());
            CollectableManager.instance.AddByType(itenType);
            DestroyObject();
        }

        public void DestroyObject()
        {
            Destroy(myCollider);
            Destroy(meshRenderer);
            Destroy(gameObject, timeToDestroy);
        }

        IEnumerator ShowMessage()
        {
            if (message == null) yield break;
            message.transform.DOScale(1, messageAnimationDuration).SetEase(messageEase);
            yield return new WaitForSeconds(messageDuration);
            message.transform.DOScale(0, messageAnimationDuration).SetEase(messageEase);
        }
    }
}
