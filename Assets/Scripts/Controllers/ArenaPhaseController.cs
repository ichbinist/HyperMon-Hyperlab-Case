using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Runner;
using DG.Tweening;

public class ArenaPhaseController : MonoBehaviour
{
    public Transform CharacterSpawnPoint;
    public Cinemachine.CinemachineVirtualCameraBase ArenaCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterSettings>())
        {
            CharacterManager.Instance.CurrentCharacter.CharacterStateController.IsRunning = false; //Stop Running Animation
            CharacterManager.Instance.CurrentCharacter.PokemonGridController.SetArenaMods();
            CharacterManager.Instance.CurrentCharacter.RunningSpeed = 0;
            CharacterManager.Instance.CurrentCharacter.SwerveSpeed = 0;//Stop Running forward            
            CharacterManager.Instance.OnArenaSet.Invoke(); //Set Arena Mod for UIs
            InputManager.Instance.Joystick.enabled = false;
            CharacterManager.Instance.CurrentCharacter.transform.position = CharacterSpawnPoint.position;
            CharacterManager.Instance.CurrentCharacter.transform.DOScale(Vector3.one * 3.5f, 0.75f);
            ArenaCamera.enabled = true;
            CharacterManager.Instance.CurrentCharacter.PokemonGridController.gameObject.SetActive(false);
        }
    }
}
