using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {

	public static bool gotSword = false;
	public bool swordAttack = false;
	public Rigidbody2D playerBody;
	public GameObject playerObject;
	public int extraX = 10, timer = 0;

	public float speed = 0f; // multiple for how fast?

	// Use this for initialization
	void Start () 
	{
		gotSword = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gotSword == true)
		{
			transform.position = playerObject.transform.position; // sword stays by the player

			if (CharacterMove.direction != 0 && transform.eulerAngles.z > 1)// the player and sword are facing right
			{
				transform.Rotate(new Vector3(0, 0,180));
				//Debug.Log(transform.eulerAngles.z);
			}
			else if (CharacterMove.direction != 1 && transform.eulerAngles.z < 179) // the player and sword are facing left
			{
				transform.Rotate(new Vector3(0,0,180));
				//Debug.Log(transform.eulerAngles.z);
			}

			if(Input.GetKeyDown(KeyCode.M) && swordAttack == false)
			{
				transform.Rotate(new Vector3(0,0,-45));
				swordAttack = true;
			}

			if (timer < 0 && swordAttack == true)
			{
				transform.Rotate(new Vector3(0, 0, 10));
				timer++;
				if (timer > 90)
				{
					swordAttack = false;
					timer = 0;
					transform.Rotate(new Vector3(0, 0, -45));
				}
			}


		}

		transform.Rotate(Vector3.back, speed);// rotates the sword on the z axis, speed controls the speed of rotation

	}
}
