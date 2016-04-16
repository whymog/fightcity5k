using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector2 playerVelocity;
	GameObject jumper;
	Jumping jumpScript;
	bool jumpInProgress;

	// Use this for initialization
	void Start () {
		jumper = GameObject.Find("Jumper");
		jumpScript = jumper.GetComponent<Jumping>();
		jumpInProgress = false;

		playerVelocity = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerVelocity = new Vector2 (0, 0);
		if (Input.GetKeyDown ("z") && jumpScript.onGround && !jumpInProgress) {
//			print ("jump key was pressed");
			playerVelocity.y = 4.0f;
			GetComponent<Rigidbody2D> ().velocity += new Vector2(0, playerVelocity.y);
			jumpInProgress = true;
			StartCoroutine(BeginJump(0.1F));
			print ("Jumping");
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

	IEnumerator BeginJump(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		jumpScript.onGround = false;
		jumpInProgress = false;
		print("Jump succeeded " + Time.time);
	}
}
