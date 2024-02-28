using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Bird birdPlayer;
    Vector3 lastBirdPosition;
    float distanceToMove;

    private void Start()
    {
        birdPlayer = FindObjectOfType<Bird>();
        lastBirdPosition = birdPlayer.transform.position;
    }

    private void Update()
    {
        distanceToMove = birdPlayer.transform.position.x - lastBirdPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastBirdPosition = birdPlayer.transform.position;
    }
}
