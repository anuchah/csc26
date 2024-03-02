using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessScreen : MonoBehaviour
{
    public TextMeshProUGUI totalCoin;
    public TextMeshProUGUI highScore;
    private void Awake()
    {
        Button btnPlay = GameObject.Find("btnPlay").GetComponent<Button>();
        btnPlay.onClick.AddListener(() => Loader.Load(Loader.Scene.Gameplay));

        Button btnShop = GameObject.Find("btnShop").GetComponent<Button>();
        btnShop.onClick.AddListener(() => Loader.Load(Loader.Scene.Shop));

        Button btnExit = GameObject.Find("btnExit").GetComponent<Button>();
        btnExit.onClick.AddListener(() => ModeManager.Instance.ClearToMain());


    }

    void Update()
    {
        totalCoin.text = CoinManager.Instance.PrettyTotalCoin();
        highScore.text = ScoreManager.Instance.PrettyHighScore();
    }

    public void ButtonSound()
    {
        AudioManager.Instance.PlaySound(TagManager.BUTTON);
    }

}
