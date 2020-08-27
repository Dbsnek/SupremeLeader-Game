using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D _controller;
    [SerializeField] private Animator walkingAnimator;
    private PlayerInput_KE _input;
    private Vector2 _movementInput;
    private float horizontalMove;
    private Player _player;

    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    public event Action OnJump;

    private void Awake()
    {
        _player = GetComponent<Player>();
        
    }

    private void Start()
    {
        _controller = _player.characterController2D;
        _input = _player.input;
        _input.OnButtonPressed += Input_OnButtonPressed;
    }

    private void Input_OnButtonPressed(string button)
    {
        if (!_player.hasMovement)
            return;

        crouch = false;
        jump = false;

        if (button == "AbuttonDown")
        {
            if (OnJump != null)
                OnJump();

            jump = true;
            
        }
        else if (button == "BbuttonDown")
        {
            crouch = true;
        }
        else if (button == "BbuttonUp")
        {
            crouch = false;
        }

        
            
    }

    void Update()
    {
        if (!_player.hasMovement)
            return;

        Move();
        
         GetInput();
         if (horizontalMove != 0)
         {
             walkingAnimator.SetBool("Walking", true);
         }

         else
             walkingAnimator.SetBool("Walking", false);

        
    }

     void GetInput()
     {
         _movementInput = _input.movementInput;
         horizontalMove = _movementInput.x * runSpeed;
     }

    private void Move()
    {
        _controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }
}
