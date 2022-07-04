using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PokemonCardController : MonoBehaviour
{
    public Image PokemonImage;
    public TextMeshProUGUI PowerText;
    public PokemonInfoName PokemonInfoName;
    public Button CardButton;

    public void SetCard(Sprite pokemonSprite, int power, PokemonInfoName pokemonInfoName)
    {
        PokemonImage.sprite = pokemonSprite;
        PowerText.SetText(power.ToString());
        PokemonInfoName = pokemonInfoName;
        CardButton.onClick.AddListener(()=> { PokemonManager.Instance.OnPokemonUIClicked.Invoke(pokemonInfoName); GetComponentInParent<PokemonPickUI>().Deactivate(); Destroy(gameObject); });
    }
}
