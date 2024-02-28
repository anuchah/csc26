using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownDisplay;
    public int countdownTimer;
    public bool isCountdown = false;

    void Start()
    {
        StartCountdown();
    }

    void StartCountdown()
    {
        if (!isCountdown)
        {
            StartCoroutine(CountdownToStart());
            isCountdown = true;
        }
    }
    IEnumerator CountdownToStart()
    {

        while (countdownTimer > 0)
        {
            countdownDisplay.text = countdownTimer.ToString();
            countdownDisplay.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            countdownTimer--;
        }

        countdownDisplay.text = "LET'S GO!";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);

        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
        {
            NormalMode.Instance.StartGame();
            Debug.Log("Normal Start!");
        }

        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
        {
            EndlessMode.Instance.StartGame();
        }
    }
}
