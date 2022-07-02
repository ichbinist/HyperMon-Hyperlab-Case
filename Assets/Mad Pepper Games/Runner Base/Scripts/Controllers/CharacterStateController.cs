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
            [ShowInInspector]
            public List<StateInfo> StateInfos = new List<StateInfo>();
            private void Awake()
            {
                foreach (CharacterState characterState in System.Enum.GetValues(typeof(CharacterState)))
                {
                    StateInfos.Add(new StateInfo(characterState, false));
                }
            }

            public enum CharacterState
            {             
                Idle,
                Running,
                Jumping,
                Hitting,
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