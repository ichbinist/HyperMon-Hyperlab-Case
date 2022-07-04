using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public GameEvent OnGameFinishes = new GameEvent();

    public void CompleteStage(bool state)
    {
        OnGameFinishes.Invoke(state);    
    }
}

public class GameEvent : UnityEvent<bool> { }