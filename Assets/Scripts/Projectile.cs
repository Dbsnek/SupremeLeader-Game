using UnityEngine;

public class Projectile : Throwable
{
    private void Update()
    {
        if (isCarried)
        {
            carryPos = _carryTransform.position;
            transform.position = carryPos;
        }
    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (thrown)
        Destroy(gameObject);
    }
    */
}
