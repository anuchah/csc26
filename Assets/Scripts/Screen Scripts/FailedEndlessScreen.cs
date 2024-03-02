using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FailedEndlessScreen : MonoBehaviour
{
    public GameObject failedScreen;
    public GameObject gamepleyScreen;
    public TextMeshProUGUI scoreTime;
    public TextMeshProUGUI coinText;
    public GameObject buttonsGroup;
    public Dictionary<string, Button> buttonDictionary;

    private void Awake()
    {
        ButtonsToArray();

        buttonDictionary["RestartButton"].onClick.AddListener(() =>
          {
              EndlessMode.Instance.RestartGame();
              Loader.Load(Loader.Scene.Gameplay);
          });
        buttonDictionary["MenuButton"].onClick.AddListener(() =>
        {
            EndlessMode.Instance.RestartGame();
            Loader.Load(Loader.Scene.Endless);
        });

    }

    private void Update()
    {
        scoreTime.text = ScoreManager.Instance.PrettyLastScore();
        coinText.text = CoinManager.Instance.PrettyCoinTemp();
        
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.GameOver)
        {
            failedScreen.SetActive(true);
            gamepleyScreen.SetActive(false);
        }
    }

    void ButtonsToArray()
    {
        int childCount = buttonsGroup.transform.childCount;
        buttonDictionary = new Dictionary<string, Button>();
        for (int i = 0; i < childCount; i++)
        {
            Button button = buttonsGroup.transform.GetChild(i).GetComponent<Button>();
            if (button != null)
            {
                buttonDictionary.Add(button.name, button);
            }
            else
            {
                Debug.LogWarning("Child at index " + i + " does not have a Button component.");
            }
        }
    }
}
