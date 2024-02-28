using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : MonoBehaviour
{
    // public static SpeedManager Instance { get; private set; }
    // public float Speed { get; set; }
    // public float SpeedIncrement { get; set; }
    // public float TimeInterval { get; set; }
    // private float lastIncrementTime;
    // public float initialSpeed;

    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //     }
    //     else if (Instance != this)
    //     {
    //         Destroy(gameObject);
    //     }

    //     initialSpeed = Speed;
    //     lastIncrementTime = Time.time;
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // private void Start()
    // {
    //     if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
    //     {
    //         Speed = 4f;
    //         SpeedIncrement = 0.05f;
    //         TimeInterval = 1.25f;
    //     }
    //     else if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
    //     {
    //         Speed = 3f;
    //         SpeedIncrement = 0.01f;
    //         TimeInterval = 1f;
    //     }
    // }

    // private void Update()
    // {
    //     if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
    //     {
    //         if (Time.time - lastIncrementTime >= TimeInterval)
    //         {
    //             Speed += SpeedIncrement;
    //             lastIncrementTime = Time.time;
    //         }
    //     }
    // }
    // private void OnDestroy()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    // private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    // {
    //     initialSpeed = Speed;
    // }
    public static SpeedManager Instance { get; private set; }
    public float Speed { get; set; }
    public float SpeedIncrement { get; set; }
    public float TimeInterval { get; set; }
    private float lastIncrementTime;
    public float initialSpeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        lastIncrementTime = Time.time;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        UpdateSpeedSettings();
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            if (Time.time - lastIncrementTime >= TimeInterval)
            {
                Speed += SpeedIncrement;
                lastIncrementTime = Time.time;
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        UpdateSpeedSettings();
    }

    private void UpdateSpeedSettings()
    {
        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
        {
            Speed = 4f;
            SpeedIncrement = 0.05f;
            TimeInterval = 1.25f;
        }
        else if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
        {
            Speed = 3.5f;
            SpeedIncrement = 0.025f;
            TimeInterval = 1f;
        }
        else if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Empty)
        {
            // Reset speed settings
            Speed = initialSpeed;
            SpeedIncrement = 0f;
            TimeInterval = 0f;
        }
    }
}
