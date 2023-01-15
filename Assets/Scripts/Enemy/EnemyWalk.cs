using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Enemy
{
    public class EnemyWalk : EnemyBase
    {
        [Header("Walker")]
        public Transform[] nextPosition;
        public float speed;
        public float minDistance;

        private int _index = 0;

        private void Update()
        {
            if(currentLife > 0)
            {
                if (Vector3.Distance(transform.position, nextPosition[_index].position) < minDistance)
                {
                    _index++;
                    if (_index >= nextPosition.Length) _index = 0;
                }

                transform.position = Vector3.MoveTowards(transform.position, nextPosition[_index].position, Time.deltaTime * speed);
                transform.LookAt(nextPosition[_index]);
            }
        }
    }
}
