using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    private void Awake()
    {
        Button btnNormal = GameObject.Find("btnNormal").GetComponent<Button>();
        btnNormal.onClick.AddListener(() => ModeManager.GetInstance().StartNormalMode());

        Button btnEndless = GameObject.Find("btnEndless").GetComponent<Button>();
        btnEndless.onClick.AddListener(() => ModeManager.GetInstance().StartEndlessMode());
    }
}
