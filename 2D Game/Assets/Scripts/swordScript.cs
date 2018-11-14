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
	public float spinDelay;

	public float speed = 0f; // multiple for how fast?

	// Use this for initialization
	void Start () 
	{
		gotSword = false;
		swordBody.rotation = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (gotSword == true)
		{
			transform.position = playerObject.transform.position; // sword stays by the player

			if (CharacterMove.direction == 0 && swordAttack == false)// if the player is facing left
			{
				swordBody.rotation = 180;
			}
			else if (CharacterMove.direction == 1 && swordAttack == false) // if the player is facing right
			{
				swordBody.rotation = 0;
			}

			if(Input.GetKeyDown(KeyCode.M) && swordAttack == false)
			{
				swordAttack = true;

				if (CharacterMove.direction == 1)// if the player is facing to the right
				{
					swordBody.rotation = 45;
				}
				else if (CharacterMove.direction == 0)// if the player is facing to the left
				{
					swordBody.rotation = 135;
				}
				swingSword();
			}// end if

		}// end if

		transform.Rotate(Vector3.back, speed);// rotates the sword on the z axis, speed controls the speed of rotation

	}// end update

	public void swingSword()
	{
		StartCoroutine ("swingSwordCO");
	}// end swingSword

	public IEnumerator swingSwordCO()
	{
		if (swordBody.rotation == 45)// if sword is at 45 degrees
		{
			// starts at 45 goes to 340, 65 degrees 65/5 = 13
			for (int i = 0; i < 15; i++)
			{
				swordBody.rotation -= 5;
				yield return new WaitForSeconds (spinDelay);
			}
		}
		else if (swordBody.rotation == 135)// if sword is at 135 degrees
		{
			// starts at 135 goes to 200, 65 degrees 65/5 = 13
			for (int i = 0; i < 15; i++)
			{
				swordBody.rotation += 5;
				yield return new WaitForSeconds (spinDelay);
			}
		}
		swordAttack = false;
	}// end swingSwordCO

}
