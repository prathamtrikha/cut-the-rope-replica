using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

	//win SoundFX components
	public AudioSource winSoundSource;
	public AudioClip winSoundClip;

	//winScene components
	public Animator winSceneAnim;

	//star Objects in winScene components
	public GameObject[] starsInWinScene;
	int starCount;

	//winSceneButtons
	public GameObject WinSceneButtons;

	//WinTextComponents
	public GameObject goodText;
	public GameObject betterText;
	public GameObject perfectText;

	void Start()
	{
		//get the current number of star active in the scene
		//stars here are the points to be collected in the level
		starCount = GameObject.FindGameObjectsWithTag ("points").Length;
	}

	//when weight enters colldider of the winBox
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("weight")) 
		{
			//win sound is being played
			//coroutine function for appearing of WinScene starts
			winSoundSource.PlayOneShot (winSoundClip);
			StartCoroutine (WinSceneAppear ());
			//to calculate how many stars calculated
			//while playing the level
			StarAchieved ();
			//Unlocking the next level since current is cleared
			UnlockNextLevel ();
		}
	}

	//making a win coroutine
	IEnumerator WinSceneAppear()
	{
		yield return new WaitForSeconds (1f);
		winSceneAnim.SetTrigger ("win");

		//buttons are retry and move to nextLevel button
		yield return new WaitForSeconds (0.5f);
		WinSceneButtons.SetActive (true);
	}

	//when level is done call this function
	void StarAchieved()
	{
		//calculate how star object left in the scene with tag points
		int starLeft = GameObject.FindGameObjectsWithTag ("points").Length;
		//calculate how many actually collected
		int starCollected = starCount - starLeft;

		//calculating the percentage
		//one star collected means 33 percent
		//two star means 66 percent and so on
		//total there are only 3 star points in the scene
		float percentage = float.Parse(starCollected.ToString()) / float.Parse(starCount.ToString()) * 100f;
		if(percentage >= 33 && percentage < 66){
			//activate only one star
			starsInWinScene[0].SetActive(true);
			goodText.SetActive (true);
		}else if(percentage >= 66 && percentage < 70){
			//activate 2 stars only 
			starsInWinScene[0].SetActive(true);
			starsInWinScene[1].SetActive(true);
			betterText.SetActive (true);
		}else{
			//activate all the 3 stars
			starsInWinScene[0].SetActive(true);
			starsInWinScene[1].SetActive(true);
			starsInWinScene[2].SetActive(true);
			perfectText.SetActive (true);
		}
	}

	//WinSceneButtonFunctions
	public void RetryLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void NextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	//UnlockNext Level
	void UnlockNextLevel()
	{
		if (SceneManager.GetActiveScene ().buildIndex >= PlayerPrefs.GetInt ("ReachedIndex")) 
		{
			PlayerPrefs.SetInt ("ReachedIndex", SceneManager.GetActiveScene ().buildIndex + 1);
			PlayerPrefs.SetInt ("UnlockedLevel", PlayerPrefs.GetInt ("UnlockedLevel", 1) + 1);
			PlayerPrefs.Save ();
		}
	}
}
