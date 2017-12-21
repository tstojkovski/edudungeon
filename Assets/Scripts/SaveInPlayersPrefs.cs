using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaveInPlayersPrefs : MonoBehaviour {

	// Input pole od ko sto ke go citame imeto
	public InputField text;

	// Na start vcituvame Name od playerprefs. Dokolku nema ime pisuvame Enter name.
	void Start () {
		text.text = PlayerPrefs.GetString("Name", "Enter name");
	}

	// Funkcija koja sto go socuvuva momentalnoto ime.
	public void SaveName() {
		PlayerPrefs.SetString("Name", text.text);
		PlayerPrefs.SetInt ("Score", 0);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

}
