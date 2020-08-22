using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterMovement : MonoBehaviour
{
    [SerializeField] private float xBound;
    [SerializeField] private float speed = 1;
    [SerializeField] private float maxXScale;
    [SerializeField] private bool hasScale;
    private Vector2 restartPoint;


    private void Start()
    {
        restartPoint.x -= xBound;
    }
    void Update()
    {
        Move();

        if(hasScale)
            Scale();
    }

    private void Move()
    {
        transform.Translate(Vector2.right *  speed * Time.deltaTime);

        if (transform.localPosition.x > xBound)
        {
            transform.localPosition = restartPoint;
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
