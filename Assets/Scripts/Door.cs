using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {


	private Animator animator;


	void Start() {

		animator = GetComponent<Animator> ();

	}

	public void Unlock () {
		int score = PlayerPrefs.GetInt ("Score", 0);
		score++;
		PlayerPrefs.SetInt ("Score", score);
		int highestScore = PlayerPrefs.GetInt ("HighestScore", 0);
		if (score >= highestScore) {
			PlayerPrefs.SetString ("HighestScoreName", PlayerPrefs.GetString ("Name", "Unknown"));
			PlayerPrefs.SetInt ("HighestScore", score);
		}

		animator.SetBool("Locked", false);

	}

	public bool IsLocked() {
		return animator.GetBool("Locked");
	}
}
