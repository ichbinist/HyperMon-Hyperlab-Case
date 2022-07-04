using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonPickUI : BasePanel
{
    public Transform Grid;
    public GameObject PokemonCard;

    private void OnEnable()
    {
        PokemonManager.Instance.OnArenaEnemyPokemonPicked.AddListener(ActivatePanel);
        PokemonManager.Instance.OnPokemonPicked.AddListener(AddCard);
    }

    private void OnDisable()
    {
        PokemonManager.Instance.OnArenaEnemyPokemonPicked.RemoveListener(ActivatePanel);
        PokemonManager.Instance.OnPokemonPicked.RemoveListener(AddCard);
    }

    public void ActivatePanel(PokemonInfoName info)
    {
        Activate();
    }

    public void AddCard(PokemonInfoName info)
    {
        GameObject localCard = Instantiate(PokemonCard, Grid);
        localCard.GetComponent<PokemonCardController>().SetCard(PokemonManager.Instance.PokemonDictionary[info].PokemonImage, PokemonManager.Instance.PokemonDictionary[info].Power, info);
    }
}
