using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	bool isPlayerOneTurn = true;
	float speedFactor = 900f;
	GameController gameController;

	[SerializeField]
	AudioClip wallHit;

	[SerializeField]
	AudioClip paddleHit;

	[SerializeField]
	AudioClip scored;

	AudioSource audioSource;

	public void Start () {
		speedFactor = 900f;
		gameController = GetComponent<GameController> ();
		audioSource = GetComponent<AudioSource> ();

		if (isPlayerOneTurn) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (1 * speedFactor, 0, 0);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (-1 * speedFactor, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "LeftPaddle") {
			speedFactor += 50f;
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (1, (transform.position.y - collision.transform.position.y) / 75f, 0).normalized * speedFactor;
			playSound (paddleHit);
		} else if (collision.gameObject.name == "RightPaddle") {
			speedFactor += 50f;
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (-1, (transform.position.y - collision.transform.position.y) / 75f, 0).normalized * speedFactor;
			playSound (paddleHit);
		} else if (collision.gameObject.name == "LeftWall") {
			isPlayerOneTurn = true;
			gameController.increaseScore (2);
			gameController.updateScoreText ();
			newRound (2);
			playSound (scored);
			if (gameController.getPlayerScore (2) < 5)
				StartCoroutine (delay ());
			else {
				gameController.gameOver (2);
			}
		} else if (collision.gameObject.name == "RightWall") {
			isPlayerOneTurn = false;
			gameController.increaseScore (1);
			gameController.updateScoreText ();
			newRound (1);
			playSound (scored);
			if (gameController.getPlayerScore (1) < 5)
				StartCoroutine (delay ());
			else {
				gameController.gameOver (1);
			}
		} else {
			playSound (wallHit);
		}
	}

	public void newRound(int player) {
		if (player == 2) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
			GetComponent<Rigidbody2D> ().position = new Vector3 (-400, 0, 0); 
		} else if (player == 1) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
			GetComponent<Rigidbody2D> ().position = new Vector3 (400, 0, 0);
		}
	}

	IEnumerator delay() {
		gameController.startNewRound ();
		yield return new WaitForSecondsRealtime (3);
        Start ();
	}

	void playSound(AudioClip sound) {
		audioSource.clip = sound;
		audioSource.Play ();
	}
}
