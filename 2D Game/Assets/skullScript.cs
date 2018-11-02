using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullScript : MonoBehaviour {

	public Rigidbody2D skull;
	public CharacterMove player;
	public static bool playerDied;
	public bool skullShown;

	// Use this for initialization
	void Start () {
		playerDied = false;
		skull.GetComponent<Renderer>().enabled = false;
		skullShown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerDied == true && skullShown == false)
		{
			skull.GetComponent<Renderer>().enabled = true;
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, -1);
			skullShown = true;
		}
		if (playerDied == false)
		{
			skullShown = false;
			skull.GetComponent<Renderer>().enabled = false;
		}
	}
}
