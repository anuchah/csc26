using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    public Button normalBtn;
    public Button endlessBtn;

    private void Awake()
    {
        normalBtn.onClick.AddListener(() =>
        {
            ModeManager.Instance.StartNormalMode();
            AudioManager.Instance.PlaySound(TagManager.BUTTON);
        });

        endlessBtn.onClick.AddListener(() =>
        {
            ModeManager.Instance.StartEndlessMode();
            AudioManager.Instance.PlaySound(TagManager.BUTTON);
        });
    }
}
