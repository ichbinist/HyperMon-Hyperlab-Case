using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Runner;
using Cinemachine;

public class PokemonGridController : MonoBehaviour
{
    public List<Transform> GridPositions = new List<Transform>();
    private int index;
    private List<PokemonAnimationController> pokemonAnimationControllers = new List<PokemonAnimationController>();
    public CinemachineVirtualCamera CharacterVirtualCamera;
    private float targetFov;

    private void Start()
    {
        targetFov = CharacterVirtualCamera.m_Lens.FieldOfView;
    }

    public void AddPokemon(GameObject pokemon)
    {
        if (index >= GridPositions.Count) return;

        pokemon.transform.parent = GridPositions[index];
        pokemon.GetComponent<PokemonRunnerController>().OnGridSet.Invoke();
        pokemonAnimationControllers.Add(pokemon.GetComponent<PokemonAnimationController>());
        targetFov += 7.5f;
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
        transform.position = new Vector3(0, 0, CharacterManager.Instance.CurrentCharacter.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, new Vector3(CharacterManager.Instance.CurrentCharacter.transform.position.x, 0, transform.position.z), Time.deltaTime);
        CharacterVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(CharacterVirtualCamera.m_Lens.FieldOfView, targetFov, Time.deltaTime);
    }
}
