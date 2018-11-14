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
			CharacterMove.bulletNumber--;
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () 
	{
		bulletTimer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bulletTimer++;

		if (CharacterMove.direction > 0)// shoots the same direction the player is facing
		{
			bulletVelocity = speed;
		}
		else
		{
			bulletVelocity = speed * -1;
		}

		// if the bullet has been flying for a certain amount of time
		if (bulletTimer >= 180)
		{

		}
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelocity, 0);

	}// end update
}
