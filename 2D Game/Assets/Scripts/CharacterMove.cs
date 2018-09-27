using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

// player movement variables
public float moveSpeed;
public float jumpHeight = 6;

//player grounded variables
public Transform groundCheck;
public float groundCheckRadius;
public LayerMask whatIsGround;
private bool grounded, doubleJump = true;// true = able to double jump
private float moveVelocity;

	// Use this for initialization
	void Start () 
	{
	}
	
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		//player jump
		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded == true)
		{
			Jump();
		}
		if (grounded == true)
		{
			doubleJump = true;
		}
		// double jump
		if (Input.GetKeyDown (KeyCode.UpArrow) && doubleJump == true && grounded == false)
		{
			Jump();
			doubleJump = false;
		}
		// non slide player
		moveVelocity = 0f;
		//move right
		if (Input.GetKey (KeyCode.RightArrow))
		{
			moveVelocity = moveSpeed;
		}
		//move left
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			moveVelocity = moveSpeed * -1;
		}
		// moves the character every frame while moving
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
	}
	public void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}

}