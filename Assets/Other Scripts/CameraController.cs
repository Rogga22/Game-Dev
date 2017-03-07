using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform camTarget;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject == player)
        {

            Camera.main.transform.position = transform.position + new Vector3(0, 0, -10);
        }

    }
}
