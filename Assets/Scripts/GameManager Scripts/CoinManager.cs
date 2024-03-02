using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; set; }
    public int currentCoin = 0;
    public int totalCoin = 0;
    private int totalTempCoin = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        totalCoin = PlayerPrefs.GetInt("TotalCoin", 0);
    }

    public void CollectCoin()
    {
        currentCoin++;
        totalTempCoin++;
    }

    public string PrettyCurrentCoin()
    {
        return currentCoin.ToString();
    }

    // Get to GAMEOVER UI
    public string PrettyCoinTemp()
    {
        return  PlayerPrefs.GetInt("LastCoin", 0).ToString();
    }

    public void EndRound()
    {
        PlayerPrefs.SetInt("LastCoin", totalTempCoin);
        PlayerPrefs.Save();
        totalCoin += totalTempCoin;
        totalTempCoin = 0;
        currentCoin = 0;
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
        PlayerPrefs.Save();
    }

    public string PrettyTotalCoin()
    {
        return PlayerPrefs.GetInt("TotalCoin", 0).ToString();
    }
}
