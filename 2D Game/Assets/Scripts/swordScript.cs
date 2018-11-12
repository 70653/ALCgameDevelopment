using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {

	public static bool gotSword = false;
	public bool swordAttack = false;
	public Rigidbody2D playerBody;
	public GameObject playerObject;
	public Rigidbody2D swordBody;
	public int extraX = 10, timer = 0;
	public float currentAngle;
	public float originalAngle;

	public float speed = 0f; // multiple for how fast?

	// Use this for initialization
	void Start () 
	{
		gotSword = false;
		originalAngle = transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gotSword == true)
		{
			transform.position = playerObject.transform.position; // sword stays by the player

			if (CharacterMove.direction == 0 && swordBody.rotation == 0 && swordAttack == false)// if the player is facing left away from sword
			{
				swordBody.rotation = 180;
			}
			else if (CharacterMove.direction == 1 && swordBody.rotation == 180 && swordAttack == false) // if the player is facing right away from sword
			{
				swordBody.rotation = 0;
			}

			if(Input.GetKeyDown(KeyCode.M) && swordAttack == false)
			{
				Debug.Log(transform.eulerAngles.z);

				if (CharacterMove.direction == 1)// if the player is facing to the right
				{
					swordBody.rotation += 45;
				}
				else if (CharacterMove.direction == 0)// if the player is facing to the left
				{
					swordBody.rotation -= 45;
				}

				Debug.Log(transform.eulerAngles.z);
				swordAttack = true;
				//swordBody.rotation += 10;
			}

			if (swordAttack == true)
			{

			}


		}

		transform.Rotate(Vector3.back, speed);// rotates the sword on the z axis, speed controls the speed of rotation

	}
}
