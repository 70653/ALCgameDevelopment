using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {

	public GameObject bullet;
	public GameObject player;
	public Rigidbody2D playerCharacter;
	public bool hit = true;
	public bool shoot = false;
	public float speed;
	public float bulletVelocity;


	void OnTriggerEnter2D (Collider2D other)
	{
		
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//bulletVelocity = 0f;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//Instantiate (bullet, CharacterMove.currentPosition, transform.rotation);
			shoot = true;
			hit = false;

			transform.position = CharacterMove.currentPosition;

			if (CharacterMove.direction > 0)
			{
				bulletVelocity = speed;
			}
			else
			{
				bulletVelocity = speed * -1;
			}
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelocity, 0);
	}
}
