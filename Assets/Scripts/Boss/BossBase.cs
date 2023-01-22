using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using DG.Tweening;

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

        [Header("Animations")]
        public float startAnimationDuration;
        public Ease startAnimationEase;

        [Header("Walk")]
        public List<Transform> wayPositions;
        public float minDistance;
        public float speed;

        [Header("Attack")]
        public int amountAttack;
        public float timeBetweenAttacks;

        [Header("Health")]
        public HealthBase healthBase;

        private void Awake()
        {
            Init();
            healthBase.onKill += BossKill;
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

        #region ANIMATIONS
        public void StartInitAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }
        #endregion

        #region WALK
        public void RandomWalk(Action onArrive = null)
        {
            StartCoroutine(RandomWalkCoroutine(wayPositions[UnityEngine.Random.Range(0, wayPositions.Count)], onArrive));
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

        IEnumerator AttackCoroutine(Action endAttack = null)
        {
            int currAmount = 0;

            while(currAmount < amountAttack)
            {
                currAmount++;
                transform.DOScale(1.2f, .1f).SetLoops(2, LoopType.Yoyo);
                yield return new WaitForSeconds(timeBetweenAttacks);
            }

            endAttack?.Invoke();
        }
        #endregion

        public void BossKill(HealthBase h)
        {
            SwitchState(BossAction.DEATH);
        }

        public void SwitchState(BossAction state)
        {
            stateMachine.SwitchStates(state, this);
        }

        #region DEBUG
        [NaughtyAttributes.Button]
        private void SwitchStateInit()
        {
            SwitchState(BossAction.INIT);
        }

        [NaughtyAttributes.Button]
        private void SwitchStateWalk()
        {
            SwitchState(BossAction.WALK);
        }

        [NaughtyAttributes.Button]
        private void SwitchStateAttack()
        {
            SwitchState(BossAction.ATTACK);
        }
        #endregion
    }
}