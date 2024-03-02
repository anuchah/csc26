using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState
    {
        NotStarted,
        InProgress,
        GameOver,
        GameCompleted,
        Paused
    }
    public GameState CurrentGameState { get; set; }
    public UnityEvent onStartGame;
    public UnityEvent onGameOver;
    public UnityEvent onGameCompleted;
    public UnityEvent onPauseGame;
    public UnityEvent onUnpauseGame;
    public bool isPaused = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Debug.Log("Game Manager is here!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                UnpauseGame();
        }
        Debug.Log(CurrentGameState);
    }
    public void StartGame()
    {
        CurrentGameState = GameState.InProgress;
        onStartGame.Invoke();
    }

    public void PauseGame()
    {
        if (CurrentGameState == GameState.InProgress)
        {
            Time.timeScale = 0f;
            CurrentGameState = GameState.Paused;
            onPauseGame.Invoke();
            isPaused = true;
        }
    }

    public void UnpauseGame()
    {
        if (CurrentGameState == GameState.Paused)
        {
            Time.timeScale = 1f;
            CurrentGameState = GameState.InProgress;
            onUnpauseGame.Invoke();
            isPaused = false;
        }
    }

    public void EndGame(bool completed)
    {
        CurrentGameState = completed ? GameState.GameCompleted : GameState.GameOver;
        if (completed)
        {
            onGameCompleted.Invoke();
        }
        else
        {
            onGameOver.Invoke();
        }
    }

    public void RestartGame()
    {
        CurrentGameState = GameState.NotStarted;
        isPaused = false;
        Time.timeScale = 1f;
    }
}
