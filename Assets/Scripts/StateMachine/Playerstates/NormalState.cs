using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IState
{
    private PlayerMovement _playerMovement;
    private GameObject _character;
    private Health _health;
    private Player _player;
    private PlayerPickUp _playerPickUp;
    private PlayerMelee _playerMelee;
    public NormalState(PlayerMovement playerMovement, GameObject character, Health health, Player player, PlayerPickUp playerPickUp, PlayerMelee playerMelee)
    {
        _playerMovement = playerMovement;
        _character = character;
        _health = health;
        _player = player;
        _playerPickUp = playerPickUp;
        _playerMelee = playerMelee;
    }
    public void OnEnter()
    {
        _health.OnDie += _health_OnDie;
        _player.isStunned = false;
        _playerPickUp.enabled = true;
        _playerMelee.enabled = true;
        _player.timeBeforeNextPickUp = 1f;
        _player.hasMovement = true;
        _player.hasGrappling = true;
    }

    private void _health_OnDie()
    {
        _player.isStunned = true;
    }

    public void OnExit()
    {
        _playerPickUp.enabled = false;
        _playerMelee.enabled = false;
    }

    public void Tick()
    {
        if(_player.timeBeforeNextPickUp > 0)
            _player.timeBeforeNextPickUp -= Time.deltaTime;
    }



}
