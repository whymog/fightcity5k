using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Vector2 playerVelocity;

	// Use this for initialization
	void Start () {
		playerVelocity = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		playerVelocity = new Vector2 (0, 0);
		if (Input.GetKeyDown ("space")) {
//			print ("space key was pressed");
			playerVelocity.y = 4.0f;
			GetComponent<Rigidbody2D> ().velocity += new Vector2(0, playerVelocity.y);
		}

		if (Input.GetKey ("left")) {
//			print ("left arrow was pressed");
			playerVelocity.x = -0.05f;
		} else if (Input.GetKey ("right")) {
//			print ("right arrow was pressed");
			playerVelocity.x = 0.05f;
		}

		transform.position += new Vector3 (playerVelocity.x , 0, 0);

	}
}
