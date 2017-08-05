using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

	public void loadGame() {
		SceneManager.LoadScene ("Game");
	}

	public void goToSplash() {
		SceneManager.LoadScene ("SplashScreen");
	}
}
