using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {

	public static bool gotSword = false;
	public bool swordAttack = false;
	public Rigidbody2D playerBody;
	public GameObject playerObject;
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

			if (CharacterMove.direction != 0 && transform.eulerAngles.z > 1 && swordAttack == false)// the player and sword are facing right
			{
				transform.Rotate(new Vector3(0, 0,180));
				//Debug.Log(transform.eulerAngles.z);
			}
			else if (CharacterMove.direction != 1 && transform.eulerAngles.z < 179 && swordAttack == false) // the player and sword are facing left
			{
				transform.Rotate(new Vector3(0,0,180));
				//Debug.Log(transform.eulerAngles.z);
			}

			if(Input.GetKeyDown(KeyCode.M) && swordAttack == false)
			{
				currentAngle = transform.eulerAngles.z + 45;
				Debug.Log(transform.eulerAngles.z);
				Debug.Log(currentAngle);
				transform.Rotate(new Vector3(0,0,-45));
				Debug.Log(transform.eulerAngles.z);
				swordAttack = true;
			}

			if (transform.eulerAngles.z != currentAngle && swordAttack == true)
			{
				transform.Rotate(new Vector3(0, 0, 1));
				//Debug.Log(transform.eulerAngles.z);
				if (transform.eulerAngles.z == currentAngle)
				{
					swordAttack = false;
					//transform.Rotate(new Vector3(0, 0, -45));
					//transform.eulerAngles.z = originalAngle;
				}
			}


		}

		transform.Rotate(Vector3.back, speed);// rotates the sword on the z axis, speed controls the speed of rotation

	}
}
