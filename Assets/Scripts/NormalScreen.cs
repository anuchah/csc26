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
        btnPlay.onClick.AddListener(() => LevelManager.GetInstance().StartLevel(LevelManager.Level.Level1));

        Button btnSwap = GameObject.Find("btnSwap").GetComponent<Button>();
        btnSwap.onClick.AddListener(() => ModeManager.GetInstance().SwitchMode());

        Button btnExit = GameObject.Find("btnExit").GetComponent<Button>();
        btnExit.onClick.AddListener(() => ModeManager.GetInstance().ClearToMain());
    }
}