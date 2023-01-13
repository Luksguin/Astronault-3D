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
        public FlashEnemy flashEnemy;
        public Collider mycollider;
        public ParticleSystem particleDamage;
        public int life;
        public float timeToDestroy;

        private int _currentLife;

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
            _currentLife = life;
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
        public void Damage(int damage)
        {
            OnDamage(damage);
        }

        protected virtual void OnDamage(int damage)
        {
            _currentLife -= damage;
            if(flashEnemy != null) flashEnemy.Flash();
            if (particleDamage != null) particleDamage.Play();

            if (_currentLife <= 0)
            {
                Kill();
            }
        }

        public void StartAnimation()
        {
            gameObject.transform.DOScale(0, durationStartAnimation).SetEase(easeStartAnimation).From();
        }

        public void PlayAnimationByTrigger(AnimationType type)
        {
            enemyAnimationBase.PlayAnimationByTrigger(type);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                OnDamage(5);
            }
        }
    }
}
