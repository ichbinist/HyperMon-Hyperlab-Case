using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Runner;

public class PokeballCanvasController : MonoBehaviour
{
    private void OnEnable()
    {
        CharacterManager.Instance.OnArenaSet.AddListener(() => gameObject.SetActive(false));
    }

    private void OnDisable()
    {
        CharacterManager.Instance.OnArenaSet.RemoveListener(() => gameObject.SetActive(false));
    }
}
