using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject birdPrefabs;

    private void Start()
    {
        Load();
    }

    void Load()
    {
        Instantiate(birdPrefabs, transform.position, transform.rotation);
    }
}
