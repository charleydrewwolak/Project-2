using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour {

	int playerScore = 0;

	// Update is called once per frame
	void Update () {
		//playerScore += Time.deltaTime;
	}

	public void IncreaseScore(int amount){
		playerScore += amount;
	}

	void OnDisable(){
		PlayerPrefs.SetInt("Score", playerScore);
	}

	void OnGUI(){
		GUI.Label(new Rect(10, 10, 100, 30), "Score: " + playerScore);
	}
}
