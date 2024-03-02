using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }
    public float RemainingTime { get; private set; }
    private bool timeActive = false;
    private int minutes;
    private int seconds;

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
        RemainingTimer(RemainingTime);
        Debug.Log(PlayerPrefs.GetFloat("ScoreTimer"));
    }

    void Update()
    {
        if (timeActive == true)
        {
            if (RemainingTime > 0)
            {
                RemainingTime -= Time.deltaTime;
                if (StarManager.Instance.CompareStar())
                {
                    NormalMode.Instance.GameCompleted();
                    StopTimer();
                }
            }
            else if (RemainingTime < 0)
            {
                RemainingTime = 0;
                NormalMode.Instance.GameOver();
                StopTimer();
            }

            RemainingTimer(RemainingTime);
        }
    }

    void RemainingTimer(float timer)
    {
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
    }

    public string PrettyTime()
    {
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void StartTimer()
    {
        timeActive = true;
    }

    public void StopTimer()
    {
        timeActive = false;
    }

    public void SetInitialRemainingTime(float initialTime)
    {
        RemainingTime = initialTime;
    }

    public void SaveScoreTimer()
    {
        PlayerPrefs.SetFloat("ScoreTimer", RemainingTime);
    }

    public void LoadScoreTimer()
    {
        if (PlayerPrefs.HasKey("ScoreTimer"))
        {
            RemainingTime = PlayerPrefs.GetFloat("ScoreTimer");
        }
        else
        {
            RemainingTime = RemainingTime;
        }
        RemainingTimer(RemainingTime);
    }

    public void RestartTimer()
    {
        RemainingTime = 0;
        timeActive = false;
    }
}
