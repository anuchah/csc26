using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NormalScreen : MonoBehaviour
{
    private void Awake()
    {
        Button btnPlay = GameObject.Find("btnPlay").GetComponent<Button>();
        // if add cutscene. Normal -> cutscene -> Level1 
        btnPlay.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.Cutscene);
            AudioManager.Instance.ButtonSound();
        });

        Button btnSelectLevel = GameObject.Find("btnSlectLevel").GetComponent<Button>();
        // if add cutscene. Normal -> cutscene -> Level1 
        btnSelectLevel.onClick.AddListener(() =>
        {
            AudioManager.Instance.ButtonSound();
        });

        Button btnExit = GameObject.Find("btnExit").GetComponent<Button>();
        btnExit.onClick.AddListener(() =>
        {
            ModeManager.Instance.ClearToMain();
            AudioManager.Instance.ButtonSound();
        });
    }

    public void ButtonSound()
    {
        AudioManager.Instance.PlaySound(TagManager.BUTTON);
    }
}
