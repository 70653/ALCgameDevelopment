using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour {
	public int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter < 60)
		{
			moveRight();
		}
		else if (counter > 60)
		{
			if (counter >= 120)
			{
				counter = 0;
			}
			else
			{
				moveLeft();
			}
		}

		
		
	}
	public void moveLeft()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
	}

	public void moveRight()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
	}
}
