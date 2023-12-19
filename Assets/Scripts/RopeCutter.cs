using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutter : MonoBehaviour {

	//audio components for rope cutting sound
	public AudioSource cutAudioSource;
	public AudioClip cutAudioClip;

	void Start(){
		//making ScreenOrientation as landscape
		Screen.orientation = ScreenOrientation.Landscape;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) 
		{
			//making a raycast2D 
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider != null) 
			{
				if (hit.collider.tag == "Link") 
				{
					//play the audio and destroy the link
					cutAudioSource.PlayOneShot (cutAudioClip);
					Destroy (hit.collider.gameObject);
				}
			}
		}
	}
}
