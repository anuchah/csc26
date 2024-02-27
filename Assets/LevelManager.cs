using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public enum Level { Level1, Level2, Level3 };
    public static LevelManager GetInstance() => instance;

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
        Debug.Log(PlayerPrefs.GetInt("ReachedIndex"));
    }

    public void StartLevel(Level level)
    {
        switch (level)
        {
            case Level.Level1:
                StarManager.GetInstance().StarGoal = 5;
                TimerManager.GetInstance().RemainingTime = 60;
                Loader.Load(Loader.Scene.Level1);
                break;
            case Level.Level2:
                StarManager.GetInstance().StarGoal = 10;
                TimerManager.GetInstance().RemainingTime = 120;
                Loader.Load(Loader.Scene.Level2);
                break;
            case Level.Level3:
                StarManager.GetInstance().StarGoal = 15;
                TimerManager.GetInstance().RemainingTime = 180;
                Loader.Load(Loader.Scene.Level3);
                break;
            default:
                Debug.LogWarning("Invalid level specified.");
                return;
        }
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
