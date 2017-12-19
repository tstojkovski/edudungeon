using UnityEngine;
using System.Collections;

public class NPCTalk : MonoBehaviour {

	private NPCMovement movement;
	
	void Start () {

		movement = GetComponent<NPCMovement> ();

	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			movement.pause = true;
		}
		
	}
	
	void OnCollisionExit2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			movement.pause = false;
		}
		
	}
}
