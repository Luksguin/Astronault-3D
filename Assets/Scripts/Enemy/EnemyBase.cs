using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AnimationEnemy;

namespace Enemy
{

    public class EnemyBase : MonoBehaviour
    {
        public EnemyAnimationBase enemyAnimationBase;

        public int life;
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
            Destroy(gameObject, 5);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }

        protected virtual void OnDamage(int damage)
        {
            _currentLife -= damage;

            if(_currentLife <= 0)
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
