using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXControl : MonoBehaviour
{
    public bool isMuted = false;
    public Image onSFX;
    public Image offSFX;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SFXmuted"))
        {
            PlayerPrefs.SetInt("SFXmuted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioManager.Instance.sfxSource.mute = isMuted;
    }

    void Update()
    {
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (isMuted == false)
        {
            onSFX.gameObject.SetActive(true);
            offSFX.gameObject.SetActive(false);
        }
        else
        {
            onSFX.gameObject.SetActive(false);
            offSFX.gameObject.SetActive(true);
        }
    }

    public void OnButtonPressSFX()
    {
        if (isMuted == false)
        {
            isMuted = true;
            AudioManager.Instance.sfxSource.mute = true;
        }
        else
        {
            isMuted = false;
            AudioManager.Instance.sfxSource.mute = false;
        }
        Save();

    }

    void Load()
    {
        isMuted = PlayerPrefs.GetInt("SFXmuted") == 1;
    }

    void Save()
    {
        PlayerPrefs.SetInt("SFXmuted", isMuted ? 1 : 0);
    }
}
