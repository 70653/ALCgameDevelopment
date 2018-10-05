using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {

	public GameObject currentCheckPoint;
	private Rigidbody2D pc;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public int pointPenaltyOnDeath = 50;
	
	private float gravityStore;

	// Use this for initialization
	void Start () 
	{
		pc = FindObjectOfType<Rigidbody2D>();
	}
	/* 
	public void respawnPlayer()
	{
		StartCoroutine ("respawnPlayerCo");
	}

	public IEnumerator respawnPlayerCo()
	{
		//generate death particle
		Instantiate (deathParticle, pc.transform.position, pc.transform.rotation);
		//hide pc
		//pc.enabled = false;
		pc.GetComponent<Renderer>().enabled = false;
		//gravity reset
		gravityStore = pc.GetComponent<Rigidbody2D>().gravityScale;
		pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
		pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//point penalty
		scoreManager.addPoints(-pointPenaltyOnDeath);
		//debug message
		Debug.Log("pc respawn");
		//respawn delay
		yield return new WaitForSeconds (respawnDelay);
		//gravity restore
		pc.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
		//match pcs transform position
		pc.transform.position = currentCheckPoint.transform.position;
		//show pc
		//pc.enabled = true;
		pc.GetComponent<Renderer>().enabled = true;
		//spawn pc
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}
*/
	// Update is called once per frame
	void Update () 
	{
		
	}
}
