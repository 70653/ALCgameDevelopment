using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerScript : MonoBehaviour {

	// int variables
	public static int playerDirection;

	// float variables
	public float moveSpeed = 5;
	public float moveVelocity;
	public float turnCorrection;

	public Animator myAnimator;

	// Use this for initialization
	void Start () 
	{
		myAnimator.SetBool("isWalking", false);
		myAnimator.SetBool("isStanding", true);
		playerDirection = 1;
		//Debug.Log(GetComponent<SpriteRenderer>().bounds.size.x);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKey == false)
		{
			myAnimator.SetBool("isStanding", true);
			myAnimator.SetBool("isWalking", false);
		}

		moveVelocity = 0f;// non slide player
		
		if (Input.GetKey(KeyCode.RightArrow))
		{
			myAnimator.SetBool("isStanding", false);
			myAnimator.SetBool("isWalking", true);

			moveVelocity = moveSpeed;

			if (playerDirection != 1)
			{
				playerDirection = 1;
				myAnimator.transform.Rotate(0, 180, 0);
				transform.position = new Vector3(transform.position.x + turnCorrection, transform.position.y, 0);// (x position, y position, z position)
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			myAnimator.SetBool("isStanding", false);
			myAnimator.SetBool("isWalking", true);
			
			moveVelocity = -moveSpeed;

			if (playerDirection != -1)
			{
				playerDirection = -1;
				myAnimator.transform.Rotate(0, 180, 0);
				transform.position = new Vector3(transform.position.x - turnCorrection, transform.position.y, 0);
			}
		}
		

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

	}
}
