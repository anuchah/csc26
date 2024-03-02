using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private static Scene targetScene;

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(Scene.Loading.ToString());

        targetScene = scene;
    }

    public static void LoadTargetScene()
    {
        MonoBehaviour monoBehaviour = GameObject.Find("Loader Update").GetComponent<MonoBehaviour>();

        monoBehaviour.StartCoroutine(LoadDelayedScene());
    }

    private static IEnumerator LoadDelayedScene()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(targetScene.ToString());
    }

    public enum Scene
    {
        MainMenu,
        Loading,
        Endless,
        Gameplay,
        Shop,
        Normal,
        Cutscene,
        Level1,
        Level2,
        Level3,
    }
}
