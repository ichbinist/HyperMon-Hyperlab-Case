using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    namespace Runner
    {
        [RequireComponent(typeof(CharacterSettings))]
        [RequireComponent(typeof(CharacterMovementController))]
        [RequireComponent(typeof(CharacterStateController))]
        [RequireComponent(typeof(Animator))]
        public class CharacterAnimationController : MonoBehaviour
        {
            private CharacterSettings characterSettings;
            public CharacterSettings CharacterSettings { get { return (characterSettings == null) ? characterSettings = GetComponent<CharacterSettings>() : characterSettings; } }

            private CharacterMovementController characterMovementController;
            public CharacterMovementController CharacterMovementController { get { return (characterMovementController == null) ? characterMovementController = GetComponent<CharacterMovementController>() : characterMovementController; } }

            private Animator animator;
            public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

            private CharacterStateController characterStateController;
            public CharacterStateController CharacterStateController { get { return (characterStateController == null) ? characterStateController = GetComponent<CharacterStateController>() : characterStateController; } }

            public void LookAtDirection()
            {
                if (LevelManager.Instance.IsLevelStarted)
                {
                    transform.LookAt(transform.position + CharacterMovementController.DirectionData());
                }
            }

            public void AnimationByState()
            {
                if (Animator)
                {
                    foreach (StateInfo stateInfo in CharacterStateController.StateInfos)
                    {
                        Animator.SetBool(stateInfo.StateName.ToString(), stateInfo.Value);
                    }
                } 
            }

            private void Update()
            {
                LookAtDirection();
                AnimationByState();
            }
        }
    }
}