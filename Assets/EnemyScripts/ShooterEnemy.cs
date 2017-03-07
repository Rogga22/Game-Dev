using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour {

    public float bulletspeed;
    public GameObject bulletprefab;
    public float shootingRate;
    public float shootCooldown;
    public float range;

    bool inRange;
    

    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth activeenemy;
    float dist;
    Vector3 shotangle;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        shootCooldown = (shootingRate - .8f);
        activeenemy = GetComponent<EnemyHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (activeenemy.active == true)
        {
            if (dist <= range)
            {
                inRange = true;
                shootCooldown += Time.deltaTime;
            }

            if (shootCooldown >= shootingRate && inRange)
            {
                Attack();
            }
        }

        if (playerHealth.currentHealth <= 0)
        {
            inRange = false;
        }
    }

    void Attack()
    {
        shootCooldown = 0f;
        shotangle = (player.transform.position - transform.position).normalized;
        var bullet = (GameObject)Instantiate(bulletprefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(shotangle * bulletspeed);
    }
}
