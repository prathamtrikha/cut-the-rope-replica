using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weight : MonoBehaviour {
	void Awake(){
		Screen.orientation = ScreenOrientation.Landscape;
	}

	public float distanceFromEndLink;

	//to get the rigidBody which isto be connected to the weight
	public void GenerateRopeEnd(Rigidbody2D endRB)
	{
		HingeJoint2D weightJoint = gameObject.AddComponent<HingeJoint2D>();
		weightJoint.connectedBody = endRB;
		weightJoint.autoConfigureConnectedAnchor = false;
		weightJoint.anchor = Vector2.zero;
		weightJoint.connectedAnchor = new Vector2 (0f, -distanceFromEndLink);
	}
}
