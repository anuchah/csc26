using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public int starGoal;
    public int countStar = 0;
    private static StarManager Instance;
    public static StarManager GetInstance()
    {
        return Instance;
    }

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

    public void CollectStar()
    {
        countStar++;
    }

    public string PrettyCountStar()
    {
        return countStar.ToString();
    }

    public string PrettyStarGo()
    {
        return StarGoal.ToString();
    }
    public int StarGoal
    {
        get
        {
            return starGoal;
        }
        set
        {
            starGoal = value;
        }
    }
}
