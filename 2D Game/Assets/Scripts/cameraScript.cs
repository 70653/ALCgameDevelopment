using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public CharacterMove player;

	public static bool isFollowing = true;

	// camera position offset
	public float xOffset = 1;
	public float yOffset = 1;

	public Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
		//player = FindObjectOfType<CharacterMove>();

		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFollowing == true)
		{
			//transform.position = playerBody.transform.position;
			transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, -10);
		}
		
	}
}
