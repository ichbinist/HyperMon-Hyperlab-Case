using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPokemonPickerController : MonoBehaviour
{
    private Animator animator;
    private Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    public Transform PokemonStandPoint;

    private void OnEnable()
    {
        PokemonManager.Instance.OnPokemonUIClicked.AddListener(PickPokemon);
    }

    private void OnDisable()
    {
        PokemonManager.Instance.OnPokemonUIClicked.RemoveListener(PickPokemon);
    }

    public void PickPokemon(PokemonInfoName infoName)
    {
        Animator.SetBool("Throwing", true);
        GameObject localPokemon = Instantiate(PokemonManager.Instance.PokemonDictionary[infoName].PokemonPrefab, transform.position, transform.rotation);

        localPokemon.transform.DOJump(PokemonStandPoint.position, 5, 1, 1f).OnComplete(() => {
            Animator.SetBool("Throwing", false);
            PokemonManager.Instance.OnArenaPokemonPicked.Invoke(infoName);
        });

        localPokemon.transform.localScale = Vector3.zero;
        localPokemon.transform.DOScale(Vector3.one * 5f, 1f);
        localPokemon.GetComponentInChildren<Animator>().SetBool("Arena", true);
        PokemonManager.Instance.PlayerPickedPokemon = localPokemon;
        localPokemon.GetComponent<PokemonRunnerController>().PowerText.SetText(PokemonManager.Instance.PokemonDictionary[infoName].Power.ToString());
        localPokemon.GetComponent<PokemonRunnerController>().PowerText.transform.parent.gameObject.SetActive(true);
    }
}
