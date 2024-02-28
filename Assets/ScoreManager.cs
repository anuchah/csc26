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
    public float multiplier = 5f; //Get Speed in Speed Manager!

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentTime = 0;
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
        score = Mathf.RoundToInt(currentTime * multiplier);
        UpdateHighScore();
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.Save();
        currentTime = 0;
    }

    public void ResetTimer()
    {
        currentTime = 0;
        stopwatchActive = false;
    }

    public string PrettyScore()
    {
        return score.ToString("00 000 000");
    }

    public string PrettyHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public string PrettyLastScore()
    {
        return PlayerPrefs.GetInt("LastScore", 0).ToString();
    }
}