using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private Transform _carryPoint;
    private Animator _animator;

    private Throwable _throwableHash;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = _player.characterAnimator;
        _carryPoint = _player.carrypoint;
    }
    private void OnEnable()
    {
        _throwableHash = null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(!_player.isCarrying && _player.timeBeforeNextPickUp <= 0)
        {
            _throwableHash = collision.gameObject.GetComponent<Throwable>();
            if (_throwableHash != null && !_throwableHash.isExploding)
            {
                _animator.SetBool("Carrying", true);
                _throwableHash.PickedUp(_carryPoint);
                _player.isCarrying = true;
                _player.throwable = _throwableHash;
            }
        }

    }



}
