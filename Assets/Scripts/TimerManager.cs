using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private static TimerManager instance;
    public float RemainingTime { get; set; }
    bool timeActive = false;
    int minutes;
    int seconds;

    public static TimerManager GetInstance() => instance;

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
        RemainingTimer(RemainingTime);
    }

    void Update()
    {
        if (timeActive == true)
        {

            if (RemainingTime > 0)
            {
                RemainingTime -= Time.deltaTime;
                if (StarManager.GetInstance().countStar == StarManager.GetInstance().StarGoal)
                {
                    NormalMode.GetInstance().GameCompleted();
                    StopTimer();
                }

            }
            else if (RemainingTime < 0)
            {
                RemainingTime = 0;
                if (StarManager.GetInstance().countStar < StarManager.GetInstance().StarGoal)
                {

                    NormalMode.GetInstance().GameFailed();
                    StopTimer();
                }
            }
            RemainingTimer(RemainingTime);
        }
    }

    void RemainingTimer(float timer)
    {
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
    }
    
    public string PrettyTIme()
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
}
