
using UnityEngine;

public class NormalState : IState
{
    private Health _health;
    private Player _player;
    private PlayerPickUp _playerPickUp;
    private PlayerMelee _playerMelee;
    private PlayerInput_KE _input;
    public NormalState(PlayerMovement playerMovement, GameObject character, Health health, Player player, PlayerPickUp playerPickUp, PlayerMelee playerMelee)
    {
        _health = health;
        _player = player;
        _playerPickUp = playerPickUp;
        _playerMelee = playerMelee;
        _input = _player.input;
    }
    public void OnEnter()
    {
        _health.OnDie += _health_OnDie;
        _input.OnButtonPressed += _input_OnButtonPressed;
        _player.timeBeforeNextPickUp = 1f;
        _player.hasMovement = true;
        _player.hasGrappling = true;
        _playerPickUp.enabled = true;
        _playerMelee.enabled = true;
    }

    private void _input_OnButtonPressed(string button)
    {
        if (button == "YbuttonDown")
        {
            _player.hasJetpack = true;
            Debug.Log("Player has jetpack " + _player.hasJetpack);
        }
    }

    private void _health_OnDie()
    {
        _player.isStunned = true;
    }

    public void OnExit()
    {
        _playerPickUp.enabled = false;
        _playerMelee.enabled = false;
        _player.hasMovement = false;
        _player.hasGrappling = false;
        _health.OnDie -= _health_OnDie;
        Debug.Log("exiting normalstate");
    }

    public void Tick()
    {
        if(_player.timeBeforeNextPickUp > 0)
            _player.timeBeforeNextPickUp -= Time.deltaTime;

        if (_player.hasJetpack == true)
            Debug.Log("I have jetpack!");
    }
}
