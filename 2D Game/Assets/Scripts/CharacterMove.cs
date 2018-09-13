using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

// player movement variables
public int moveSpeed;
public float jumpHeight;

//player grounded variables
public Transform groundCheck;
public float groundCheckRadius;
public LayerMask whatIsGround;
private bool grounded, doubleJump = true;// true = able to double jump

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
		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded)
		{
			Jump();
			doubleJump = true;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && doubleJump == true && grounded == false)
		{
			jumpHeight = 5;
			Jump();
			doubleJump = false;
		}
		//move right
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		//move left
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2((moveSpeed * -1), GetComponent<Rigidbody2D>().velocity.y);
		}
	}
	public void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		jumpHeight = 6;
	}
}