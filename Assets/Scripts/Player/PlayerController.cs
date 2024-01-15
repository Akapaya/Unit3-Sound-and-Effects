using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private PlayerData _playerData;
    private PlayerView _playerView;
    private Rigidbody _rigidBody;
    private Animator _animator;

    private bool _isOnGround;
    private bool _isAlive = true;
    
    public static UnityEvent GameOverEvent = new UnityEvent();

    private void Start()
    {
        _playerData = GetComponent<PlayerData>();
        _playerView = GetComponent<PlayerView>();
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        _animator.SetFloat("Speed_f", _playerData.MoveSpeed);
        _animator.SetBool("Static_b", true);
    }

    private void Update()
    {
        if (_isAlive)
        {
            CheckJump();
        }
    }

    private void CheckJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _animator.SetTrigger("Jump_trig");
            _rigidBody.AddForce(Vector3.up * _playerData.JumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerData.DisableDirtSplatter();
            _playerData.EnableJump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isOnGround = true;
            _playerData.EnableDirtSplatter();
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            GameOverEvent.Invoke();
            _animator.SetBool("Death_b", true);
            _isAlive = false;
            _playerData.EnableExplosion();
            _playerData.DisableDirtSplatter();
        }
    }
}