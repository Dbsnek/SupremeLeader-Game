using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_SFX : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private AudioClip landSFX;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip meleeSFX;
    [SerializeField] private AudioClip hitSFX;
    [SerializeField] private AudioClip throwSFX;
    

    private Player _player;
    private PlayerMovement _playerMovement;
    private CharacterController2D _characterController2D;
    private PlayerMelee _playerMelee;
    private Health _health;
    private PlayerThrow _playerThrow;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _playerMovement = _player.playerMovement;
        _characterController2D = _player.characterController2D;
        _playerMelee = _player.playerMelee;
        _health = _player.health;
        _playerThrow = _player.playerThrow;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _playerMovement.OnJump += _playerMovement_OnJump;
        _playerMelee.OnMelee += _playerMelee_OnMelee;
        _health.OnHit += _health_OnHit;
        _playerThrow.OnThrow += _playerThrow_OnThrow;
    }

    private void _playerThrow_OnThrow()
    {
        audioSource.pitch = Random.Range(.9f, 1.1f);
        audioSource.volume = Random.Range(.4f, .5f);
        audioSource.clip = throwSFX;
        audioSource.Play();
    }

    private void _health_OnHit()
    {
        audioSource.pitch = Random.Range(.5f, .6f);
        audioSource.volume = Random.Range(.4f, .5f);
        audioSource.clip = hitSFX;
        audioSource.Play();
    }

    private void _playerMelee_OnMelee()
    {
        audioSource.pitch = Random.Range(.9f, 1.1f);
        audioSource.volume = Random.Range(.4f, .5f);
        audioSource.clip = meleeSFX;
        audioSource.Play();
    }

    private void _playerMovement_OnJump()
    {
        if(_characterController2D.m_Grounded)
        {
            audioSource.pitch = Random.Range(.9f, 1.1f);
            audioSource.volume = Random.Range(.4f, .5f);
            audioSource.clip = jumpSFX;
            audioSource.Play();
        }
    }

    public void PlayLandingSound()
    {
        float velocity = GetComponentInParent<Rigidbody2D>().velocity.y;

        float modifier = 1;
        modifier -= velocity / 20;
        audioSource.pitch =  1 / (modifier);
        audioSource.volume = .1f * (modifier * 2);
        audioSource.clip = landSFX;
        audioSource.Play();
    }



}
