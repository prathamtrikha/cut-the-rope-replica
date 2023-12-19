using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starPoints : MonoBehaviour {

	//star collect SoundFX components
	public AudioSource starSoundSource;
	public AudioClip starSoundClip;

	//when weight collides with star
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.CompareTag ("weight")) 
		{
			//when is star is collected
			//play the sound and destroy the gameObject star
			starSoundSource.PlayOneShot (starSoundClip);
			Destroy (this.gameObject);
		}	
	}
}
