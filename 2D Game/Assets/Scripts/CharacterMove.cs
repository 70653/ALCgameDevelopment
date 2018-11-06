using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour {

public static CharacterMove instance;

// player movement variables
public float moveSpeed;
public float jumpHeight = 6;
public float respawnDelay = 1f;

// 0 = left, 1 = right
public static int direction;

public Rigidbody2D playerCharacter;// the player
public GameObject bullet;// the bullet
public GameObject swordObject;// the sword

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

public Rigidbody2D skull;// skull body

// end variables

	void OnTriggerEnter2D (Collider2D other) // if the player hits something
	{
		if (other.name == "DeathBox")
		{
			//Reset();
			respawnPlayer();
		}
		else if (other.name == "sword")
		{
			swordScript.gotSword = true;
		}

	}// onTrigger2D ends

	public void respawnPlayer()
	{
		StartCoroutine ("respawnPlayerCO");
	}// respawn player ends

	public IEnumerator respawnPlayerCO()
	{
		cameraScript.isFollowing = false;
		playerCharacter.GetComponent<Renderer>().enabled = false;
		skullScript.playerDied = true;
		yield return new WaitForSeconds (respawnDelay);
		skullScript.playerDied = false;
		if (scoreManager.score <= 0 && reachCheckpoint == 0) // did the player reach the checkpoint
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
		playerCharacter.GetComponent<Renderer>().enabled = true;
		cameraScript.isFollowing = true;
	}// respawn player co ends

	// Use this for initialization
	void Start () 
	{
		spawn = transform.position;
		playerCharacter.GetComponent<Renderer>().enabled = true;
	}// start ends
	
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}// fixed update ends

	// Update is called once per frame
	void Update () {
		//player jump
		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded == true)
		{
			Jump();
		}

		// is the player on the ground
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
			direction = 1;// direction = 1 is going to the right
			leftRight = 1;
		}

		//move left
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			moveVelocity = moveSpeed * -1;
			direction = 0;
			leftRight = 0;
		}

		if (playerDie == 1) // did the player die
		{
			playerDie = 0;
			//Reset();
			respawnPlayer();
		}

		if (jumpPadScript.onJumpPad == true)
		{
			jumpHeight = 18;
		}
		else
		{
			jumpHeight = 6;
		}

		// moves the character every frame while moving
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		currentPosition = transform.position;

	}// end update



	public void Jump() // jumping function
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}

	public void Reset() // reset or death function
	{
		//cameraScript.isFollowing = false;
		playerCharacter.GetComponent<Renderer>().enabled = true;
		if (scoreManager.score <= 0 && reachCheckpoint == 0) // did the player reach the checkpoint
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