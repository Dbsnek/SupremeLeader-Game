
using UnityEngine;

public class JetpackState : IState
{
    private Player _player;
    private Jetpack _jetpack;
    private Rigidbody2D rb;
    private PlayerInput_KE _input;
    public JetpackState (Player player)
    {
        _player = player;
        _jetpack = _player.jetpack;
        rb = _player.rigidbody2D;
        _input = _player.input;
    }
    public void OnEnter()
    {
        Debug.Log("Entering jetpackState!");
        rb.freezeRotation = false;
        _input.OnButtonPressed += _input_OnButtonPressed;
    }

    private void _input_OnButtonPressed(string button)
    {
       if (button == "YbuttonDown")
        {
            _player.hasJetpack = false;
        }
    }

    public void OnExit()
    {
        rb.freezeRotation = true;
    }

    public void Tick()
    {
        
    }


}
