using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Runner;

public class PokemonGridController : MonoBehaviour
{
    public List<Transform> GridPositions = new List<Transform>();
    private int index;
    private List<PokemonAnimationController> pokemonAnimationControllers = new List<PokemonAnimationController>();
    public void AddPokemon(GameObject pokemon)
    {
        if (index >= GridPositions.Count) return;

        pokemon.transform.parent = GridPositions[index];
        pokemon.GetComponent<PokemonRunnerController>().OnGridSet.Invoke();
        pokemonAnimationControllers.Add(pokemon.GetComponent<PokemonAnimationController>());
        index++;
    }

    public void SetArenaMods()
    {
        foreach (PokemonAnimationController pokemonAnimationController in pokemonAnimationControllers)
        {
            pokemonAnimationController.SetArenaMode();
        }
    }

    private void Update()
    {
        if(LevelManager.Instance.IsLevelStarted)
            transform.position = new Vector3(0, 0, CharacterManager.Instance.CurrentCharacter.transform.position.z);
    }
}
