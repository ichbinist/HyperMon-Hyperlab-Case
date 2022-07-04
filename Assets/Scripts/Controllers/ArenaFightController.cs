using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Runner;

public class ArenaFightController : MonoBehaviour
{
    public GameObject PlayerCharacter, EnemyCharacter;

    private PokemonInfoName EnemyPickedPokemonInfo, PlayerPickedPokemonInfo;

    private EnemyPokemonPickerController enemyPokemonPickerController;
    public EnemyPokemonPickerController EnemyPokemonPickerController { get { return (enemyPokemonPickerController == null) ? enemyPokemonPickerController = EnemyCharacter.GetComponent<EnemyPokemonPickerController>() : enemyPokemonPickerController; } }

    private void OnEnable()
    {
        CharacterManager.Instance.OnArenaSet.AddListener(StartSequence);
        PokemonManager.Instance.OnArenaPokemonPicked.AddListener(FightControl);
    }

    private void OnDisable()
    {
        CharacterManager.Instance.OnArenaSet.RemoveListener(StartSequence);
        PokemonManager.Instance.OnArenaPokemonPicked.RemoveListener(FightControl);
    }

    public void StartSequence()
    {
        EnemyPickedPokemonInfo = EnemyPokemonPickerController.PickPokemon();
    }

    public void FightControl(PokemonInfoName pokemonInfoName)
    {
        PlayerPickedPokemonInfo = pokemonInfoName;

        Animator enemyPokemonAnimator = PokemonManager.Instance.EnemyPickedPokemon.GetComponentInChildren<Animator>();
        Animator playerPokemonAnimator = PokemonManager.Instance.PlayerPickedPokemon.GetComponentInChildren<Animator>();

        if (PokemonManager.Instance.PokemonDictionary[PlayerPickedPokemonInfo].Power > PokemonManager.Instance.PokemonDictionary[EnemyPickedPokemonInfo].Power)
        {
            playerPokemonAnimator.SetTrigger("Attack");
            enemyPokemonAnimator.SetTrigger("Die");
            PokemonManager.Instance.PlayerScore++;
        }
        else if(PokemonManager.Instance.PokemonDictionary[PlayerPickedPokemonInfo].Power < PokemonManager.Instance.PokemonDictionary[EnemyPickedPokemonInfo].Power)
        {
            playerPokemonAnimator.SetTrigger("Die");
            enemyPokemonAnimator.SetTrigger("Attack");
            PokemonManager.Instance.EnemyScore++;
        }
        else
        {
            playerPokemonAnimator.SetTrigger("Attack");
            enemyPokemonAnimator.SetTrigger("Attack");
            PokemonManager.Instance.PlayerScore++;
            PokemonManager.Instance.EnemyScore++;
        }
        StartCoroutine(FightEndSequence());
    }

    public IEnumerator FightEndSequence()
    {
        yield return new WaitForSeconds(3f);
        Destroy(PokemonManager.Instance.EnemyPickedPokemon);
        Destroy(PokemonManager.Instance.PlayerPickedPokemon);

        if(!EnemyPokemonPickerController.IsPokemonsFinished)
            EnemyPickedPokemonInfo = EnemyPokemonPickerController.PickPokemon();
    }
}
