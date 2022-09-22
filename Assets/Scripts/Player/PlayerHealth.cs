using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public GameObject checkpoint;
    private CapsuleCollider2D coll2D;
    public override void HandleDamage(int damageValue)
    {
        base.HandleDamage(damageValue);

        // Reset player on death
        if(currentHealth <= 0)
        {
            this.gameObject.transform.position = checkpoint.transform.position;
            currentHealth = maxHealth;
            Debug.Log("Ouch, I'm dead noi");
        }
        
    }
}
