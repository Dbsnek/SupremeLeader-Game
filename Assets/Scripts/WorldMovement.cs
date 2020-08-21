using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xBound;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;    }

    // Update is called once per frame
    void Update()
    {
        MoveWorld();
        if(transform.position.x <= xBound)
        {
            transform.position = startPos;
        }
    }

    public void MoveWorld()
    {
        transform.Translate(Vector3.right * -speed * Time.deltaTime);
    }
}
