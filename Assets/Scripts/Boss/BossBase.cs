using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using DG.Tweening;
using AnimationEnemy;

namespace Boss
{
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }

    public class BossBase : MonoBehaviour
    {
        public StateMachine<BossAction> stateMachine;

        [Header("Init")]
        public Transform player;
        public float startAnimationDuration;
        public Ease startAnimationEase;

        [Header("Walk")]
        public List<Transform> wayPositions;
        public float minDistance;
        public float speed;

        [Header("Attack")]
        public GunBase gunBase;
        public int amountAttack;
        public float timeBetweenAttacks;

        [Header("Health/Death")]
        public HealthBase healthBase;
        public EnemyAnimationBase enemyAnimationBase;
        public FlashColor flashColor;

        private void Awake()
        {
            Init();
            healthBase.onKill += BossKill;
            healthBase.onDamage += BossDamage;
        }

        public void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();

            stateMachine.Register(BossAction.INIT, new BossStateInit());
            stateMachine.Register(BossAction.WALK, new BossStateWalk());
            stateMachine.Register(BossAction.ATTACK, new BossStateAttack());
            stateMachine.Register(BossAction.DEATH, new BossStateDeath());
        }

        #region INIT
        public void InitAnimation()
        {
            transform.DOScale(1, startAnimationDuration).SetEase(startAnimationEase);
        }
        #endregion

        #region WALK
        public void RandomWalk(Action onArrive = null)
        {
            StartCoroutine(RandomWalkCoroutine(wayPositions[UnityEngine.Random.Range(0, wayPositions.Count)], onArrive));
        }

        public void WalkAnimation()
        {
            PlayAnimationByTrigger(AnimationType.RUN);
        }

        IEnumerator RandomWalkCoroutine(Transform t, Action onArrive = null)
        {
            while (Vector3.Distance(transform.position, t.position) > minDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            onArrive?.Invoke();
        }
        #endregion

        #region ATTACK
        public void Attack(Action endAttack = null)
        {
            StartCoroutine(AttackCoroutine(endAttack));
        }

        public void BossShoot()
        {
            gunBase.InitShoot();
        }

        public void AttackAnimation()
        {
            PlayAnimationByTrigger(AnimationType.ATTACK);
        }

        IEnumerator AttackCoroutine(Action endAttack = null)
        {
            int currAmount = 0;

            while(currAmount < amountAttack)
            {
                currAmount++;
                AttackAnimation();
                yield return new WaitForSeconds(timeBetweenAttacks);
            }

            endAttack?.Invoke();
        }
        #endregion

        #region DEATH
        public void BossKill(HealthBase h)
        {
            ChangeState(BossAction.DEATH);
        }

        public void KillAnimation()
        {
            PlayAnimationByTrigger(AnimationType.DEATH);
        }
        #endregion

        public void BossDamage(HealthBase h)
        {
            flashColor.Flash();
        }

        public void PlayAnimationByTrigger(AnimationType type)
        {
            enemyAnimationBase.PlayAnimationByTrigger(type);
        }

        public void ChangeState(BossAction state)
        {
            stateMachine.SwitchStates(state, this);
        }

        private void Update()
        {
            if (player != null) transform.LookAt(player);
        }
    }
}