using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] birdPrefabs;
    int selectedCharacter;
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
        Load();
    }

    void Update()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
    }

    void Load()
    {
        Instantiate(birdPrefabs[selectedCharacter], transform.position, transform.rotation);
    }
}
