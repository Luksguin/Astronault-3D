using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AnimationEnemy;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public EnemyAnimationBase enemyAnimationBase;
        public FlashColor flashEnemy;
        public Collider mycollider;
        public ParticleSystem particleDamage;
        public Player player;
        public int life;
        public float timeToDestroy;

        protected int currentLife;

        [Header("Animation")]
        public float durationStartAnimation;
        public Ease easeStartAnimation;

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            ResetLife();
            StartAnimation();
        }

        private void ResetLife()
        {
            currentLife = life;
        }

        private void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            PlayAnimationByTrigger(AnimationType.DEATH);
            Destroy(mycollider);
            Destroy(gameObject, timeToDestroy);
        }

        protected virtual void OnDamage(int damage)
        {
            currentLife -= damage;
            if(flashEnemy != null) flashEnemy.Flash();
            if (particleDamage != null) particleDamage.Play();

            transform.position -= transform.forward;

            if (currentLife <= 0)
            {
                Kill();
            }
        }

        #region INTERFACES
        public void Damage(int damage)
        {

        }

        public void DamageVector(int damage, Vector3 dir)
        {
            OnDamage(damage);
            transform.DOMove(transform.position - dir, .1f);
        }
        #endregion

        public void StartAnimation()
        {
            gameObject.transform.DOScale(0, durationStartAnimation).SetEase(easeStartAnimation).From();
        }

        public void PlayAnimationByTrigger(AnimationType type)
        {
            enemyAnimationBase.PlayAnimationByTrigger(type);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Player p = collision.transform.GetComponent<Player>();

            if(p != null)
            {
                p.Damage(1);
            }
        }

        protected virtual void Update()
        {
            if(player != null) transform.LookAt(player.transform.position);
        }
    }
}
