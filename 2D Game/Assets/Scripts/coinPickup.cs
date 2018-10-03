using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour {

	public int pointsToAdd = 100;

	void OnTriggerEnter2D (Collider2D other)
	{
		if ( other.GetComponent<Rigidbody2D>() == null)
		{
			return;
		}
		if (other.name == "player")
		{
		scoreManager.addPoints(pointsToAdd);
		Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
