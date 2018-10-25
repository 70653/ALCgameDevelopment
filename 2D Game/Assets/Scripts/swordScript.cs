using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {

	public static bool gotSword = false;
	public Rigidbody2D playerBody;
	public GameObject playerObject;
	public int extraX = 10;

	public float speed = 0f; // multiple for how fast?

	// Use this for initialization
	void Start () 
	{
		gotSword = false;

		transform.Rotate(new Vector3(0,0,0)); 

		Debug.Log(transform.eulerAngles.z);

		transform.Rotate(new Vector3(0,0,180)); 

		Debug.Log(transform.eulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gotSword == true)
		{
			transform.position = playerObject.transform.position; // sword stays by the player

			if (Input.GetKeyDown (KeyCode.RightArrow))
			{
				if (CharacterMove.direction != 1)// if player was going to the left then turns right
				{
					transform.Rotate(new Vector3(0, 0,180)); 
				}
			}
			else if (Input.GetKeyDown (KeyCode.LeftArrow))
			{
				if (CharacterMove.direction != 0) // if player was going to the right then turns left
				{
					transform.Rotate(new Vector3(0,0,180)); 
				}
			}

			if (CharacterMove.direction > 0) // if player is going to the right
			{
				if (transform.eulerAngles.z != 0)
				{

				}
			}
			else // if going to the left
			{

			}
		}

		transform.Rotate(Vector3.back, speed);// rotates the sword on the z axis, speed controls the speed of rotation

	}
}
