using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_SFX : MonoBehaviour
{
    private AudioSource audioSource;
    private CharacterController2D characterController2D;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        characterController2D = GetComponentInParent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController2D.isRunning && audioSource.isPlaying == false)
        {
            audioSource.pitch = Random.Range(2f, 2.2f);
            audioSource.volume = Random.Range(.4f, .5f);
            audioSource.Play();
        }


        else if (!characterController2D.isRunning)
            audioSource.Stop();
    }
}
