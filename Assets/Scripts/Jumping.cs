using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {

	public bool onGround;

	// Use this for initialization
	void Start () {

	}

	// First, let's see if Chorizo is on the ground
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Ground") {
			onGround = true;
			print ("On the ground.");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
