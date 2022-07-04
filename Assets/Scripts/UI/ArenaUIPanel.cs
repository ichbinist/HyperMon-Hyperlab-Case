using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base.Runner;
using TMPro;

public class ArenaUIPanel : BasePanel
{

    public TextMeshProUGUI PlayerScoreText, EnemyScoreText;
    private void OnEnable()
    {
        CharacterManager.Instance.OnArenaSet.AddListener(Activate);
        GameManager.Instance.OnGameFinishes.AddListener(DeactivateOnGameFinishes);
    }

    private void OnDisable()
    {
        CharacterManager.Instance.OnArenaSet.RemoveListener(Activate);
        GameManager.Instance.OnGameFinishes.RemoveListener(DeactivateOnGameFinishes);
    }

    private void DeactivateOnGameFinishes(bool state)
    {
        Deactivate();
    }

    private void Update()
    {
        if (LevelManager.Instance.IsLevelStarted)
        {
            PlayerScoreText.SetText(PokemonManager.Instance.PlayerScore.ToString());
            EnemyScoreText.SetText(PokemonManager.Instance.EnemyScore.ToString());
        }
    }
}
