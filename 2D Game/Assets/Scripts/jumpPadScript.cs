using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPadScript : MonoBehaviour {


	public static bool onJumpPad;
	public float jumpDelay = 1f;


	void OnTriggerEnter2D (Collider2D other) // if the pad is touching something
	{
		if (other.name == "player")
		{
			onJumpPad = true;
		}

	}// onTrigger2D ends

	void OnTriggerExit2D(Collider2D other) // if the player leaves the jump pad
    {
        if (other.name == "player")
		{
			onJumpPad = false;
		}
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
