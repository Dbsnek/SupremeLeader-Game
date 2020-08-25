using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterMovement : MonoBehaviour
{
    #region Fields and declarations
    [SerializeField] private float xBound;
    [SerializeField] private float maxXScale;
    [SerializeField] private bool hasScale;
    [SerializeField] private Vector2 restartPoint;
    [SerializeField] private int stage;
    [SerializeField] private bool hasFlame;

    private Rigidbody2D rb;
    private RocketShip _rocketShip;
    private SpriteRenderer spriteRenderer;
    private GameObject rocketFlame;

    private bool rocketIsSpinning = false;
    
    private float newSpeed;
    private float speed;

    #endregion
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rocketShip = FindObjectOfType<RocketShip>();
        _rocketShip.OnStageSeparation += _rocketShip_OnStageSeparation;
        if(hasFlame)
            rocketFlame = transform.Find("RocketFlame").gameObject;
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
            if (stage == 1)
                rocketIsSpinning = false;

            newSpeed = _rocketShip.secondStageSpinAmount;
            
        }

        else if(value == 2)
        {
            newSpeed = 0;
            if(stage == 2)
                rocketIsSpinning = false;
        }
            
    }

    private void Start()
    {
        if(restartPoint.x == 0)
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
    private void LateUpdate()
    {
        ShowGFX();
    }

    private void ShowGFX()
    {
        if (transform.localPosition.x < -xBound)
        {
            spriteRenderer.enabled = false;
            Debug.Log(rocketFlame);
            if (rocketFlame != null)
                rocketFlame.SetActive(false);
        }

        else
        {
            spriteRenderer.enabled = true;
            if (rocketFlame != null)
                rocketFlame.SetActive(true);
        }
    }
    private void Move()
    {
        if (newSpeed != speed)
            speed = Mathf.Lerp(speed, newSpeed, (0.05f*Time.deltaTime));

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

    private void OnDisable()
    {
        _rocketShip.OnStageSeparation -= _rocketShip_OnStageSeparation;
    }
}
