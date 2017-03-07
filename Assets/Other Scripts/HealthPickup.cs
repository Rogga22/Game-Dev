using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    GameObject player;
    PlayerHealth playhp;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playhp = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && playhp.currentHealth < playhp.startingHealth)
        {
            playhp.currentHealth += 1;
            Destroy(gameObject);
        }
    }
}
