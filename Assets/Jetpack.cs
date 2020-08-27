using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{

    public bool isFlying { get; private set; }

    [SerializeField] private float power;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float normalizeRotationSpeed;

    [SerializeField] private float boxLength;
    [SerializeField] private float boxHeight;

    [SerializeField] private Transform groundPosition;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private ParticleSystem jetpackEffect;

    private Player _player;
    private Rigidbody2D _rb;
    private PlayerInput_KE _input;
    private Collider2D[] isGrounded = new Collider2D[1];
    

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    void Start()
    {
        _rb = _player.rigidbody2D;
        _input = _player.input;
        _input.OnButtonPressed += _input_OnButtonPressed;
        isFlying = false;
    }

    private void _input_OnButtonPressed(string button)
    {
        if (!_player.hasJetpack)
            return;

        if (button == "AbuttonDown")
        {
            isFlying = true;
            PlayEffect();
        }
        else if (button == "AbuttonUp")
        {
            isFlying = false;
            StopEffect();
        }

    }

    void FixedUpdate()
    {
        if (!_player.hasJetpack)
            return;

        Thrust();
        Rotate();
        GroundCheck();

        if (isGrounded[0])
        {
            transform.rotation = Quaternion.identity;
            _rb.velocity = new Vector2(_input.movementInput.x * moveSpeed, _rb.velocity.y);
            _rb.freezeRotation = true;
        }

    }

    void Thrust()
    {
        if(isFlying)
            _rb.AddForce(transform.rotation * Vector2.up * power);
    }

    void PlayEffect()
    {
        jetpackEffect.Play();
    }

    void StopEffect()
    {
        jetpackEffect.Stop();
    }
    void Rotate()
    {
        _rb.freezeRotation = false;
        Vector3 rotation = new Vector3(0, 0, -_input.movementInput.x * rotationSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.fixedDeltaTime * normalizeRotationSpeed);
        transform.Rotate(rotation);
    }

    private void GroundCheck()
    {
        isGrounded[0] = null;
        Physics2D.OverlapBoxNonAlloc(groundPosition.position, new Vector2(boxLength, boxHeight), 0, isGrounded, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundPosition.position, new Vector2(boxLength, boxHeight));
    }

}
