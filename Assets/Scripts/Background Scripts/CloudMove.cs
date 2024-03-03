using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float obstacleSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
    }

}
