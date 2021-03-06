﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float startingHealth;                            // The amount of health the player starts the game with.
	public float currentHealth;                                   // The current health the player has.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 1f);     // The colour the damageImage is set to, to flash.
    public Color deathcolor;

    public AudioClip takedamage;
	SpriteRenderer playercolor;                                 //Reference to player's color
	PlayerController playerMovement;                            // Reference to the player's movement.
    AudioSource source;
	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.


	void Awake ()
	{
		// Setting up the references.
		playercolor = GetComponent<SpriteRenderer>();
		playerMovement = GetComponent<PlayerController> ();
        source = GetComponent<AudioSource>();
		
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			playercolor.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			playercolor.color = Color.Lerp(playercolor.color, Color.white, flashSpeed * Time.deltaTime);
		}
		
		// Reset the damaged flag.
		damaged = false;
	}

	public void TakeDamage (float amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;
        source.PlayOneShot(takedamage, .5f);
		// Reduce the current health by the damage amount.
		currentHealth -= amount;

		
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;
        playercolor.color = Color.Lerp(playercolor.color, deathcolor, flashSpeed * Time.deltaTime);

        // Turn off being able to move and stuff
        playerMovement.enabled = false;

	}  


}
