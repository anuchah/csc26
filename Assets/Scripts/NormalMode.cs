using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalMode : MonoBehaviour
{
    public static NormalMode Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {

    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
        TimerManager.Instance.StartTimer();
    }

    public void GameOver()
    {
        GameManager.Instance.EndGame(false);
        TimerManager.Instance.StopTimer();
    }

    public void GameCompleted()
    {
        GameManager.Instance.EndGame(true);
        TimerManager.Instance.SaveScoreTimer();
        LevelManager.Instance.UnlockNewLevel();
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
        TimerManager.Instance.RestartTimer();
        StarManager.Instance.RestartStars();
    }
}
