using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReadingToggle : MonoBehaviour {

	// Toggle objekt za koj ke proveruvame dali e selektiran
	public Toggle toggle;
	// Text objekt kade ke ja pisuvame sostojbata na togglot
	public Text text;

	// Se izvrsuva sekoj frame
	void Update () {
		// Ako toggl e on
		if (toggle.isOn) {
			text.text = "активно";
		} else {
			text.text = "не акативно";
		}
	}

}
