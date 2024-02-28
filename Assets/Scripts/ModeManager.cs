using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    public enum GameMode { Empty, Normal, Endless }
    public GameMode CurrentMode { get; private set; }
    public GameObject[] normalPrefabs;
    public GameObject[] endlessPrefabs;
    public Transform gameModeParent;
    public static ModeManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CurrentMode = GameMode.Empty;
    }

    public void StartNormalMode()
    {
        CurrentMode = GameMode.Normal;
        Loader.Load(Loader.Scene.Normal);
        InstantiateObject();
    }

    public void StartEndlessMode()
    {
        CurrentMode = GameMode.Endless;
        Loader.Load(Loader.Scene.Endless);
        InstantiateObject();
    }

    public void SwitchMode()
    {
        if (CurrentMode == GameMode.Normal)
        {
            DestroyModePrefab();
            StartEndlessMode();
        }
        else if (CurrentMode == GameMode.Endless)
        {
            DestroyModePrefab();
            StartNormalMode();
        }
    }

    public void InstantiateObject()
    {
        GameObject obj = null;
        switch (CurrentMode)
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
        CurrentMode = GameMode.Empty;
        Loader.Load(Loader.Scene.MainMenu);
    }
}
