using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMode : MonoBehaviour
{
    public static EndlessMode Instance { get; private set; }

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
        ScoreManager.Instance.StartStopwatch();
        
    }

    public void GameOver()
    {
        GameManager.Instance.EndGame(false);
        ScoreManager.Instance.EndRound();
        CoinManager.Instance.EndRound();
        ScoreManager.Instance.StopStopwatch();
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
        ScoreManager.Instance.ResetTimer();
    }
}
