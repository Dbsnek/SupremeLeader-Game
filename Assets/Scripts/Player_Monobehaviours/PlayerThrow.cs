using System;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float throwForce;
    

    private CharacterController2D _characterController;
    private PlayerInput_KE _input;
    private Animator _animator;

    private Player _player;

    private float timeBtwAttack;
    private float startTimeBtwAttack = .3f;

    public event Action OnThrow;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController2D>();
        _input = GetComponent<PlayerInput_KE>();
        _player = GetComponent<Player>();
        _animator = _player.characterAnimator;
    }
    private void Start()
    {
        _input.OnButtonPressed += Input_OnButtonPressed;
    }

    private void OnEnable()
    {
        _player.throwable.OnCancelCarry += _throwable_OnCancelCarry;
        if (_player.throwable.hasTimer)
        {
            var countdownController = _player.throwable.GetComponentInParent<CountDownController>();
            if (countdownController != null)
            {
                countdownController.OnCountdownFinished += CountdownController_OnCountdownFinished;
            }
        }
    }

    private void Update()
    {
        if (_player.isCarrying)
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void Input_OnButtonPressed(string button)
    {
        if (_player.isCarrying)
        {
            if (timeBtwAttack <= 0)
            {
                if (button == "XbuttonDown")
                {
                    Debug.Log("Throwing!");
                    ThrowProjectile(_player.throwable);
                    timeBtwAttack = startTimeBtwAttack;
                    if (OnThrow != null)
                        OnThrow();
                }
            }
        }
    }
    void ThrowProjectile(Throwable throwable)
    {
        
        _animator.SetTrigger("Throw");
        throwable.Throw();
        if (_characterController.m_FacingRight == true)
            throwable.rb.AddForce((Vector2.right) * throwForce, ForceMode2D.Impulse);
        else
            throwable.rb.AddForce((Vector2.left) * throwForce, ForceMode2D.Impulse);
        _player.isCarrying = false;
        _animator.SetBool("Carrying", false);
    }

    public void CancelCarry()
    {
        _player.isCarrying = false;
        _animator.SetBool("Carrying", false);
    }
    private void _throwable_OnCancelCarry()
    {
        CancelCarry();
        //_player.throwable.OnCancelCarry -= _throwable_OnCancelCarry;
        //_player.throwable = null;
    }

    private void CountdownController_OnCountdownFinished()
    {
        CancelCarry();
        //_player.throwable.OnCancelCarry -= _throwable_OnCancelCarry;
        //_player.throwable = null;
    }

    public void DropCarry()
    {
        _player.throwable.Throw();
        _player.isCarrying = false;
        _player.throwable = null;
        _animator.SetBool("Carrying", false);
    }

}
