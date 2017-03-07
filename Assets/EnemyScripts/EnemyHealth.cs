using UnityEngine;
using System.Collections;
using System;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 5;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
    public bool active;
    public float deathtime;

    SpriteRenderer enemycolor;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 1f);
    public Color defaultcolor;

    public bool isDead;                                // Whether the enemy is dead.
    bool damaged;
    
	
	void Awake ()
	{		
		// Setting the current health when the enemy first spawns.
		currentHealth = startingHealth;
        enemycolor = GetComponent<SpriteRenderer>();
        defaultcolor = enemycolor.color;
    }

    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            enemycolor.color = flashColour;
        }
        // Otherwise...
        if (!isDead)
        {
            // ... transition the colour back to clear.
            enemycolor.color = Color.Lerp(enemycolor.color, defaultcolor, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    public void TakeDamage (int amount)
	{
		// If the enemy is dead...
		if(isDead)
			// ... no need to take damage so exit the function.
			return;
		
		// Reduce the current health by the amount of damage sustained.
		currentHealth -= amount;
        damaged = true;

		// If the current health is less than or equal to zero...
		if(currentHealth <= 0)
		{
			// ... the enemy is dead.
			Death();
		}
	}

    void Death ()
	{
		// The enemy is dead.
		isDead = true;
        enemycolor.color = flashColour;
        // After a second destroy the enemy.
        Destroy (gameObject, deathtime);
	}
}