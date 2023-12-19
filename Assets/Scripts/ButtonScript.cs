using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	//button to retry the scene
	public void RetryButton()
	{
		//Get the current name of the scene which is active
		//load the current scene again
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		if (Time.timeScale != 1f) {
			Time.timeScale = 1f;
		}
	}

	//move to StartMenu
	public void MainMenu()
	{
		SceneManager.LoadScene ("StartMenu");
	}
}
