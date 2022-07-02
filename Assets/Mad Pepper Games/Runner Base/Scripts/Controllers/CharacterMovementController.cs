using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Base
{
    namespace Runner 
    {
        [RequireComponent(typeof(CharacterSettings))]
        [RequireComponent(typeof(Rigidbody))]
        public class CharacterMovementController : MonoBehaviour
        {
            //Character Movement and Input

            private CharacterSettings characterSettings;
            public CharacterSettings CharacterSettings { get { return (characterSettings == null) ? characterSettings = GetComponent<CharacterSettings>() : characterSettings; } }
            
            private CharacterStateController characterStateController;
            public CharacterStateController CharacterStateController { get { return (characterStateController == null) ? characterStateController = GetComponent<CharacterStateController>() : characterStateController; } }

            private Rigidbody _rb;
            public Rigidbody _Rb { get { return (_rb == null) ? _rb = GetComponent<Rigidbody>() : _rb; } }

            public Vector3 DirectionData()
            {
                Vector3 localDirectionData = Vector3.zero;
                localDirectionData = (Vector3.forward * CharacterSettings.RunningSpeed) + (Vector3.right * CharacterSettings.SwerveSpeed * InputManager.Instance.Joystick.Horizontal);
                localDirectionData.Normalize();
                return localDirectionData;
            }
            
            private void Move()
            {
                transform.position = transform.position + DirectionData() * CharacterSettings.RunningSpeed * Time.deltaTime;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, CharacterSettings.RunnerPlatformBoundaries.x, CharacterSettings.RunnerPlatformBoundaries.y), transform.position.y, transform.position.z);
            }

            private void Update()
            {
                if (LevelManager.Instance.IsLevelStarted && CharacterStateController.StateInfos[2].Value == false)
                {
                    Move();
                }
            }

            #region Seperate Movement Functions

            /* private void Run()
            {
                if (CharacterSettings)
                {
                    switch (CharacterSettings.PhysicsType)
                    {
                        case PhysicsType.Default:
                            //No Running
                            break;
                        case PhysicsType.Rigidbody:
                            //Not yet.
                            break;
                        case PhysicsType.Transform:
                            transform.position = transform.position + Vector3.forward * CharacterSettings.RunningSpeed;
                            break;
                        default:
                            break;
                    }
                }
            }*/

            /* private void Swerve()
            {
                if (CharacterSettings)
                {
                    switch (CharacterSettings.ControllerType)
                    {
                        case ControllerType.Default:
                            //No Swerving
                            break;
                        case ControllerType.Joystick:
                            transform.position = transform.position + Vector3.right * CharacterSettings.SwerveSpeed * InputManager.Instance.Joystick.Vertical;
                            break;
                        default:
                            break;
                    }
                }
            }*/

            #endregion
        }
    }
}