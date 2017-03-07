using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour {
    public float timeBetweenAttacks;     // The time in seconds between each attack.
    public int attackDamage;               // The amount of health taken away per attack.

    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    public float timer;                                // Timer for counting up to the next attack.

    SpriteRenderer enemycolor;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 1f);
    public Color defaultcolor;

    EnemyHealth activeenemy;
    public float range;
    float maxrange;
    public float dist;
    bool inRange;

    Vector3 angle;
    public float movespd;


    // Use this for initialization
    void Awake () {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        timer = timeBetweenAttacks - .8f;
        enemycolor = GetComponent<SpriteRenderer>();
        defaultcolor = enemycolor.color;
        activeenemy = GetComponent<EnemyHealth>();
        maxrange = range * 4;
    }

    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        angle = (player.transform.position - transform.position).normalized;

        if (activeenemy.active == true && dist <= range)
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;
            range = maxrange;

            transform.position += angle * movespd * Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (timer >= timeBetweenAttacks && playerInRange)
            {
                // ... attack.
                Attack();
                enemycolor.color = flashColour;
            }
            else
            {
                enemycolor.color = Color.Lerp(enemycolor.color, defaultcolor, flashSpeed * Time.deltaTime);
            }

            // If the player has zero or less health...
            if (playerHealth.currentHealth <= 0)
            {
                playerInRange = false;
            }
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }

}
