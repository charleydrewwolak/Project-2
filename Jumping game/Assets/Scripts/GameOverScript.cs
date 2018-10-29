using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	int score = 0;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt("Score");
	}

	void OnGUI(){
		GUI.Label(new Rect(Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");
		GUI.Label(new Rect(Screen.width / 2 - 40, 90, 80, 30), "Score: " + score);
		if (GUI.Button(new Rect(Screen.width / 2 - 30, 130, 60, 30), "Retry?")){
			SceneManager.LoadScene(0);
		}
	}
}
