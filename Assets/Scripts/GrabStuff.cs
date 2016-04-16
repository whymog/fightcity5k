using UnityEngine;
using System.Collections;

public class GrabStuff : MonoBehaviour {

	GameObject objToGrab = null;
	public bool grabbed = false;

	GameObject chorizo;
	PlayerMovement playerMovement;

	GameObject jumper;
	Jumping jumpScript;

	// Use this for initialization
	void Start () {
		chorizo = GameObject.Find ("Chorizo");
		playerMovement = chorizo.GetComponent<PlayerMovement> ();

		jumper = GameObject.Find("Jumper");
		jumpScript = jumper.GetComponent<Jumping>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown ("x")) {
			if (objToGrab != null && !grabbed) {
//				print ("GRABBED " + objToGrab);
				grabbed = true;
				objToGrab.GetComponent<Rigidbody2D> ().gravityScale = 0f;
				objToGrab.GetComponent<BoxCollider2D> ().isTrigger = true;
			} else if (grabbed) {
//				print ("DROPPING " + objToGrab);
				Throw ("forward");
			} else {
				print ("Nothing to grab.");
			}
		} else if (Input.GetKeyDown ("z")) {
			if (grabbed && !jumpScript.onGround) {
				print ("Throwing down");
				print (jumpScript.onGround);
				playerMovement.playerVelocity.y += 12.0f;
				Throw ("down");
			}
		}

		if (grabbed)
			objToGrab.transform.position = this.transform.position;
	}

	void Throw(string direction) {
		if (direction == "down") {
//			objToGrab.GetComponent<BoxCollider2D> ().isTrigger = false;
			objToGrab.GetComponent<Transform> ().Translate(new Vector2 (-0.3f, -0.5f));
			objToGrab.GetComponent<Rigidbody2D> ().AddForce(new Vector2(0f, -200f));
			objToGrab.GetComponent<Rigidbody2D> ().gravityScale = 1f;
			objToGrab.GetComponent<BoxCollider2D> ().isTrigger = false;

		}
		else if (direction == "forward") {
//			objToGrab.GetComponent<BoxCollider2D> ().isTrigger = false;
			objToGrab.GetComponent<Rigidbody2D> ().AddForce(new Vector2(500f, 0f));
			objToGrab.GetComponent<Rigidbody2D> ().gravityScale = 1f;
		}
		grabbed = false;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Grabbable" && !grabbed) {
//			print("grabbable object within reach");
			objToGrab = coll.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Grabbable" && !grabbed) {
//			print ("grabbable object lost");
			objToGrab.GetComponent<BoxCollider2D> ().isTrigger = false;
			objToGrab = null;
		}
	}
}
