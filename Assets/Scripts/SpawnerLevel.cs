using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLevel : MonoBehaviour
{
    #region Public field
    public GameObject[] levels;
    public GameObject[] stars;
    public Transform levelPoint;
    private float[] levelWidths;
    private float[] starWidths;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    #endregion

    #region Private field
    private int levelSelector;
    #endregion

    private void Start()
    {
        levelWidths = new float[levels.Length];
        starWidths = new float[stars.Length];

        for (int i = 0; i < levels.Length; i++)
        {
            levelWidths[i] = levels[i].GetComponent<BoxCollider2D>().size.x;
            starWidths[i] = stars[i].GetComponent<BoxCollider2D>().size.x;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            Spawner();
        }

    }

    void Spawner()
    {
        if (transform.position.x < levelPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            levelSelector = Random.Range(0, levels.Length);

            transform.position = new Vector3(transform.position.x + levelWidths[levelSelector] + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(levels[levelSelector], transform.position, transform.rotation);

            Instantiate(stars[levelSelector], transform.position, transform.rotation);
        }
    }
}
