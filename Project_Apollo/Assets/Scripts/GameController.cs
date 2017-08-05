using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	int playerOneScore;
	int playerTwoScore;
	BallController ballController;

	[SerializeField]
	Text scoreText;

	[SerializeField]
	Text ready;

	[SerializeField]
	Text set;

	[SerializeField]
	Text go;

	[SerializeField]
	Image panel;

	[SerializeField]
	Text gameOverText;

	[SerializeField]
	Button playAgain;

	[SerializeField]
	Image playAgainImage;

	[SerializeField]
	Text playAgainText;

	void Start () {
		playerOneScore = 0;
		playerTwoScore = 0;

		ballController = GetComponent<BallController> ();
		ready.enabled = false;
		set.enabled = false;
		go.enabled = false;
		panel.enabled = false;
		gameOverText.enabled = false;
		playAgain.enabled = false;
		playAgainImage.enabled = false;
		playAgainText.enabled = false;
	}

	public int getPlayerScore(int player) {
		if (player == 1)
			return playerOneScore;
		else if (player == 2)
			return playerTwoScore;
		else
			return 5;
	}

	public void increaseScore(int player) {
		if (player == 1)
			playerOneScore++;
		else if (player == 2)
			playerTwoScore++;
	}

	public void updateScoreText() {
		scoreText.text = "?PLAYER'ONE'" + playerOneScore + "''-''" + playerTwoScore + "'PLAYER'TWO/";
	}

	public void gameOver(int player) {
		Start ();
		updateScoreText ();
		ballController.newRound (player);
		panel.enabled = true;
		gameOverText.text = "?PLAYER'" + player + "'WINS/";
		gameOverText.enabled = true;
		playAgain.enabled = true;
		playAgainImage.enabled = true;
		playAgainText.enabled = true;
	}

	public void startNewRound() {
		StartCoroutine (newRoundAnimations ());
	}

	IEnumerator newRoundAnimations() {
		ready.enabled = true;
		yield return new WaitForSecondsRealtime (1);
		ready.enabled = false;
		set.enabled = true;
		yield return new WaitForSecondsRealtime (1);
		set.enabled = false;
		go.enabled = true;
		yield return new WaitForSecondsRealtime (1);
		go.enabled = false;
	}
}
