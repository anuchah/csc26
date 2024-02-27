using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public UnityEvent onStartGame;
    public UnityEvent onGameOver;
    public UnityEvent onGameComplete;
    public bool isGameOver = false;
    public bool isGameStart = false;
    public bool isGameComplete = false;

    public static GameManager GetInstance() => instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("Game Manager is here!");
    }

    public void StartGame()
    {
        isGameStart = true;
        onStartGame.Invoke();
    }

    public void GameOver()
    {

        isGameOver = true;
        isGameStart = false;
        onGameOver.Invoke();
    }

    public void GameCompleted()
    {
        isGameComplete = true;
        isGameStart = false;
        onGameComplete.Invoke();
    }

    public void GameFailed()
    {
        GameOver();
    }
}
