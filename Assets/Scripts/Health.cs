using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{   
    // Health Values
    public int currentHealth;
    public int maxHealth;

    // Heart images
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    

    // Update is called once per frame
    void Update()
    {
        // Checks if hearts = max health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        UpdateHealth();
    }

    public virtual void HandleDamage(int damageValue)
    {
        currentHealth -= damageValue;
    }

    private void UpdateHealth() 
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            {
                hearts[i].sprite = emptyHeart;
            }
            
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else 
            {
                hearts[i].enabled = false;
            }
        }
    }
}
