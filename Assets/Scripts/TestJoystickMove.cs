using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestJoystickMove : MonoBehaviour
{
    private float speed = 300;
    Vector2 movementInput;

    void Update()
    {
        Move();

    }

    private void Move()
    {
        if(movementInput != new Vector2(0, 0))
        {
            Vector2 movement = new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        
    }
    private void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        Debug.Log(movementInput);
    }
}
