using UnityEngine;
using System.Collections;
using System;

public class PlayerMelee : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public float attackBoost;

    private PlayerInput_KE _input;
    private CharacterController2D _characterController2D;
    private Animator _characterAnimator;
    private Animator _characterEffectAnimator;
    private Player _player;
    private Transform _firePoint;

    [SerializeField]
    private float meleeForce;

    public event Action OnMelee;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    private void Start()
    {
        timeBtwAttack = startTimeBtwAttack;
        _input = _player.input;
        _characterController2D = _player.characterController2D;
        _firePoint = _player.firePoint;
        _characterAnimator = _player.characterAnimator;
        _characterEffectAnimator = _player.characterEffectAnimator;
        _input.OnButtonPressed += Input_OnButtonPressed;
    }

    private void Input_OnButtonPressed(string button)
    {
        if (timeBtwAttack <= 0 && !_player.isCarrying)
        {
            if (button == "XbuttonDown")
            {
                StartCoroutine(MeleeAttack());
                timeBtwAttack = startTimeBtwAttack;
            }
        }
    }

    private void Update()
    {
        timeBtwAttack -= Time.deltaTime;
    }

    private IEnumerator MeleeAttack()
    {
        
        _characterAnimator.SetTrigger("Kick");
        _characterEffectAnimator.SetTrigger("Melee");

        if (_characterController2D.m_FacingRight)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * attackBoost, ForceMode2D.Impulse);
        else if (!_characterController2D.m_FacingRight)
            GetComponent<Rigidbody2D>().AddForce(-Vector2.right * attackBoost, ForceMode2D.Impulse);

        if (OnMelee != null)
            OnMelee();

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(_firePoint.position, attackRange, whatIsEnemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].gameObject != this.gameObject)
                    {
                        enemiesToDamage[i].GetComponent<Health>().TakeDamage(damage);
                        enemiesToDamage[i].GetComponent<Rigidbody2D>().AddForce((enemiesToDamage[i].transform.position - transform.position).normalized * meleeForce, ForceMode2D.Impulse);
                        Debug.Log(gameObject.name + (" hit") + enemiesToDamage[i].gameObject.name);
                    }
            }

        yield return new WaitForSeconds(.2f);

        enemiesToDamage = Physics2D.OverlapCircleAll(_firePoint.position, attackRange, whatIsEnemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if (enemiesToDamage[i].gameObject != this.gameObject)
            {
                enemiesToDamage[i].GetComponent<Health>().TakeDamage(damage);
                enemiesToDamage[i].GetComponent<Rigidbody2D>().AddForce((enemiesToDamage[i].transform.position - transform.position).normalized * meleeForce, ForceMode2D.Impulse);
                Debug.Log(gameObject.name + (" hit") + enemiesToDamage[i].gameObject.name);
            }
        }
    }
    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_firePoint.position, attackRange);
    }
    


    void PlayBodyHitSFX()
    {
        audioSource.clip = bodyHitSFX;
        audioSource.pitch = Random.Range(.9f, 1.1f);
        audioSource.volume = Random.Range(.5f, .6f);
        audioSource.Play();
    }
    */

}
