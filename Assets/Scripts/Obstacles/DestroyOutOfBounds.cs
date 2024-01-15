using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _xLimitNegativePosition = -11;

    private void Update()
    {
        if (transform.position.x < _xLimitNegativePosition)
        {
            this.gameObject.SetActive(false);
        }
    }
}