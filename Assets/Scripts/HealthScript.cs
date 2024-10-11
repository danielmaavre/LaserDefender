using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int healthPoints = 50;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }        
    }

    private void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
