using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
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
        Gameplay1,
        Gameplay2,
        Gameplay3,
        Shop,
        Normal,
        Level1,
        Level2,
        Level3,
    }
}
