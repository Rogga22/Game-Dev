using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour {

    public AudioClip keypick;

    AudioSource source;
    GameObject player;
    PlayerKeys playkey;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playkey = player.GetComponent<PlayerKeys>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject == player)
        {
            source.PlayOneShot(keypick, 1f);
            playkey.keycount += 1;
            Destroy(gameObject, .05f);
        }
    }
}
