using System;
using TMPro;
using UnityEngine;

public class Bomb : Throwable 

{
    [SerializeField] private float explotionForce;
    [SerializeField] private int explotionTimer;
    [SerializeField] private float explotionRadius;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask damageable;

    [SerializeField] private Animator animator;
    private CountDownController countdownController;
    private Health health;
    private CameraShake cameraShake;
    
    private AudioSource audioSource;
    [SerializeField]private AudioClip explotionSFX;
    [SerializeField] private AudioClip bounceSFX;

    private bool isActivated = false;

    public event Action OnBombExplode;

    private void Awake()
    {
        countdownController = GetComponent<CountDownController>();
        health = GetComponent<Health>();
        cameraShake = FindObjectOfType<CameraShake>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        countdownController.OnCountdownFinished += CountdownController_OnCountdownFinished;
        health.OnDie += Health_OnDie;
        OnPickedUp += ActivateBomb;
        hasTimer = true;

    }

    private void OnEnable()
    {
        isExploding = false;
    }

    private void Health_OnDie()
    {
        ActivateBomb();
    }

    private void ActivateBomb()
    {
        if(!isActivated)
        {
            isActivated = true;
            countdownController._countdownTime = explotionTimer;
            countdownController.StartCountDown();
        }
    }

    private void CountdownController_OnCountdownFinished()
    {
        Explode();
    }

    private void Update()
    {
        if (isCarried)
        {
            carryPos = _carryTransform.position;
            transform.position = carryPos;
        }
    }

    void Explode ()
    {
        isExploding = true;
        if (OnBombExplode != null)
            OnBombExplode();

        audioSource.pitch = UnityEngine.Random.Range(.9f, 1.1f);
        audioSource.volume = UnityEngine.Random.Range(.9f, 1.1f);
        audioSource.clip = explotionSFX;
        audioSource.Play();

        cameraShake.Shake(.2f, 2f);

        animator.SetTrigger("Explode");

        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        GetComponent<BoxCollider2D>().isTrigger = true;

        CancelCarry();

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, explotionRadius, damageable);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Health>().TakeDamage(damage);
            enemiesToDamage[i].GetComponent<Rigidbody2D>().AddForce((enemiesToDamage[i].transform.position - transform.position).normalized * explotionForce, ForceMode2D.Impulse);
        }
        OnPickedUp -= ActivateBomb;
        countdownController.OnCountdownFinished -= CountdownController_OnCountdownFinished;
        health.OnDie -= Health_OnDie;
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            audioSource.pitch = UnityEngine.Random.Range(.9f, 1.1f);
            audioSource.volume = UnityEngine.Random.Range(.9f, 1.1f);
            audioSource.clip = bounceSFX;
            audioSource.Play();
        }
    }

}
