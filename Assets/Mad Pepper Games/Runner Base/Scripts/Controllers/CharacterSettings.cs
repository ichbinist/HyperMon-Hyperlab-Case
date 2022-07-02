using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

namespace Base
{
    namespace Runner 
    {
        public class CharacterSettings : MonoBehaviour
        {
            private CharacterStateController characterStateController;
            public CharacterStateController CharacterStateController { get { return (characterStateController == null) ? characterStateController = GetComponent<CharacterStateController>() : characterStateController; } }
            
            private CharacterMovementController characterMovementController;
            public CharacterMovementController CharacterMovementController { get { return (characterMovementController == null) ? characterMovementController = GetComponent<CharacterMovementController>() : characterMovementController; } }

            public PokemonGridController PokemonGridController;

            public TextMeshProUGUI PokeballText;
            public int PokeballCount;

            //Character Settings
            [FoldoutGroup("Basic Settings")]
            public float RunningSpeed;
            [FoldoutGroup("Basic Settings")]
            public float SwerveSpeed;
            [FoldoutGroup("Basic Settings")]
            public Vector2 RunnerPlatformBoundaries;

            [FoldoutGroup("Advanced Settings")]
            public CharacterType CharacterType = CharacterType.Player;
            [FoldoutGroup("Advanced Settings")]
            public PhysicsType PhysicsType = PhysicsType.Transform;
            [FoldoutGroup("Advanced Settings")]
            public ControllerType ControllerType = ControllerType.Joystick;

            private void Update()
            {
                PokeballText.SetText(PokeballCount.ToString());
            }

            public void OnEnable()
            {
                if(CharacterManager.Instance)
                    CharacterManager.Instance.CurrentCharacter = this;
            }

            private void OnDisable()
            {
                if (CharacterManager.Instance)
                    CharacterManager.Instance.CurrentCharacter = null;
            }
        }

        public enum CharacterType 
        { 
            Default = 0,
            Player = 1
        }

        public enum PhysicsType
        {
            Default = 0,
            Rigidbody = 1,
            Transform = 2
        }

        public enum ControllerType
        {
            Default = 0,
            Joystick = 1
        }
    } 
}