using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public static StarManager Instance { get; private set; }
    public int StarGoal { get; private set; }
    public int CountStar { get; private set; }

    private bool isEqauls;

    private void Awake()
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

    public bool CompareStar()
    {
        if (CountStar == StarGoal)
            isEqauls = true;

        if (CountStar < StarGoal)
            isEqauls = false;
        
        return isEqauls;
    }

    public void InitializeStarGoal(int goal)
    {
        StarGoal = goal;
    }

    public void IncrementStarCount()
    {
        CountStar++;
    }

    public string PrettyCountStar()
    {
        return CountStar.ToString();
    }

    public string PrettyStarGoal()
    {
        return StarGoal.ToString();
    }

    public void RestartStars()
    {
        CountStar = 0;
        StarGoal = 0;
    }
}
