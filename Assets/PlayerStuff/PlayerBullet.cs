using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    GameObject[] boulder;
    GameObject[] enemy;
    GameObject[] walls;
    GameObject[] doors;
    GameObject[] cover;

    EnemyHealth hitenemy;

	// Use this for initialization
	void Awake () {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        walls = GameObject.FindGameObjectsWithTag("Walls");
        boulder = GameObject.FindGameObjectsWithTag("Boulder");
        doors = GameObject.FindGameObjectsWithTag("Door");
        cover = GameObject.FindGameObjectsWithTag("Cover");
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

        foreach (GameObject boulder in boulder)
        {
            if (other.gameObject == boulder)
            {
                Destroy(gameObject);
            }
        }

        foreach (GameObject door in doors)
        {
            if (other.gameObject == door)
            {
                Destroy(gameObject);
            }
        }

        foreach (GameObject cover in cover)
        {
            if (other.gameObject == cover)
            {
                Destroy(gameObject);
            }
        }

    }
}
