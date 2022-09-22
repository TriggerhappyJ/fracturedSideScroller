using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{   
    // Health Values
    public int currentHealth;
    public int maxHealth;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void HandleDamage(int damageValue)
    {
        currentHealth -= damageValue;
    }

}
