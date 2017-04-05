using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    GameObject[] boulder;
    GameObject player;
    GameObject[] walls;
    GameObject[] doors;
    public float damage;

    PlayerHealth hitplayer;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        walls = GameObject.FindGameObjectsWithTag("Walls");
        boulder = GameObject.FindGameObjectsWithTag("Boulder");
        doors = GameObject.FindGameObjectsWithTag("Door");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Destroy(gameObject, 2f);
    }


    void OnTriggerStay2D(Collider2D other)
    {
            if (other.gameObject == player)
            {
                hitplayer = player.GetComponent<PlayerHealth>();
                hitplayer.TakeDamage(damage);
                Destroy(gameObject);
            }
        foreach (GameObject walls in walls)
        {
            if (other.gameObject == walls)
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

        foreach (GameObject boulder in boulder)
        {
            if (other.gameObject == boulder)
            {
                Destroy(gameObject);
            }
        }
    }
}
