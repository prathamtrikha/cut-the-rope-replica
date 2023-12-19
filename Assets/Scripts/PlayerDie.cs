using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour {

	//trigger wall underneath the level
	//when player falls down this function is triggered
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("weight")) 
		{
			//when player enters the trigger 
			//reload the same level again
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}
