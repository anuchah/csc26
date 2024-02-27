using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public enum Level { Level1, Level2, Level3, Empty };
    public Level CurrentLevel { get; set; }

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
        Debug.Log(PlayerPrefs.GetInt("ReachedIndex"));
    }

    void Start()
    {
        CurrentLevel = Level.Empty;
    }

    public void StartLevel(Level level)
    {
        switch (level)
        {
            case Level.Level1:
                StarManager.Instance.InitializeStarGoal(2);
                TimerManager.Instance.SetInitialRemainingTime(60);
                Loader.Load(Loader.Scene.Level1);
                break;
            case Level.Level2:
                StarManager.Instance.InitializeStarGoal(3);
                TimerManager.Instance.SetInitialRemainingTime(120);
                Loader.Load(Loader.Scene.Level2);
                break;
            case Level.Level3:
                StarManager.Instance.InitializeStarGoal(5);
                TimerManager.Instance.SetInitialRemainingTime(180);
                Loader.Load(Loader.Scene.Level3);
                break;
            case Level.Empty:
                StarManager.Instance.RestartStars();
                TimerManager.Instance.RestartTimer();
                Loader.Load(Loader.Scene.Normal);
                break;
            default:
                Debug.LogWarning("Invalid level specified.");
                return;
        }
        CurrentLevel = level;
    }

    public void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
        }
    }
}
