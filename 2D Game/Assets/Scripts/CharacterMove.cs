using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour {

public static CharacterMove instance;

// float variables
	// player movement variables
public float moveSpeed = 5;
public float jumpHeight = 6;
public static float moveVelocity;

public float respawnDelay = 1f;
public float groundCheckRadius;

// int variables
public static int direction;// 0 = left, 1 = right
public static int bulletNumber = 0;
public static int reachCheckpoint;
public static int playerDie = 0; // 0 = alive, 1 = dead
public static int leftRight; // 0 = left, 1 = right

// bool variables
private bool grounded, doubleJump = true;// true = able to double jump


// Rigidbody2D variables
public Rigidbody2D playerCharacter;// the player
public Rigidbody2D skull;// skull body
public Rigidbody2D newPlayerBody;


// GameObject variables
public GameObject bullet;// the bullet
public GameObject swordObject;// the sword
public GameObject particleRespawn;
public GameObject blockPlayer;
public GameObject newPlayerObject;


//player grounded variables
public Transform groundCheck;
public LayerMask whatIsGround;

// misc variables
public static Vector3 spawn;
public static Vector3 currentPosition;

public Transform firePoint;

public Animator animator;

public Collider2D blockCollider;
public Collider2D newPlayerCollider;

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
		Instantiate(particleRespawn, transform.position, transform.rotation);
		playerCharacter.GetComponent<Renderer>().enabled = true;
		cameraScript.isFollowing = true;
	}// respawn player co ends

	// Use this for initialization
	void Start () 
	{
		if (mainMenuScript.choice == "block")
		{
			Destroy(newPlayerObject);
			//newPlayerBody.GetComponent<Renderer>().enabled = false;// image
			//playerCharacter.GetComponent<Renderer>().enabled = true;// image
			//newPlayerCollider.enabled = false;// disable new player collider
			//blockPlayer.GetComponent<CharacterMove>().enabled = true;//script
			//newPlayerObject.GetComponent<newPlayerScript>().enabled = false;//script
		}
		else if (mainMenuScript.choice == "new")
		{
			Destroy(blockPlayer);
			//newPlayerBody.GetComponent<Renderer>().enabled = true;
			//playerCharacter.GetComponent<Renderer>().enabled = false;
			//blockCollider.enabled = false;// disable block collider
			//blockPlayer.GetComponent<CharacterMove>().enabled = false;//script
			//newPlayerObject.GetComponent<newPlayerScript>().enabled = true;//script
		}
		else if (mainMenuScript.choice == "none")
		{
			SceneManager.LoadScene(0);// level 0 is the main menu
		}
		
		spawn = transform.position;
		bulletNumber = 0;
		bullet = Resources.Load("Prefab/bullet") as GameObject;
		particleRespawn = Resources.Load("Prefab/particleRespawn") as GameObject;
		Instantiate(particleRespawn, transform.position, transform.rotation);

		animator.SetBool("isWalking", false);
		animator.SetBool("isStanding", true);
		
	}// start ends
	
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}// fixed update ends

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded == true)// player jump
		{
			Jump();
		}

		if (grounded == true)// is the player on the ground
		{
			doubleJump = true;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && doubleJump == true && grounded == false)// double jump
		{
			Jump();
			doubleJump = false;
		}
		
		moveVelocity = 0f;// non slide player


		if (Input.GetKey(KeyCode.RightArrow))// move right
		{
			moveVelocity = moveSpeed;
			direction = 1;// direction = 1 is going to the right
			leftRight = 1;
		}

		if (Input.GetKey(KeyCode.LeftArrow))// move left
		{
			moveVelocity = moveSpeed * -1;
			direction = 0;
			leftRight = 0;
		}

		if (playerDie == 1) // did the player die
		{
			playerDie = 0;
			respawnPlayer();
		}

		if (jumpPadScript.onJumpPad == true)// if player is on the jump pad
		{
			jumpHeight = 18;
		}
		else
		{
			jumpHeight = 6;
		}

		if (Input.GetKeyDown(KeyCode.Space) && bulletNumber < 3) // if the player is able to shoot
		{
			Instantiate(bullet, transform.position, transform.rotation);
			bulletNumber++;
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