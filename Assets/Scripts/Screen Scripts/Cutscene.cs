using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Animator transitionAnim;
    public TextMeshProUGUI textMesh;
    void Start()
    {
        StartCoroutine(LoadDelayedScene());
    }

    IEnumerator LoadDelayedScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(5f);
        AudioManager.Instance.PlaySound(TagManager.BIRD_FLY);
        textMesh.text = "FLY!";
        yield return new WaitForSeconds(2f);
        LevelManager.Instance.StartLevel(LevelManager.Level.Level1);
        transitionAnim.SetTrigger("Start");
    }
}
