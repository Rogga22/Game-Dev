using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour {

    public int keycount;
    GameObject[] doors;

	// Use this for initialization
	void Awake () {
        doors = GameObject.FindGameObjectsWithTag("Door");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject doors in doors)
        {
            if (other.gameObject == doors && keycount >= 1)
            {
                keycount -= 1;
                Destroy(other.gameObject, 1f);
            }
        }
    }
}
