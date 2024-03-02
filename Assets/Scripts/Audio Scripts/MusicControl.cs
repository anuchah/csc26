using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    public bool isMuted = false;
    public Image onMusic;
    public Image offMusic;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioManager.Instance.musicSource.mute = isMuted;
    }

    void Update()
    {
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (isMuted == false)
        {
            onMusic.gameObject.SetActive(true);
            offMusic.gameObject.SetActive(false);
        }
        else
        {
            onMusic.gameObject.SetActive(false);
            offMusic.gameObject.SetActive(true);
        }
    }

    public void OnButtonPressMusic()
    {
        if (isMuted == false)
        {
            isMuted = true;
            AudioManager.Instance.musicSource.mute = true;
        }
        else
        {
            isMuted = false;
            AudioManager.Instance.musicSource.mute = false;
        }
        Save();

    }

    void Load()
    {
        isMuted = PlayerPrefs.GetInt("muted") == 1;
    }

    void Save()
    {
        PlayerPrefs.SetInt("muted", isMuted ? 1 : 0);
    }
}
