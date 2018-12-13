using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public Rigidbody2D player;

	public Rigidbody2D newPlayer;

	public static bool isFollowing = true;

	// camera position offset
	public float xOffset = 1;
	public float yOffset = 1;

	// Use this for initialization
	void Start () 
	{
		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFollowing == true)
		{
			if (mainMenuScript.choice == "block")
			{
				transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, -10);
			}
			else if (mainMenuScript.choice == "new")
			{
				transform.position = new Vector3(newPlayer.transform.position.x + xOffset, newPlayer.transform.position.y + yOffset, -10);
			}
		}
		
	}
}
