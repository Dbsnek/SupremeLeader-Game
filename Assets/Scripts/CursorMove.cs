using UnityEngine;

public class CursorMove : MonoBehaviour
{
    private float speed = 250;
    private Vector2 _movementInput;
    public PlayerInput_KE input;

    void Update()
    {
        GetInput();
        Move();
    }

    private void Move()
    {
        if (_movementInput != new Vector2(0, 0))
        {
            Vector2 movement = new Vector2(_movementInput.x, _movementInput.y) * speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
    private void GetInput()
    {
        _movementInput = input.movementInput;
    }
}
