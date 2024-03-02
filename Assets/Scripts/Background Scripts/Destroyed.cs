using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{
    #region Public field
    public GameObject destroyedPoint;
    #endregion

    private void Start()
    {
        destroyedPoint = GameObject.Find("DestroyedPoint");
    }

    private void Update()
    {
        if (transform.position.x < destroyedPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
