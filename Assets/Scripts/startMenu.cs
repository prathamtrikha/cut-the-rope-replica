using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenu : MonoBehaviour {

	//button click Audio components
	public AudioSource buttonClickSource;
	public AudioClip buttonClickSound;

	//before everything loads make Screen orientation as landscape
	void Awake () 
	{
		//PlayerPrefs.DeleteAll ();
		Screen.orientation = ScreenOrientation.Landscape;
	}

	//Play sound when button is clicked
	public void ButtonClick()
	{
		buttonClickSource.PlayOneShot (buttonClickSound);
	}
		
	//for quitting the game
	public void QuitGame()
	{
		Application.Quit ();
	}

}

