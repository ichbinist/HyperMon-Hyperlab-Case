using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Runner;
public class ArenaPhaseController : MonoBehaviour
{
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
        }
    }
}
