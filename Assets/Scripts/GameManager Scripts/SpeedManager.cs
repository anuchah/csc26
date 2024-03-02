using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance { get; private set; }
    public float Speed { get; set; }
    public float SpeedIncrement { get; set; }
    public float TimeInterval { get; set; }
    private float lastIncrementTime;
    public float initialSpeed;

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
        lastIncrementTime = Time.time;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }



    void Start()
    {
        UpdateSpeedSettings();
    }

    void Update()
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

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        UpdateSpeedSettings();
    }

    void UpdateSpeedSettings()
    {
        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
        {
            Speed = 4f;
            SpeedIncrement = 0.05f;
            TimeInterval = 1f;
        }
        else if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
        {
            Speed = 3.5f;
            SpeedIncrement = 0.03f;
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
