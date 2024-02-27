using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayScreen : MonoBehaviour
{
    public GameObject gameplayScreen;
    public TextMeshProUGUI timeRemainingText;
    public TextMeshProUGUI goalStarText;
    public TextMeshProUGUI countStarText;

    private void Update()
    {
        timeRemainingText.text = TimerManager.GetInstance().PrettyTIme();
        goalStarText.text = StarManager.GetInstance().PrettyStarGo();
        countStarText.text = StarManager.GetInstance().PrettyCountStar();

        if (TimerManager.GetInstance().RemainingTime < 4)
        {
            timeRemainingText.color = Color.red;
        }

        if (GameManager.GetInstance().isGameStart)
        {
            gameplayScreen.SetActive(true);
        }
    }

}
