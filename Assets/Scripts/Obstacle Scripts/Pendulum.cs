using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    #region Public field
    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;
    #endregion
    Rigidbody2D _rigidbody2D;
    #region Private field
    private bool movingClockwise;
    #endregion
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    void LateUpdate()
    {

        Move();
    }

    void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }

    }

    void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            _rigidbody2D.angularVelocity = moveSpeed;
        }

        if (!movingClockwise)
        {
            _rigidbody2D.angularVelocity = -1 * moveSpeed;
        }
    }
}
