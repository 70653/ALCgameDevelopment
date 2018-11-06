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
			Debug.Log("Player Enters Jump Pad");
			superJump();
		}

	}// onTrigger2D ends

	public void superJump()
	{
		StartCoroutine ("superJumpCO");
	}// respawn player ends

	public IEnumerator superJumpCO()
	{
		yield return new WaitForSeconds (jumpDelay);
		onJumpPad = false;
	}// respawn player co ends

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
