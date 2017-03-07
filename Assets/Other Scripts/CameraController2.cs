using UnityEngine;
using System.Collections;

public class CameraController2 : MonoBehaviour {

	//This Controller is for having the camera move/follow the player in bigger rooms

	public Transform camTarget;
	GameObject player;


    public float yMax;
    public float yMin;
    public float xMax;
    public float xMin;

    void Start() {
		player = GameObject.FindWithTag("Player");
	}

    void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject == player) {

            //if within the bounds, camera locks onto player
            if (player.transform.position.y <= yMax && player.transform.position.y >= yMin && player.transform.position.x <= xMax && player.transform.position.x >= xMin) {
                Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            }

            //if player is above/below the y axis binders, camera locks to player on xAxis and stays stationary 
            //on yAxis
            if (player.transform.position.y > yMax){
                Camera.main.transform.position = new Vector3(player.transform.position.x, yMax, -10);
            }
            else if (player.transform.position.y < yMin){
                Camera.main.transform.position = new Vector3(player.transform.position.x, yMin, -10);
            }

            //if player is right/left of the xAxis binders, camera locks to player on yAxis and stays stationary 
            //on xAxis
            if (player.transform.position.x > xMax){
                Camera.main.transform.position = new Vector3(xMax, player.transform.position.y, -10);
            }
            else if (player.transform.position.x < xMin){
                Camera.main.transform.position = new Vector3(xMin, player.transform.position.y, -10);
            }

            //if player is above the yAxis binder, and to the right of the xAxis, the camera stays stationary
            if (player.transform.position.y > yMax && player.transform.position.x > xMax){
                Camera.main.transform.position = new Vector3(xMax, yMax, -10);
            }
            //if player is above the yAxis binder, and to the left of the xAxis, the camera stays stationary
            if (player.transform.position.y > yMax && player.transform.position.x < xMin){
                Camera.main.transform.position = new Vector3(xMin, yMax, -10);
            }
            //if player is below the yAxis binder, and to the right of the xAxis, the camera stays stationary
            if (player.transform.position.y < yMin && player.transform.position.x > xMax){
                Camera.main.transform.position = new Vector3(xMax, yMin, -10);
            }
            //if player is below the yAxis binder, and to the left of the xAxis, the camera stays stationary
            if (player.transform.position.y < yMin && player.transform.position.x < xMin){
                Camera.main.transform.position = new Vector3(xMin, yMin, -10);
            }

        }

    }
}
  

