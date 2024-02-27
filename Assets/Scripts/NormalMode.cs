using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalMode : MonoBehaviour
{
    public static NormalMode instance;
    public GameManager gameManager;
    public TimerManager timerManager;

    public static NormalMode GetInstance() => instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        GameManager.GetInstance().StartGame();
        TimerManager.GetInstance().StartTimer();
    }

    public void GameOver()
    {
        GameManager.GetInstance().GameOver();
        TimerManager.GetInstance().StopTimer();
    }

    public void GameCompleted()
    {
        GameManager.GetInstance().GameCompleted();
        LevelManager.GetInstance().UnlockNewLevel();
    }

    public void GameFailed()
    {
        GameOver();
    }
}
