using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.
    public float bulletspeed;
    public GameObject bulletprefab;
    public Transform bulletSpawn;
    private Vector3 direction;

    SpriteRenderer spr;
    public Sprite idleup;
    public Sprite idledown;
    public Sprite idleleft;
    public Sprite idleright;
    bool up;
    bool down;
    bool left;
    bool right;

    // Use this for initialization
    void Start () {
        direction = Vector3.down;
        spr = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        if (left)
            spr.sprite = idleleft;
        if (right)
            spr.sprite = idleright;
        if (up)
            spr.sprite = idleup;
        if (down)
            spr.sprite = idledown;
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            direction = Vector3.left;
            left = true;
            right = false;
            up = false;
            down = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            direction = Vector3.right;
            right = true;
            left = false;
            up = false;
            down = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            direction = Vector3.up;
            up = true;
            down = false;
            left = false;
            right = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            direction = Vector3.down;
            down = true;
            up = false;
            left = false;
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var bullet = (GameObject)Instantiate(bulletprefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletspeed);
        }
    }

}
