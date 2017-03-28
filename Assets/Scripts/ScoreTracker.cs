using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

	public int playerScore;
	Text score;

	// Use this for initialization
	void Awake () {
		score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + playerScore;
	}

	public void incScore(int score){
		playerScore += score;
	}
}
