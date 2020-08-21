using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryState : IState
{
    private Player _player;
    private PlayerThrow _playerThrow;
    private PlayerMovement _playerMovement;
    private GameObject _character;
    private Health _health;

    public CarryState (Player player, PlayerMovement playerMovement, GameObject character, Health health, PlayerThrow playerThrow)
    {
        _player = player;
        _playerThrow = playerThrow;
        _playerMovement = playerMovement;
        _character = character;
        _health = health;
    }
    public void OnEnter()
    {
        _playerThrow.enabled = true;
        Debug.Log("Entering Carrystate");
        _health.OnDie += _health_OnDie;
        _player.hasGrappling = false;
    }

    public void OnExit()
    {
        if (_player.isCarrying)
            _playerThrow.DropCarry();

        _playerThrow.enabled = false;
    }

    public void Tick()
    {

    }
    private void _health_OnDie()
    {
        _player.isStunned = true;
    }
}
