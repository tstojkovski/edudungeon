using UnityEngine;
using System.Collections;

public class NPCQuestionAnswer : MonoBehaviour {

	private AnswerDialog answer;

	void Start() {
		
		answer = GetComponentInChildren<AnswerDialog> ();
		answer.SetVisible (false);
		
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			answer.SetVisible(true);
		}
		
	}
	
	void OnCollisionExit2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			answer.SetVisible(false);
		}
		
	}


}
