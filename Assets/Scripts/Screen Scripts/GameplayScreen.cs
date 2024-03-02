using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    public GameObject gameplayScreen;
    public Button pauseBtn;
    public TextMeshProUGUI timeRemainingText;
    public TextMeshProUGUI goalStarText;
    public TextMeshProUGUI countStarText;

    private void Update()
    {
        timeRemainingText.text = TimerManager.Instance.PrettyTime();
        goalStarText.text = StarManager.Instance.PrettyStarGoal();
        countStarText.text = StarManager.Instance.PrettyCountStar();

        if (TimerManager.Instance.RemainingTime < 4)
        {
            timeRemainingText.color = Color.red;
        }

        if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            gameplayScreen.SetActive(true);
            pauseBtn.onClick.AddListener(() => GameManager.Instance.PauseGame());
        }
    }

    public void ButtonSound()
    {
        AudioManager.Instance.PlaySound(TagManager.BUTTON);
    }

}
