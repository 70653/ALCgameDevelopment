using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour {

	public static bool gotSword = false;
	public Rigidbody2D playerBody;
	public GameObject playerObject;
	public int extraX = 10;

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
			transform.position = playerObject.transform.position;
			if (CharacterMove.direction > 0)
			{
				
			}
			else
			{

			}
		}
	}
}
