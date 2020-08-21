using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stjerneskudd : MonoBehaviour
{
    public float speed;
    private Vector2 originalPos;
    public float yBound;
    public bool isLooping;
    private bool isMoving = false;

    private RocketShip _rocketShip;
    private void Awake()
    {
        _rocketShip = FindObjectOfType<RocketShip>();
        _rocketShip.OnStageSeparation += _rocketShip_OnStageSeparation;
        originalPos = transform.position;
    }

    private void _rocketShip_OnStageSeparation(int value)
    {
        if (value == 0)
            isMoving = true;
    }

    void Update()
    {
        if(isMoving)
        {
            Move();
        }
        
    }

    private void Move()
    {
        transform.Translate(Vector2.up * -(speed * Time.deltaTime));
        if (!isLooping)
            return;

        if(transform.position.y <= yBound)
        { 
            transform.position = originalPos;
        }
    }

    private void OnDisable()
    {
        _rocketShip.OnStageSeparation -= _rocketShip_OnStageSeparation;
    }
}
