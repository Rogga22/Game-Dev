using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrap : MonoBehaviour {

    GameObject player;
    public GameObject door;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Instantiate(door, transform.position, transform.rotation);
        }
    }
}
