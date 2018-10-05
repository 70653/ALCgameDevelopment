using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

	public static int score;

	Text scoreText;

	// Use this for initialization
	void Start ()
	{
		scoreText = GetComponent<Text>();
		scoreText.text = " 0";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (score < 0)
		{
			score = 0;
		}
		scoreText.text = " " + score;
	}
	public static void addPoints(int pointsToAdd)
	{
		score += pointsToAdd;
	}
}
