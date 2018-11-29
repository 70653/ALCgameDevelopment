using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour {

	public int levelToLoad;

	public void loadLevel()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void exitLevel()
	{
		Application.Quit();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
