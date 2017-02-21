using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    GameObject player;
    GameObject[] enemy;
    GameObject[] walls;

    EnemyHealth hitenemy;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        walls = GameObject.FindGameObjectsWithTag("Walls");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Destroy(gameObject, 2f);
    }


    void OnTriggerStay2D (Collider2D other)
    {
        foreach (GameObject enemy in enemy)
        {
            if (other.gameObject == enemy)
            {
                hitenemy = enemy.GetComponent<EnemyHealth>();
                hitenemy.TakeDamage(1);
                Destroy(gameObject);
            }
        }
        foreach (GameObject walls in walls)
        {
            if (other.gameObject == walls)
            {
                Destroy(gameObject);
            }
        }
    }
}
