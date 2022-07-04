using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class EnemyPokemonPickerController : MonoBehaviour
{
    public List<PokemonInfoName> PokemonList = new List<PokemonInfoName>();
    private int index;
    public Transform PokemonStandPoint;

    public bool IsPokemonsFinished;

    private Animator animator;
    private Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    public PokemonInfoName PickPokemon()
    {
        if(index >= PokemonList.Count)
        {
            IsPokemonsFinished = true;
            if (PokemonManager.Instance.PlayerScore > PokemonManager.Instance.EnemyScore)
            {
                GameManager.Instance.OnGameFinishes.Invoke(true);
            }
            else
            {
                GameManager.Instance.OnGameFinishes.Invoke(false);
            }
            return PokemonList[0];
        }
        Animator.SetBool("Throwing", true);
        PokemonInfoName infoName = PokemonList[index];
        GameObject localPokemon = Instantiate(PokemonManager.Instance.PokemonDictionary[PokemonList[index]].PokemonPrefab, transform.position, transform.rotation);

        localPokemon.transform.DOJump(PokemonStandPoint.position, 5, 1, 1f).OnComplete(()=> { 
            Animator.SetBool("Throwing", false); 
            PokemonManager.Instance.OnArenaEnemyPokemonPicked.Invoke(infoName); 
        });

        localPokemon.transform.localScale = Vector3.zero;
        localPokemon.transform.DOScale(Vector3.one * 5f, 1f);
        localPokemon.GetComponentInChildren<Animator>().SetBool("Arena",true);
        PokemonManager.Instance.EnemyPickedPokemon = localPokemon;
        localPokemon.GetComponent<PokemonRunnerController>().PowerText.SetText(PokemonManager.Instance.PokemonDictionary[PokemonList[index]].Power.ToString());
        localPokemon.GetComponent<PokemonRunnerController>().PowerText.transform.parent.gameObject.SetActive(true);
        index++;
        
        return infoName;
    }
}
