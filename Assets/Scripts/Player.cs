using System;
using System.Runtime.CompilerServices;
using UnityEngine;


public delegate void PlayerHitHandler();
public class Player : MonoBehaviour
{
    #region Declarations and fields

    //Privates
    private StateMachine _stateMachine;
    private PlayerMovement _playerMovement;
    
    private PlayerPickUp _playerPickUp;
    private PlayerThrow _playerThrow;
    private PlayerMelee _playerMelee;
    private CameraShake _cameraShake;
    

    //Hidden publics
    public CharacterController2D characterController2D { get; set; }
    public Throwable throwable { get; set; }
    public PlayerInput_KE input { get; set; }
    public Rigidbody2D rigidbody2D {get;set;}
    public PlayerMovement playerMovement { get; private set; }
    public PlayerMelee playerMelee { get; set; }

    public Health health { get; private set; }
    public PlayerThrow playerThrow { get; private set; }
    public Transform spawnPoint { get; set; }

    private bool hasPlayerJoined = false;
    public bool isStunned { get; set; }
    public bool isCarrying { get; set; }
    public bool isGrappling { get; set; }
    public bool hasMovement { get; set; }
    public bool hasGrappling { get; set; }

    public bool hasGravity;
    public float timeBeforeNextPickUp { get; set; }

    public Animator characterAnimator;
    public Animator characterEffectAnimator;

    public event PlayerHitHandler _PlayerHit;
    

    //Visible in inspector

    [Header("Dependancies")]
    public Transform startposition;

    [Header("Selected character")]
    public string character;

    public GameObject cursor { get; set; }
    public GameObject playerSelectedSlot { get; set; }
    public GameObject _CharacterGFX { get; set; }

    private GameObject _character;

    [Header("Points and Transforms")]
    public Transform carrypoint;
    public Transform firePoint;

    public int PlayerNumber;
    public Quaternion originalCharacterRotation;

    #endregion

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _playerMovement = GetComponentInChildren<PlayerMovement>();
        health = GetComponent<Health>();
        _character = transform.GetChild(0).gameObject;
        _CharacterGFX = GameObject.Find("Character_GFX");
        _playerPickUp = GetComponent<PlayerPickUp>();
        _playerThrow = GetComponent<PlayerThrow>();
        _playerMelee = GetComponent<PlayerMelee>();
        _cameraShake = FindObjectOfType<CameraShake>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterController2D = GetComponent<CharacterController2D>();
        playerMelee = GetComponent<PlayerMelee>();
        playerMovement = GetComponent<PlayerMovement>();
        playerThrow = GetComponent<PlayerThrow>();
        input = GetComponent<PlayerInput_KE>();
        originalCharacterRotation = _CharacterGFX.transform.rotation;
        

        //States
        var playerSelectState = new PlayerSelectState(cursor, playerSelectedSlot);
        var stunnedState = new StunnedState(this, _CharacterGFX, characterController2D);
        var normalState = new NormalState(_playerMovement, _character, health, this, _playerPickUp, _playerMelee);
        var carryState = new CarryState(this, _playerMovement, _CharacterGFX, health, _playerThrow);

        //Transitions
        //AddTransition(deadState, playerSelectState, PlayerHasJoined());
        AddTransition(stunnedState, normalState, PlayerIsNotStunned());
        AddTransition(normalState, carryState, IsCarrying());
        AddTransition(carryState, normalState, IsNotCarrying());

        AddAnyTransition(stunnedState, PlayerIsStunnedd());


        _stateMachine.SetState(normalState);

        void AddTransition(IState from, IState to, Func<bool> condition)
        {
            _stateMachine.AddTransition(from, to, condition);
        }

        void AddAnyTransition(IState to, Func<bool> condition)
        {
            _stateMachine.AddAnyTransition( to, condition);
        }
        //Bools
        //Func<bool> PlayerHasJoined() => () => hasPlayerJoined == true;
        Func<bool> PlayerIsStunnedd() => () => isStunned == true;
        Func<bool> PlayerIsNotStunned() => () => isStunned == false;
        Func<bool> IsCarrying() => () => isCarrying == true;
        Func<bool> IsNotCarrying() => () => isCarrying == false;
    }

    private void Start()
    {
        health.OnHit += _health_OnHit;
        if (!hasGravity)
            rigidbody2D.gravityScale = 0;
        transform.position = spawnPoint.position;
    }

    private void _health_OnHit()
    {
        characterAnimator.SetTrigger("Hit");
        _cameraShake.Shake(.1f, .1f);
        
        if (_PlayerHit != null)
            _PlayerHit();
    }

    private void OnDisable()
    {
        health.OnHit -= _health_OnHit;
    }


    void Update()
    {
        _stateMachine.Tick();
    }

    public void PlayerJoined()
    {
        hasPlayerJoined = true;
        Debug.Log("Player joined!");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            transform.position = Vector3.zero;
        }
    }
}
