using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput_KE : MonoBehaviour
{
    public Vector2 movementInput { get; set; }

    public event Action<string> OnButtonPressed;

    public float Horizontal { get; set; }
    public float Vertical { get; set; }

    private void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
 
    private void OnAbutton(InputValue value)
    {
        var inputValue = value.Get<float>();
        if(inputValue == 1 && OnButtonPressed!= null)
             OnButtonPressed("AbuttonDown");
        if (inputValue == 0 && OnButtonPressed != null)
            OnButtonPressed("AbuttonUp");
    }
    private void OnBbutton(InputValue value)
    {
        var inputValue = value.Get<float>();
        if (inputValue == 1 && OnButtonPressed != null)
            OnButtonPressed("BbuttonDown");
        if (inputValue == 0 && OnButtonPressed != null)
            OnButtonPressed("BbuttonUp");
    }
    private void OnXbutton(InputValue value)
    {
        var inputValue = value.Get<float>();
        if (inputValue == 1 && OnButtonPressed != null)
            OnButtonPressed("XbuttonDown");
        if (inputValue == 0 && OnButtonPressed != null)
            OnButtonPressed("XbuttonUp");
    }
    private void OnYbutton(InputValue value)
    {
        var inputValue = value.Get<float>();
        if (inputValue == 1 && OnButtonPressed != null)
            OnButtonPressed("YbuttonDown");
        if (inputValue == 0 && OnButtonPressed != null)
            OnButtonPressed("YbuttonUp");
    }
    
}

