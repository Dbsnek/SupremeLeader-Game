using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterEffects : MonoBehaviour
{
    private Animator _animator;

    private Vector2 positionHash;
    private float landingTimer;
    private Player _player;
    private PlayerMelee _playerMelee;
    private Health _health;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _player = GetComponentInParent <Player>();
        _playerMelee = _player.playerMelee;
        _health = _player.health;
    }

    private void Start()
    {
        _playerMelee.OnMelee += _playerMelee_OnMelee;
        _health.OnHit += _health_OnHit;
    }

    private void _health_OnHit()
    {
        _animator.SetTrigger("Hit");
        positionHash = _player.transform.position;
        landingTimer = 2f;
    }

    private void _playerMelee_OnMelee()
    {
        _animator.SetTrigger("Melee");
        positionHash = _player.transform.position;
        landingTimer = 2f;
    }

    public void InvokeLandEffect()
    {
       
        _animator.SetTrigger("Lands");
        positionHash = _player.transform.position;
        landingTimer = 2f;
    }




    private void Update()
    {
        
        if (landingTimer >  0)
        {
            transform.position = positionHash + new Vector2(0, -.4f);
            landingTimer -= Time.deltaTime;
        }


    }

}
