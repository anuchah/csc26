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

    public void StartGame()
    {
        GameManager.Instance.StartGame();
        TimerManager.Instance.StartTimer();
    }

    public void GameOver()
    {
        GameManager.Instance.EndGame(false);
        AudioManager.Instance.PlaySound(TagManager.FAILED);
        TimerManager.Instance.StopTimer();
    }

    public void GameCompleted()
    {
        GameManager.Instance.EndGame(true);
        TimerManager.Instance.SaveScoreTimer();
        LevelManager.Instance.UnlockNewLevel();
        AudioManager.Instance.PlaySound(TagManager.COMPLETE);
        Bird.Instance.ResetBody();
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
        TimerManager.Instance.RestartTimer();
        StarManager.Instance.RestartStars();
    }
}
