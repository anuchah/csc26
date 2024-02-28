using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FailedScreen : MonoBehaviour
{
    public GameObject failedScreen;
    public GameObject gamepleyScreen;
    public TextMeshProUGUI scoreTime;
    public GameObject buttonsGroup;
    public Dictionary<string, Button> buttonDictionary;

    private void Awake()
    {
        ButtonsToArray();
        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
        {
            if (LevelManager.Instance.CurrentLevel == LevelManager.Level.Level1)
            {
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
                buttonDictionary["RestartButton"].onClick.AddListener(() =>
               {
                   NormalMode.Instance.RestartGame();
                   LevelManager.Instance.StartLevel(LevelManager.Level.Level3);
               });
                buttonDictionary["MenuButton"].onClick.AddListener(() =>
                {
                    NormalMode.Instance.RestartGame();
                    LevelManager.Instance.StartLevel(LevelManager.Level.Empty);
                });
            }
        }
        else if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
        {
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
    }

    private void Update()
    {
        scoreTime.text = ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal ? StarManager.Instance.PrettyCountStar() : ScoreManager.Instance.PrettyLastScore();

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
