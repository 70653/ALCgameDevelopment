using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour {

	public int levelToLoad = 1;// level 1 is the first level
	
	public static string choice = "none";

	public GameObject playerCube;

	public void loadLevel()
	{
		SceneManager.LoadScene(levelToLoad);
		//varGameObject.GetComponent(scriptname).enabled = true;
	}

	public void exitLevel()
	{
		Application.Quit();
	}

	public void chooseBlock()
	{
		choice = "block";
		SceneManager.LoadScene(levelToLoad);
	}

	public void chooseNormal()
	{
		choice = "new";
		SceneManager.LoadScene(levelToLoad);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
