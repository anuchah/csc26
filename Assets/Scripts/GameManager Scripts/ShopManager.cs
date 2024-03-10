using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public Character[] characters;
    public int selectedCharacter = 0;
    public Button unlockBtn;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI coinsAmount;
    public TextMeshProUGUI nameText;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);

        foreach (GameObject g in prefabs)
        {
            g.SetActive(false);
        }

        prefabs[selectedCharacter].SetActive(true);

        foreach (Character c in characters)
        {
            if (c.price == 0)
            {
                c.isUnlocked = true;
            }
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        nameText.text = characters[selectedCharacter].name.ToString();
        UpdateUI();
    }

    public void ChangeNext()
    {
        prefabs[selectedCharacter].SetActive(false);
        selectedCharacter++;

        if (selectedCharacter == prefabs.Length)
        {
            selectedCharacter = 0;
        }

        prefabs[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        nameText.text = characters[selectedCharacter].name.ToString();
        UpdateUI();
    }

    public void ChangePrevois()
    {
        prefabs[selectedCharacter].SetActive(false);
        selectedCharacter--;

        if (selectedCharacter == -1)
        {
            selectedCharacter = prefabs.Length - 1;
        }

        prefabs[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        nameText.text = characters[selectedCharacter].name.ToString();
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinsText.text = characters[selectedCharacter].price.ToString();
        coinsAmount.text = CoinManager.Instance.PrettyTotalCoin();
        if (characters[selectedCharacter].isUnlocked == true)
        {
            unlockBtn.gameObject.SetActive(false);
            
        }
        else
        {
            if (PlayerPrefs.GetInt("TotalCoin", 0) < characters[selectedCharacter].price)
            {
                unlockBtn.gameObject.SetActive(true);
                unlockBtn.interactable = false;
            }
            else
            {
                unlockBtn.gameObject.SetActive(true);
                unlockBtn.interactable = true;
            }
        }
    }

    public void Unlock()
    {

        int coin = PlayerPrefs.GetInt("TotalCoin", 0);
        int price = characters[selectedCharacter].price;
        int total = coin - price;
        PlayerPrefs.SetInt("TotalCoin", total);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        characters[selectedCharacter].isUnlocked = true;
        Debug.Log("Buy successfuly : " + PlayerPrefs.GetInt("TotalCoin", 0));
        AudioManager.Instance.PlaySound(TagManager.CASH);
        UpdateUI();
    }

    public void Destroyed()
    {
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 0);
        characters[selectedCharacter].isUnlocked = false;
        unlockBtn.gameObject.SetActive(true);
    }

    public void LoadToMain()
    {
        Loader.Load(Loader.Scene.Endless);
    }
}
