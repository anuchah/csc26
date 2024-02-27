using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompleteScreen : MonoBehaviour
{
    public GameObject completeScreen;
    public GameObject gamepleyScreen;
    public TextMeshProUGUI scoreTime;
    public GameObject buttonsGroup;
    public Dictionary<string, Button> buttonDictionary;

    private void Awake()
    {
        ButtonsToArray();
        if (LevelManager.Instance.CurrentLevel == LevelManager.Level.Level1)
        {
            buttonDictionary["NextLevelButton"].onClick.AddListener(() =>
            {
                NormalMode.Instance.RestartGame();
                LevelManager.Instance.StartLevel(LevelManager.Level.Level2);
            });
            buttonDictionary["RestartButton"].onClick.AddListener(() =>
            {
                NormalMode.Instance.RestartGame();
                LevelManager.Instance.StartLevel(LevelManager.Level.Level1);
            });
            buttonDictionary["MenuButton"].onClick.AddListener(() =>
            {
                NormalMode.Instance.RestartGame();
                LevelManager.Instance.StartLevel(LevelManager.Level.Empty);
            });
        }
        else if (LevelManager.Instance.CurrentLevel == LevelManager.Level.Level2)
        {
            buttonDictionary["NextLevelButton"].onClick.AddListener(() =>
           {
               NormalMode.Instance.RestartGame();
               LevelManager.Instance.StartLevel(LevelManager.Level.Level3);
           });
            buttonDictionary["RestartButton"].onClick.AddListener(() =>
            {
                NormalMode.Instance.RestartGame();
                LevelManager.Instance.StartLevel(LevelManager.Level.Level2);
            });
            buttonDictionary["MenuButton"].onClick.AddListener(() =>
            {
                NormalMode.Instance.RestartGame();
                LevelManager.Instance.StartLevel(LevelManager.Level.Empty);
            });
        }
        else if (LevelManager.Instance.CurrentLevel == LevelManager.Level.Level3)
        {
            buttonDictionary["NextLevelButton"].gameObject.SetActive(false);

            RectTransform restartButtonRectTransform = buttonDictionary["RestartButton"].GetComponent<RectTransform>();
            restartButtonRectTransform.anchoredPosition = new Vector2(300, 0);

            buttonDictionary["RestartButton"].onClick.AddListener(() =>
           {
               NormalMode.Instance.RestartGame();
               LevelManager.Instance.StartLevel(LevelManager.Level.Level3);
           });

            RectTransform menuButtonRectTransform = buttonDictionary["MenuButton"].GetComponent<RectTransform>();
            menuButtonRectTransform.anchoredPosition = new Vector2(-300, 0);

            buttonDictionary["MenuButton"].onClick.AddListener(() =>
            {
                NormalMode.Instance.RestartGame();
                LevelManager.Instance.StartLevel(LevelManager.Level.Empty);
            });
        }
    }

    private void Update()
    {
        scoreTime.text = TimerManager.Instance.PrettyTime();

        if (GameManager.Instance.CurrentGameState == GameManager.GameState.GameCompleted)
        {
            completeScreen.SetActive(true);
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
