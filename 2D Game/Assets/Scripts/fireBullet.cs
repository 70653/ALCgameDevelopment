using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {

	//public GameObject bullet;
	//public GameObject player;
	//public Rigidbody2D playerCharacter;
	//public Rigidbody2D bulletSprite;
	//public static bool canShoot = true;
	private float speed;
	private float bulletVelocity;
	private int bulletTimer = 0;


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name != "player" && other.name != "sword")
		{
			Destroy(gameObject);
			CharacterMove.bulletNumber--;
		}
	}

	// Use this for initialization
	void Start () 
	{
		speed = 10f;
		bulletTimer = 0;
		if (CharacterMove.direction > 0)// shoots the same direction the player is facing
		{
			bulletVelocity = speed;
		}
		else
		{
			bulletVelocity = speed * -1;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		bulletTimer++;

		// if the bullet has been flying for a certain amount of time
		if (bulletTimer >= 100)
		{
			Destroy(gameObject);
			CharacterMove.bulletNumber--;
		}
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelocity, 0);

	}// end update
}
