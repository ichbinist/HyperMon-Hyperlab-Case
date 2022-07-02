using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelStartPanel : BasePanel
{
    public GameObject TutorialObject;

    private void Start()
    {
        TutorialObject.transform.DOScale(Vector3.one * 0.6f, 1.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnEnable()
    {
        if (!Managers.Instance) return;
        SceneController.Instance.OnSceneLoaded.AddListener(Activate);
        LevelManager.Instance.OnLevelStarted.AddListener(Deactivate);
    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;
        SceneController.Instance.OnSceneLoaded.RemoveListener(Activate);
        LevelManager.Instance.OnLevelStarted.RemoveListener(Deactivate);
    }
}
