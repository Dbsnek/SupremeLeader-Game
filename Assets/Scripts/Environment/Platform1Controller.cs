using UnityEngine;

public class Platform1Controller : Platform
{
    private bool movingRight = true;
    private float currentSpeed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }
    void Start()
    {
       currentSpeed = speed;
        
    }


    void FixedUpdate()
    {
        if(movingRight)
            rb.MovePosition(platform.position + platform.right * currentSpeed * Time.fixedDeltaTime);
       
        if(!movingRight)
            rb.MovePosition(platform.position - platform.right * currentSpeed * Time.fixedDeltaTime);

        if (platform.position.x >= waypoint2.position.x)
            movingRight = false;
        else if (platform.position.x <= waypoint1.position.x)
            movingRight = true;
    }
}
