using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public bool isDead;

    public event Action OnDie;
    public event Action OnHit;

    private void Awake()
    {
        isDead = false;
        health = maxHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (OnHit != null)
            OnHit();


        if (health <= 0)
        {
            isDead = false;
            Debug.Log(gameObject.name + (" is dead!"));
            if (OnDie != null)
                OnDie();
        }

        Debug.Log("Player takes " + damageTaken + "damage");
    }


    // public void RecieveHealth(int healthRecieved)
    // {
    // health += healthRecieved;
    //    if (health >= maxHealth)
    //health = maxHealth;

    //EventManager.current.PlayerHealthUpdated();

    // Debug.Log("Player recieves " + healthRecieved + "health");
    //}


}
