using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEnemy
{
    public enum AnimationType
    {
        NONE,
        IDLE,
        RUN,
        ATTACK,
        DEATH
    }

    public class EnemyAnimationBase : MonoBehaviour
    {
        public Animator animator;
        public List<AnimationSetup> animationSetups;

        public void PlayAnimationByTrigger(AnimationType type)
        {
            var setup = animationSetups.Find(i => i.animationType == type);
            if(setup != null)
            {
                animator.SetTrigger(setup.trigger);
            }
        }
    }

    [System.Serializable]
    public class AnimationSetup
    {
        public AnimationType animationType;
        public string trigger;
    }
}
