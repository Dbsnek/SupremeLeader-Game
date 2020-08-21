using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShipSFX : MonoBehaviour
{
    [SerializeField] private AudioClip _separationSFX;
    private RocketShip _rocketShip;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rocketShip = GetComponentInParent<RocketShip>();
    }
    private void Start()
    {
        _rocketShip.OnStageSeparation += _rocketShip_OnStageSeparation;
    }

    private void _rocketShip_OnStageSeparation(int obj)
    {
        PlaySeparationSFX();
    }

    private void PlaySeparationSFX()
    {
        _audioSource.pitch = Random.Range(.9f, 1.1f);
        _audioSource.volume = Random.Range(.4f, .5f);
        _audioSource.clip = _separationSFX;
        _audioSource.Play();
    }
}
