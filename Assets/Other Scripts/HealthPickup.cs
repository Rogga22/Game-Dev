using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    public AudioClip healthpick;

    GameObject player;
    PlayerHealth playhp;
    AudioSource source;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playhp = player.GetComponent<PlayerHealth>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && playhp.currentHealth < playhp.startingHealth)
        {
            source.PlayOneShot(healthpick, 1f);
            playhp.currentHealth += 1;
            Destroy(gameObject, .05f);
        }
    }
}
