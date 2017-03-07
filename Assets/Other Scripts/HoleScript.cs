using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {

    GameObject[] boulder;

	// Use this for initialization
	void Awake()
    {
        boulder = GameObject.FindGameObjectsWithTag("Boulder");

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject boulder in boulder)
        {
            if(other.gameObject == boulder)
            {
                Destroy(gameObject, 1f);
                other.transform.position = transform.position;
                Destroy(other.GetComponent<Rigidbody2D>());
                Destroy(other.GetComponent<PolygonCollider2D>());
            }
        }
    }
}
