using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {

	public GameObject bullet;
	public GameObject player;
	public Rigidbody2D playerCharacter;
	public Rigidbody2D bulletSprite;
	public static bool canShoot = true;
	public float speed;
	public static float bulletVelocity;
	public int bulletTimer = 0;
	public static bool didHit = false;


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name != "player" && other.name != "sword")
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
		bulletTimer++;
		
		// if the bullet is in the air count how long it's in the air
		if (canShoot == false)
		{
			bulletTimer++;
		}


		if (Input.GetKeyDown(KeyCode.Space) && canShoot == true) // if the player is able to shoot
		{
			canShoot = false;
			didHit = false;
			bulletTimer = 0;


			transform.position = CharacterMove.currentPosition; // bullet goes to the player

			bulletSprite.GetComponent<Renderer>().enabled = true; // shows the bullet

			// shoots the same direction the player is facing
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
		if (bulletTimer >= 120)
		{
			bulletSprite.GetComponent<Renderer>().enabled = false;// hides the bullet
			canShoot = true;
		}
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelocity, 0);


	}// end update
}
