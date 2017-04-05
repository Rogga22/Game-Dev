using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public float timeBetweenAttacks;     // The time in seconds between each attack.
    public int attackDamage;               // The amount of health taken away per attack.

    public float bulletspeed;
    public GameObject bulletprefab;
    public GameObject keydrop;
    public float shootingRate;
    public float shootCooldown;

    bool dropkey;
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

    Vector3 angle;
    public float movespd;


    // Use this for initialization
    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        timer = timeBetweenAttacks - .8f;
        enemycolor = GetComponent<SpriteRenderer>();
        defaultcolor = enemycolor.color;
        activeenemy = GetComponent<EnemyHealth>();
        maxrange = range * 4;
        shootCooldown = (shootingRate - 4);
    }

    void FixedUpdate()
    {
        if (playerHealth.currentHealth > 0)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
            angle = (player.transform.position - transform.position).normalized;

            if (activeenemy.isDead)
            {
                if (!dropkey)
                {
                    Instantiate(keydrop, transform.position, transform.rotation);
                    Instantiate(keydrop, transform.position, transform.rotation);
                    dropkey = true;
                }
            }
            else
            {

                if (activeenemy.active == true && dist <= range)
                {
                    // Add the time since Update was last called to the timer.
                    timer += Time.deltaTime;
                    range = maxrange;

                    transform.position += angle * movespd * Time.deltaTime;

                    shootCooldown += Time.deltaTime;


                    if (shootCooldown >= shootingRate)
                    {
                        ShootAttack();
                    }
                    if (shootCooldown >= shootingRate + 2)
                        shootCooldown = 0;


                    // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
                    if (timer >= timeBetweenAttacks && playerInRange)
                    {
                        // ... attack.
                        MeleeAttack();
                        enemycolor.color = flashColour;
                    }
                    else
                    {
                        enemycolor.color = Color.Lerp(enemycolor.color, defaultcolor, flashSpeed * Time.deltaTime);
                    }
                }
            }
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            playerInRange = false;
        }

    }

    void ShootAttack()
    {
        angle = (player.transform.position - transform.position).normalized;
        var bullet = (GameObject)Instantiate(bulletprefab, transform.position, transform.rotation);
        bullet.GetComponent<EnemyShot>().damage = .3f;
        bullet.GetComponent<Rigidbody2D>().AddForce(angle * bulletspeed);
    }


    void MeleeAttack()
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
