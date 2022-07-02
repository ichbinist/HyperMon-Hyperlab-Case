using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Runner;
using UnityEngine.Events;

public class PokemonRunnerController : MonoBehaviour
{
    public UnityEvent OnGridSet = new UnityEvent();

    private void OnEnable()
    {
        OnGridSet.AddListener(SetPosition);
    }
    private void OnDisable()
    {
        OnGridSet.RemoveListener(SetPosition);
    }

    public void SetPosition()
    {
        transform.localPosition = Vector3.zero;
    }
}
