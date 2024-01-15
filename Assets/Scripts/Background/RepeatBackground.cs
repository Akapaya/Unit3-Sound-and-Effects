using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] private Vector3 _initialPosition;
    [SerializeField] private float _repeatWidth;

    private void Start()
    {
        _initialPosition = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        if(transform.position.x < _initialPosition.x - _repeatWidth)
        {
            transform.position = _initialPosition;
        }
    }
}