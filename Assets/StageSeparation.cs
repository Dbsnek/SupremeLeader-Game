using System;
using System.Collections;
using UnityEngine;

public class StageSeparation : MonoBehaviour
{
    private ParticleSystem _ThrusterEffect;
    private float killTime = 10f;
    private event Action TimeToKillStage;
    [SerializeField] private int stageNumber;
    [SerializeField] private GameObject _thrusterLight;
    private Rigidbody2D [] _platformRigidBody2D;
    private RocketShip _rocketShip;
    

    private void Awake()
    {
        _ThrusterEffect = GetComponentInChildren<ParticleSystem>();
        TimeToKillStage += StageSeparation_TimeToKillStage;
        _rocketShip = GetComponentInParent<RocketShip>();
        _rocketShip.OnStageSeparation += _rocketShip_OnStageSeparation;
        _platformRigidBody2D = GetComponentsInChildren<Rigidbody2D>();
    }

    void SetActiveStage()
    {
        _ThrusterEffect.Play();
        _thrusterLight.SetActive(true);
    }
    private void _rocketShip_OnStageSeparation(int value)
    {
        if (value == (stageNumber - 1))
            SetActiveStage();

        if (value == stageNumber)
            SeparateStage();
    }

    private void StageSeparation_TimeToKillStage()
    {
       StopAllCoroutines();
        Destroy(gameObject, 5f);
    }

    public void SeparateStage()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        for (var i = 0; i < _platformRigidBody2D.Length; i++)
        {
            _platformRigidBody2D[i].bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("setting Rigidbody " + i + "to dynamic!");
        }
        
        _ThrusterEffect.Stop();
        StartCoroutine(KillStage());
        _thrusterLight.SetActive(false);
    }

    private IEnumerator KillStage()
    {
        yield return new WaitForSeconds(killTime);
        if (TimeToKillStage != null)
            TimeToKillStage();
    }
}
