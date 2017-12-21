using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	// Koga nekoe telo ke stapne vrz trigger kolajderot.
	void OnTriggerEnter2D(Collider2D other) {
		// Racuname koe e sledno nivo.
		int nextLevel = SceneManager.GetActiveScene ().buildIndex + 1;
		// Ako sme na posledno nivo premini na prvo.
		if (nextLevel >= SceneManager.sceneCountInBuildSettings) {
			nextLevel = 0;
		}

		// Se vcituva novoto nivo.
		SceneManager.LoadScene (nextLevel);
	}

}
