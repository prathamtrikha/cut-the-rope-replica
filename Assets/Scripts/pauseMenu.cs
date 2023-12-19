using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {

	public GameObject pauseMenuObject;

	bool isPaused;

	//reference to RopeCutterScript
	public RopeCutter ropeCutterScript;

	//retry and pauseButton refrence
	public Button pauseButtonObject;
	public Button retryButtonObject;

	void Start()
	{
		pauseMenuObject.SetActive (false);
	}

	void checkPauseMenu()
	{
		if (isPaused == true) {
			ResumeGame ();
		}
		if (isPaused == false) 
		{
			PauseGame ();
		}
	}

	public void ResumeGame()
	{	
		//when game is resume make pauseMenu disappear
		pauseMenuObject.SetActive (false);
		//when game is resumed enable ropeCutting
		ropeCutterScript.enabled = true;

		//enable both the buttons
		pauseButtonObject.enabled = true;
		retryButtonObject.enabled = true;

		isPaused = false;
	}
	void PauseGame()
	{	
		//when game is paused make pauseMenu appear
		pauseMenuObject.SetActive (true);
		//when game is paused disable ropeCutting
		ropeCutterScript.enabled = false;

		//disable both the buttons
		pauseButtonObject.enabled = false;
		retryButtonObject.enabled = false;

		isPaused = true;
	}
	
	public void PauseButton()
	{
		checkPauseMenu ();
	}
}
