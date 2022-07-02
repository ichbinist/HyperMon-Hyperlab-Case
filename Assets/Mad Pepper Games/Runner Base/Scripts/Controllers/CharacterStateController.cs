using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
namespace Base
{
    namespace Runner
    {
        public class CharacterStateController : MonoBehaviour
        {
            private Rigidbody _rb;
            public Rigidbody _Rb { get { return (_rb == null) ? _rb = GetComponent<Rigidbody>() : _rb; } }

            [ShowInInspector]
            public List<StateInfo> StateInfos = new List<StateInfo>();

            public bool IsRunning;
            private void Awake()
            {
                foreach (CharacterState characterState in System.Enum.GetValues(typeof(CharacterState)))
                {
                    StateInfos.Add(new StateInfo(characterState, false));
                }
            }

            private void OnEnable()
            {
                LevelManager.Instance.OnLevelStarted.AddListener(()=> IsRunning = true);
            }

            private void OnDisable()
            {
                LevelManager.Instance.OnLevelStarted.RemoveListener(()=> IsRunning = true);
            }

            private void Update()
            {
               StateInfos[1].Value = IsRunning;
            }

            public enum CharacterState
            {             
                Idle,
                Running,
                Falling,
                Throwing,
                Dying
            }
        }

        public class StateInfo
        {
            public StateInfo(CharacterStateController.CharacterState localStateName, bool localValue)
            {
                StateName = localStateName;
                Value = localValue;
            }

            public CharacterStateController.CharacterState StateName;
            public bool Value;
        }
    }
}