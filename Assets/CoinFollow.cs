using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFollow : MonoBehaviour
{
    private Bird birdPlayer;

    private void Start()
    {
        birdPlayer = FindObjectOfType<Bird>();
    }

    private void FixedUpdate()
    {
        if (birdPlayer.isMagnet)
        {
            if (Vector3.Distance(birdPlayer.transform.position, transform.position) <= 8)
                transform.position = Vector3.MoveTowards(transform.position, birdPlayer.transform.position, 20f * Time.fixedDeltaTime);
        }
    }
}
