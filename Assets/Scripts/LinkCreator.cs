using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkCreator : MonoBehaviour {

	//object holding the rope
	public GameObject hook;

	//Link prefab gameobject
	public GameObject linkPrefab;

	//how many links needs in one rope
	public int linkAmount = 7;

	//ball gameObject
	public weight weightClass;

	void Start () 
	{
		//when scene is loaded generate rope attached to the ball
		GeneratorLinks ();
	}

	//function to generate rope
	void GeneratorLinks()
	{
		Rigidbody2D hookRigid = hook.GetComponent<Rigidbody2D> ();
		Rigidbody2D prevRigid = hookRigid;
		for (int i = 0; i < linkAmount; i++) 
		{
			GameObject linkObject = Instantiate (linkPrefab, transform);
			HingeJoint2D linkJoint = linkObject.GetComponent<HingeJoint2D> ();
			linkJoint.connectedBody = prevRigid;
			//in this case all the links satisfy this condition
			//and are connected to the previous rigidBody
			if (i < linkAmount - 1) {
				prevRigid = linkObject.GetComponent<Rigidbody2D> ();
			} else {
				//for the last link is connected to the Weight
				//function is called from the Weight class
				weightClass.GenerateRopeEnd (linkObject.GetComponent<Rigidbody2D> ());
			}
		}
	}
}
