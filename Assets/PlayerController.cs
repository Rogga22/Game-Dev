using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.
    public float bulletspeed;
    public GameObject bulletprefab;
    public Transform bulletSpawn;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
        direction = Vector3.up;


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
            direction = Vector3.left;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
            direction = Vector3.right;
        }
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
            direction = Vector3.up;
        }
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
            direction = Vector3.down;
		}
	}


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var bullet = (GameObject)Instantiate(bulletprefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletspeed);
        }
    }

}
