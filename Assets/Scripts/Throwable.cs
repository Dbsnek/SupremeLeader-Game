using System;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public abstract class Throwable : MonoBehaviour
{
    public bool thrown = false;

    public bool isCarried = false;
    public bool hasTimer { get; set; }
    public bool isExploding { get; set; }

    public Transform _carryTransform { get; private set; }


    [SerializeField] public Rigidbody2D rb;

    public Vector2 carryPos { get; set; }
    

    public event Action OnPickedUp;
    public event Action OnCancelCarry;

    public void PickedUp(Transform carryTransform)
    {
        GetComponent<Collider2D>().enabled = false;
        rb.freezeRotation = true;
        isCarried = true;
        Physics2D.IgnoreLayerCollision(9, 11, false);
        _carryTransform = carryTransform;
        if (OnPickedUp != null)
            OnPickedUp();
    }
    public void Throw()
    {
        GetComponent<Collider2D>().enabled = true;
        thrown = true;
        rb.freezeRotation = false;
        isCarried = false;
    }

    public void CancelCarry()
    {
        GetComponent<Collider2D>().enabled = true;
        thrown = true;
        rb.freezeRotation = false;
        isCarried = false;
        if (OnCancelCarry != null)
            OnCancelCarry();
    }




}
