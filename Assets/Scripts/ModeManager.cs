using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    public enum GameMode { Empty, Normal, Endless }
    public GameMode currentMode;
    public GameObject[] normalPrefabs;
    public GameObject[] endlessPrefabs;
    public Transform gameModeParent;
    private static ModeManager instance;
    public static ModeManager GetInstance() => instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentMode = GameMode.Empty;
    }

    public void StartNormalMode()
    {
        currentMode = GameMode.Normal;
        Loader.Load(Loader.Scene.Normal);
        InstantiateObject();
    }

    public void StartEndlessMode()
    {
        currentMode = GameMode.Endless;
        Loader.Load(Loader.Scene.Endless);
        InstantiateObject();
    }

    public void SwitchMode()
    {
        if (currentMode == GameMode.Normal)
        {
            DestroyModePrefab();
            StartEndlessMode();
        }
        else if (currentMode == GameMode.Endless)
        {
            DestroyModePrefab();
            StartNormalMode();
        }
    }

    public void InstantiateObject()
    {
        GameObject obj = null;

        switch (currentMode)
        {
            case GameMode.Normal:
                for (int i = 0; i < normalPrefabs.Length; i++)
                {
                    obj = Instantiate(normalPrefabs[i], gameModeParent);
                }
                break;
            case GameMode.Endless:
                for (int i = 0; i < endlessPrefabs.Length; i++)
                {
                    obj = Instantiate(endlessPrefabs[i], gameModeParent);
                }
                break;
        }
    }
    private void DestroyModePrefab()
    {
        foreach (Transform child in gameModeParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void ClearToMain()
    {
        DestroyModePrefab();
        currentMode = GameMode.Empty;
        Loader.Load(Loader.Scene.MainMenu);
    }
}
