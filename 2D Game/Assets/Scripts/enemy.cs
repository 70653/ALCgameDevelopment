using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	// move variables
	public float moveSpeed;
	public bool moveRight;

	// wall check
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	//edge check
	private bool notAtEdge;
	public Transform edgeCheck;
	public Vector3 enemySpawn;
	public static int respawn = 0;
	// Use this for initialization
	void Start () 
	{
		enemySpawn = transform.position;
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{

	}

	// Update is called once per frame
	void Update () {
		notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge)
		{
			moveRight = !moveRight;
		}
		if (moveRight)
		{
			transform.localScale = new Vector3(-.2f, 0.2f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			transform.localScale = new Vector3(.2f, 0.2f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if (respawn == 1)
		{
			respawn = 0;
			transform.position = enemySpawn;
			moveRight = true;
		}
	}

	public static void Reset()
	{

	}

}
