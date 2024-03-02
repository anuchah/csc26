using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public Button exitBtn;
    public GameObject levelsButtons;
    public LevelManager.Level[] levels = {
        LevelManager.Level.Level1,
        LevelManager.Level.Level2,
        LevelManager.Level.Level3,
        LevelManager.Level.Empty
        };

    void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            int indexCurrent = i;
            buttons[i].onClick.AddListener(() => OpenLevel(levels[indexCurrent]));
            buttons[i].interactable = false;
        }
        unlockedLevel = Mathf.Min(unlockedLevel, buttons.Length);
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(LevelManager.Level level)
    {
        LevelManager.Instance.StartLevel(level);
    }

    void ButtonsToArray()
    {
        int childCount = levelsButtons.transform.childCount;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = levelsButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
        buttons.Append(exitBtn);
    }
}
