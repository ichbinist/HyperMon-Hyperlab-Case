using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelFinishPanel : BasePanel
{
    public Button SuccessButton,FailButton;

    public GameObject FailPanel, SuccessPanel;
    private void OnEnable()
    {
        if (!Managers.Instance) return;
        GameManager.Instance.OnGameFinishes.AddListener(FinishGameUIControl);
        SuccessButton.onClick.AddListener(SuccessButtonClick);
        FailButton.onClick.AddListener(FailButtonClick);
    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;
        GameManager.Instance.OnGameFinishes.RemoveListener(FinishGameUIControl);
        SuccessButton.onClick.RemoveListener(SuccessButtonClick);
        FailButton.onClick.RemoveListener(FailButtonClick);
    }

    private void SuccessButtonClick()
    {
        LevelManager.Instance.LoadNextLevel();
        FailPanel.SetActive(false);
        SuccessPanel.SetActive(false);
    }

    private void FailButtonClick()
    {
        LevelManager.Instance.ReloadLevel();
        FailPanel.SetActive(false);
        SuccessPanel.SetActive(false);
    }

    private void FinishGameUIControl(bool check)
    {
        if (check)
        {
            SuccessPanel.SetActive(true);
        }
        else
        {
            FailPanel.SetActive(true);
        }
    }
}