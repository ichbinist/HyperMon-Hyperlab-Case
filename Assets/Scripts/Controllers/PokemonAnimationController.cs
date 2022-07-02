using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PokemonAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponentInChildren<Animator>() : animator; } }

    public PokemonAnimationEvent PokemonAnimationEvent = new PokemonAnimationEvent();

    private void OnEnable()
    {
        PokemonAnimationEvent.AddListener(ArenaDecision);
    }

    private void OnDisable()
    {
        PokemonAnimationEvent.RemoveListener(ArenaDecision);
    }

    public void SetArenaMode()
    {
        Animator.SetBool("Arena", true);
    }

    public void ArenaDecision(bool decision)
    {
        if (decision)
        {
            Animator.SetTrigger("Attack");
        }
        else
        {
            Animator.SetTrigger("Die");
        }
    }
}
public class PokemonAnimationEvent : UnityEvent<bool>{ }