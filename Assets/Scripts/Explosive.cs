using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Explosive : MonoBehaviour
{
    public bool hasCountdown;
    public float countdownTime;

    private void Awake()
    {
        if(hasCountdown)
        {

        }
    }


    public void Detonate()
    {
        if (hasCountdown)
        {

        }
        else
        {

        }
    }
}
