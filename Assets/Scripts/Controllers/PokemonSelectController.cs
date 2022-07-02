using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Base.Runner;
using TMPro;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PokemonSelectController : MonoBehaviour
{
    public Transform JumpReferencePoint;
    public PokemonSelectController LinkedPicker;
    public bool CanPickable;
    public PokemonInfoName PokemonInfoName;

    [BoxGroup("Card References")]
    public TextMeshProUGUI CostText;
    [BoxGroup("Card References")]
    public Image Background;
    [BoxGroup("Card References")]
    public Image PokemonImage;
    [BoxGroup("Card References")]
    public TextMeshProUGUI PokemonName; 
    [BoxGroup("Card References")]
    public TextMeshProUGUI PokemonRarity;
    [BoxGroup("Card References")]
    public TextMeshProUGUI PokemonLevel;

    private void Start()
    {
        CostText.SetText(PokemonManager.Instance.PokemonDictionary[PokemonInfoName].Cost.ToString());
        Background.color = (PokemonManager.Instance.PokemonDictionary[PokemonInfoName].BackgroundColor);
        PokemonImage.sprite = (PokemonManager.Instance.PokemonDictionary[PokemonInfoName].PokemonImage);
        PokemonName.SetText(PokemonManager.Instance.PokemonDictionary[PokemonInfoName].Name.ToString());
        PokemonRarity.SetText(PokemonManager.Instance.PokemonDictionary[PokemonInfoName].Rarity.ToString());
        PokemonLevel.SetText(PokemonManager.Instance.PokemonDictionary[PokemonInfoName].Power.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterSettings characterSettings = other.GetComponent<CharacterSettings>();

        if (CanPickable && characterSettings && CharacterManager.Instance.CurrentCharacter.PokeballCount < PokemonManager.Instance.PokemonDictionary[PokemonInfoName].Cost)
        {
            characterSettings.CharacterStateController.StateInfos[2].Value = true;
            characterSettings.transform.DOJump(new Vector3(characterSettings.transform.position.x, JumpReferencePoint.position.y, JumpReferencePoint.position.z), 1.5f, 1, 1.8f).OnComplete(()=> characterSettings.CharacterStateController.StateInfos[2].Value = false);
        }
        else
        {
            if (CanPickable)
            {
                LinkedPicker.CanPickable = false;
                PokemonManager.Instance.PickPokemon(PokemonInfoName);
                CharacterManager.Instance.CurrentCharacter.PokeballCount -= PokemonManager.Instance.PokemonDictionary[PokemonInfoName].Cost;
            }
        }
    }
}
