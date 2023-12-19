using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeveLSelecter : MonoBehaviour {

	//array of buttons in SelectLevelWindow
	public Button[] button;

	void Awake()
	{
		int unlockedLevel = PlayerPrefs.GetInt ("UnlockedLevel", 1);
		//loop over all buttons and make them non-interactable
		for (int i = 0; i < button.Length; i++) 
		{
			button [i].interactable = false;
		}
		//loop and only make first level button active
		for (int i = 0; i < unlockedLevel; i++) 
		{
			button [i].interactable = true;
		}
	}

	//Load the scene according to the level name and its number
	//number input given at button Onclick function
	public void LevelSelecter(int levelNum)
	{
		string levelname = "Level0" + levelNum;
		SceneManager.LoadScene (levelname);
	}
}
