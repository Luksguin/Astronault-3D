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
        ATTACK
    }

    public class BossBase : MonoBehaviour
    {
        public StateMachine<BossAction> stateMachine;

        [Header("Animation")]
        public float startAnimationDuration;
        public Ease startAnimationEase;

        [Header("WalkBoss")]
        public List<Transform> wayPositions;
        public float minDistance;
        public float speed;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();

            stateMachine.Register(BossAction.INIT, new BossStateInit());
            stateMachine.Register(BossAction.WALK, new BossStateWalk());
        }

        public void StartInitAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        #region WALK
        public void RandomWalk()
        {
            StartCoroutine(RandomWalkCoroutine(wayPositions[Random.Range(0, wayPositions.Count)]));
        }

        IEnumerator RandomWalkCoroutine(Transform t)
        {
            while (Vector3.Distance(transform.position, t.position) > minDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
        #endregion

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
        #endregion
    }
}