using UnityEngine;
using System.Collections;

public class GrabStuff : MonoBehaviour {

	GameObject objToGrab = null;
	public bool grabbed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("down")) {
			if (objToGrab != null && !grabbed) {
				print ("GRABBED " + objToGrab);
				grabbed = true;
				objToGrab.GetComponent<BoxCollider2D> ().isTrigger = true;
			} else if (grabbed) {
				print ("DROPPING " + objToGrab);
				objToGrab.GetComponent<BoxCollider2D> ().isTrigger = false;
				grabbed = false;
			} else {
				print ("Nothing to grab.");
			}
		}

		if (grabbed)
			objToGrab.transform.position = this.transform.position;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Grabbable" && !grabbed) {
			print("grabbable object within reach");
			objToGrab = coll.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Grabbable" && !grabbed) {
			print ("grabbable object lost");
			objToGrab = null;
		}
	}
}
