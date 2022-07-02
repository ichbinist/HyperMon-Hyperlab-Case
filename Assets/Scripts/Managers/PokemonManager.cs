using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PokemonManager : Singleton<PokemonManager>
{
    public PokemonDictionary PokemonDictionary = new PokemonDictionary();
    [HideInInspector]
    public PokemonEvent OnPokemonPicked = new PokemonEvent();

    public List<PokemonInfoName> CurrentPickedPokemons = new List<PokemonInfoName>();

    private void OnEnable()
    {
        LevelManager.Instance.OnLevelStarted.AddListener(CurrentPickedPokemons.Clear);
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnLevelStarted.RemoveListener(CurrentPickedPokemons.Clear);
    }

    public void PickPokemon(PokemonInfoName pokemonInfoName)
    {
        CurrentPickedPokemons.Add(pokemonInfoName);
        GameObject localPokemon = Instantiate(PokemonDictionary[pokemonInfoName].PokemonPrefab);
        Base.Runner.CharacterManager.Instance.CurrentCharacter.PokemonGridController.AddPokemon(localPokemon);
        OnPokemonPicked.Invoke(pokemonInfoName);
    }
}

[System.Serializable]
public class PokemonDictionary : UnitySerializedDictionary<PokemonInfoName, Pokemon> { }

[System.Serializable]
public class Pokemon
{
    public string Name;
    public string Rarity;
    public int Power;
    public int Cost;
    public Color BackgroundColor;
    public Sprite PokemonImage;
    public GameObject PokemonPrefab;   
}

public enum PokemonInfoName
{
    Shadow,
    Shade,
    Phantom,
    Bat_Lord
}

public class PokemonEvent : UnityEvent<PokemonInfoName> { }