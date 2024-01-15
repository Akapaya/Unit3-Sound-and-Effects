using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float _moveSpeed;

    #region StartMethods
    private void OnEnable()
    {
        PlayerController.GameOverEvent.AddListener(StopMovement);
    }

    private void OnDisable()
    {
        PlayerController.GameOverEvent.RemoveListener(StopMovement);
    }
    #endregion

    private void Update()
    {
        transform.Translate(Vector3.left *  _moveSpeed * Time.deltaTime);
    }

    private void StopMovement()
    {
        _moveSpeed = 0;
    }
}