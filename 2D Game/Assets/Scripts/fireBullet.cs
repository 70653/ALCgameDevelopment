using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {

	public GameObject bullet;
	public GameObject player;
	public Rigidbody2D playerCharacter;
	public Rigidbody2D bulletSprite;
	public bool canShoot = true;
	public float speed;
	public float bulletVelocity;
	public int bulletTimer = 0;
	public static bool didHit = false;


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name != "player")
		{
			didHit = true;
			canShoot = true;
			bulletSprite.GetComponent<Renderer>().enabled = false; // hides the bullet
			bulletTimer = 0;
		}
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if the bullet is in the air count how long it's in the air
		if (canShoot == false)
		{
			bulletTimer++;
		}


		if (Input.GetKeyDown(KeyCode.Space) && canShoot == true)
		{
			canShoot = false;
			didHit = false;
			bulletTimer = 0;

			transform.position = CharacterMove.currentPosition;

			bulletSprite.GetComponent<Renderer>().enabled = true;

			if (CharacterMove.direction > 0)
			{
				bulletVelocity = speed;
			}
			else
			{
				bulletVelocity = speed * -1;
			}
		}

		// if the bullet has been flying for a certain amount of time
		if (bulletTimer >= 90)
		{
			bulletTimer = 0;
			canShoot = true;
			bulletSprite.GetComponent<Renderer>().enabled = false;// hides the bullet
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelocity, 0);
	}// end update
}
