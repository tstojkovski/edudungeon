using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		int highestScore = PlayerPrefs.GetInt ("HighestScore", 0);
		if (highestScore > 0) {
			string name = PlayerPrefs.GetString ("HighestScoreName");
			int score = PlayerPrefs.GetInt ("HighestScore");

			text.text = "Highest score by " + name + ": " + score;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
