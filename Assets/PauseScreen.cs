using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gamepleyScreen;
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
                buttonDictionary["ResumeButton"].onClick.AddListener(() => GameManager.Instance.UnpauseGame());
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
                buttonDictionary["ResumeButton"].onClick.AddListener(() => GameManager.Instance.UnpauseGame());
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
                buttonDictionary["ResumeButton"].onClick.AddListener(() => GameManager.Instance.UnpauseGame());
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
            buttonDictionary["ResumeButton"].onClick.AddListener(() => GameManager.Instance.UnpauseGame());
            buttonDictionary["MenuButton"].onClick.AddListener(() =>
            {
                EndlessMode.Instance.RestartGame();
                Loader.Load(Loader.Scene.Endless);
            });
        }
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Paused)
        {
            pauseScreen.SetActive(true);
            gamepleyScreen.SetActive(false);
        }
        else if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            pauseScreen.SetActive(false);
            gamepleyScreen.SetActive(true);
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