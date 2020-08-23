using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterMovement : MonoBehaviour
{
    [SerializeField] private float xBound;
    
    [SerializeField] private float maxXScale;
    [SerializeField] private bool hasScale;

    private Vector2 restartPoint;
    private Rigidbody2D rb;
    private bool rocketIsSpinning = false;
    private float newSpeed;
    private float speed;

    private RocketShip _rocketShip;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _rocketShip = FindObjectOfType<RocketShip>();
        _rocketShip.OnStageSeparation += _rocketShip_OnStageSeparation;
    }

    private void _rocketShip_OnStageSeparation(int value)
    {
        if (value == 0)
        {
            rocketIsSpinning = true;
            newSpeed = _rocketShip.firstStageSpinAmount;
        }

        else if (value == 1)
        {
            newSpeed = _rocketShip.secondStageSpinAmount;
        }

        else if(value == 2)
        {
            newSpeed = 0;
        }
            
    }

    private void Start()
    {
        restartPoint.x -= xBound;
    }
    void Update()
    {
        if (!rocketIsSpinning)
            return;

        Move();

        if(hasScale)
            Scale();
    }

    private void Move()
    {
        if (newSpeed != speed)
            speed = Mathf.Lerp(speed, newSpeed, (0.1f*Time.deltaTime));

        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);

        if (transform.localPosition.x > xBound)
        {
            transform.localPosition = restartPoint;
        }

        if (speed == 0)
        {
            rocketIsSpinning = false;
        }
        
    } 

    void Scale()
    {
        float distance = Vector2.Distance(transform.localPosition, Vector2.zero);
        float t =  1f -(distance / 10);
        float xScale = Mathf.Lerp(0, maxXScale, t);
        transform.localScale = new Vector2(xScale, transform.localScale.y);
    } 

}
