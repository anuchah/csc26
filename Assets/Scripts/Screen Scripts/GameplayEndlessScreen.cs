using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayEndlessScreen : MonoBehaviour
{
    public GameObject gameplayEndlessScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public Button pauseBtn;


    private void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            gameplayEndlessScreen.SetActive(true);
            pauseBtn.onClick.AddListener(() => GameManager.Instance.PauseGame());
        }

        scoreText.text = ScoreManager.Instance.PrettyScore();
        coinText.text = CoinManager.Instance.PrettyCurrentCoin();
    }

    public void ButtonSound()
    {
        AudioManager.Instance.PlaySound(TagManager.BUTTON);
    }

}
