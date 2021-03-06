﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    [Space]
    [Header("Before launch")]
    public float timeBeforeLaunch;

    [Space]
    [Header("First stage")]
    public float firstStageShakeamount;
    public float firstStageSpinAmount;
    public float timeBeforeFirstSeparation;
    [Space]
    [Header("Second stage")]
    public float secondStageShakeamount;
    public float secondStageSpinAmount;
    public float timeBeforeSecondSeparation;


    public event Action<int> OnStageSeparation;

    private float shakeAmount;

    private void Start()
    {
        StartCoroutine(StageSeparationManager());
        
    }
    private IEnumerator StageSeparationManager()
    {
        yield return new WaitForSeconds(timeBeforeLaunch);
        

        OnStageSeparation?.Invoke(0);
        BeginShake();
        shakeAmount = firstStageShakeamount;
        Debug.Log("Starting Engines!");
        
        yield return new WaitForSeconds(timeBeforeFirstSeparation);
        
        Debug.Log("Separating first stage!");
        OnStageSeparation?.Invoke(1);
        StopShake();
        shakeAmount = Mathf.Lerp(firstStageShakeamount, secondStageShakeamount, Time.deltaTime);
    
        yield return new WaitForSeconds(timeBeforeSecondSeparation);
        
        Debug.Log("Separating second stage!");
        OnStageSeparation?.Invoke(2);
        StopShake();
        
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 originalPos = transform.position;

            float offsetAmountX = UnityEngine.Random.value * shakeAmount * 2 - shakeAmount;
            float offsetAmountY = UnityEngine.Random.value * shakeAmount * 2 - shakeAmount;
            originalPos.x += offsetAmountX;
            originalPos.y += offsetAmountY;

            transform.position = originalPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        transform.localPosition = Vector3.Lerp(transform.position,  new Vector3(0,0,1),Time.deltaTime);
    }


}
