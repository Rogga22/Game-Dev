using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour {

    GameObject player;
    PlayerKeys playkey;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playkey = player.GetComponent<PlayerKeys>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject == player)
        {
            playkey.keycount += 1;
            Destroy(gameObject);
        }
    }
}
