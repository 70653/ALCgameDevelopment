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
private bool grounded;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		//player jump
		if (Input.GetKeyDown (KeyCode.Space) && grounded)
		{
			Jump();
		}
	}
	public void Jump()
	{
	GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}