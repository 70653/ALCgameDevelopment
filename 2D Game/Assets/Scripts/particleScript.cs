﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticleSystem.isPlaying == false)
		{
			Destroy(gameObject);
		}
	}
}
