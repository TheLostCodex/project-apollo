using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
	[SerializeField]
	bool isPlayerTwo;
	float speedFactor = 750f;
	Rigidbody2D rigidBody2D;

	public void Start() {
		rigidBody2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		if (isPlayerTwo) {
			if (Input.GetKey ("up")) {
				moveUp ();
			} else if (Input.GetKey ("down")) {
				moveDown ();
			} else {
				stopMoving ();
			}
		} else {
			if (Input.GetKey ("w")) {
				moveUp ();
			} else if (Input.GetKey ("s")) {
				moveDown ();
			} else {
				stopMoving ();
			}
		}
	}

	void moveUp() {
		rigidBody2D.velocity = new Vector2 (0, 1 * speedFactor);
	}

	void moveDown() {
		rigidBody2D.velocity = new Vector2 (0, -1 * speedFactor);
	}

	void stopMoving() {
		rigidBody2D.velocity = new Vector2 (0, 0);
	}
}
