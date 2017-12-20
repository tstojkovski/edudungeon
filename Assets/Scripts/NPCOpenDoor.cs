using UnityEngine;
using System.Collections;

public class NPCOpenDoor : MonoBehaviour {

	public GameObject doorObject;

	private QuestionDialogBase question;
	private Door door;

	void Start() {

		question = GetComponentInChildren<QuestionDialogBase> ();
		question.QuestionAnswered += QuestionAnswered;
		if (doorObject != null) {
			door = doorObject.GetComponent<Door> ();
		}
		question.SetVisible (false);

	}

	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player" && door != null && door.IsLocked()) {
			question.SetVisible(true);
		}
		
	}

	void OnCollisionExit2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			question.SetVisible(false);
		}
		
	}

	public void QuestionAnswered() {

		if (door != null && door.IsLocked()) {
			door.Unlock();
			question.SetVisible(false);
		}

	}

	void OnDestroy() {

		if (question != null) {
			question.QuestionAnswered -= QuestionAnswered;
		}

	}

}
