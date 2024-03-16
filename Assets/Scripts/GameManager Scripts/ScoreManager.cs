using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    bool stopwatchActive = false;
    float currentTime;
    int score;
    int highScore;

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
        currentTime = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime += Time.deltaTime;
            score = Mathf.RoundToInt(currentTime * (SpeedManager.Instance.Speed * 2));
        }
    }

    void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void StartStopwatch()
    {
        stopwatchActive = true;
    }

    public void StopStopwatch()
    {
        stopwatchActive = false;
    }

    public void EndRound()
    {
        UpdateHighScore();
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.Save();
        currentTime = 0;
        score = 0;
    }

    public void ResetTimer()
    {
        currentTime = 0;
        score = 0;
        stopwatchActive = false;
    }

    public string PrettyScore()
    {
        return score.ToString("D6");
    }

    public string PrettyHighScore()
    {
        return highScore.ToString();
    }

    public string PrettyLastScore()
    {
        return PlayerPrefs.GetInt("LastScore", 0).ToString();
    }
}
