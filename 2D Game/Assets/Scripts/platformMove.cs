using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour {
	public int counter = 0, counterMax = 60;
	public float blockMove, realMove = .1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		// moving the block to the right
		if (counter < counterMax)
		{
			blockMove = realMove;
		}
		// moving the block to the left
		else if (counter < counterMax * 2)
		{
			blockMove = realMove * -1;
		}
		else if (counter > counterMax * 2)
		{
			counter = 0;
		}

		//GetComponent<Rigidbody2D>().velocity = new Vector2(blockVelocity, 0);
		transform.position = new Vector3(transform.position.x + blockMove, 0, 0);
		//transform.position = new Vector3(transform.position.x, 0, 0);
		
	}
}
