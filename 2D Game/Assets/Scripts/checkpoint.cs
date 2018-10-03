using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "player")
		{
			CharacterMove.spawn = transform.position;
			CharacterMove.reachCheckpoint = 1;
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
