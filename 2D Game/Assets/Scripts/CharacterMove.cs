using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour {

public static CharacterMove instance;

// player movement variables
public float moveSpeed;
public float jumpHeight = 6;
public float respawnDelay;

// 0 = left, 1 = right
public static int direction;

public Rigidbody2D playerCharacter;
public GameObject bullet;
public GameObject swordObject;

//player grounded variables
public Transform groundCheck;
public float groundCheckRadius;
public LayerMask whatIsGround;

public static int reachCheckpoint;
public static int playerDie = 0; // 0 = alive, 1 = dead

private bool grounded, doubleJump = true;// true = able to double jump
public static float moveVelocity;

public static Vector3 spawn;
public static Vector3 currentPosition;

public static int leftRight; // 0 = left, 1 = right

public Transform firePoint;
public GameObject bulletClone;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "DeathBox")
		{
			Reset();
		}
		else if (other.name == "sword")
		{
			swordScript.gotSword = true;
		}
	}

	// Use this for initialization
	void Start () 
	{
		spawn = transform.position;
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

		// 
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
		if (Input.GetKey(KeyCode.RightArrow))
		{
			moveVelocity = moveSpeed;
			direction = 1;
			leftRight = 1;
		}

		//move left
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			moveVelocity = moveSpeed * -1;
			direction = 0;
			leftRight = 0;
		}

		if (playerDie == 1)
		{
			playerDie = 0;
			Reset();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (CharacterMove.direction > 0)
			{
				fireBullet.bulletVelocity = 7;
			}
			else
			{
				fireBullet.bulletVelocity = -7;
			}
			bulletClone = (GameObject) Instantiate(bullet, transform.position, transform.rotation);
		}

		if (fireBullet.didHit == true)
		{
			DestroyImmediate(bulletClone);
		}

		// moves the character every frame while moving
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		currentPosition = transform.position;

	}// end update



	public void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}

	public void Reset()
	{
		if (scoreManager.score <= 0 && reachCheckpoint == 0)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			transform.position = spawn;
			enemy.respawn = 1;
		}
		scoreManager.addPoints(-50);
	}

}