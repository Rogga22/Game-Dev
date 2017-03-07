using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrap : MonoBehaviour {

    GameObject player;
    public GameObject door;
    bool bossactivated;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        bossactivated = false;
    }
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && !bossactivated)
        {
            Instantiate(door, transform.position, transform.rotation);
            bossactivated = true;
        }
    }
}
