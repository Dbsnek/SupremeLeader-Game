using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : IState
{
    private GameObject _CharacterGFX;
    private Player _player;
    private float stunnedtimer;
    private CharacterController2D _characterController2D;
    public StunnedState (Player player, GameObject characterGFX, CharacterController2D characterController2D)
    {
        _CharacterGFX = characterGFX;
        _player = player;
        _characterController2D = characterController2D;
    }

    public void OnEnter()
    {
        _characterController2D.Move(0, false, false);
        _player.hasMovement = false;
        _player.isStunned = true;
        _CharacterGFX.transform.Rotate(Vector3.forward, 90f);
        stunnedtimer = 5f;
        _player.rigidbody2D.velocity = Vector3.zero;
    }

    public void OnExit()
    {
        _CharacterGFX.transform.rotation = _player.originalCharacterRotation;
    }

    public void Tick()
    {
        stunnedtimer -= Time.deltaTime;
        if(stunnedtimer <= 0)
        {
            _player.isStunned = false;
        }
    }
}
