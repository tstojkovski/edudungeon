using UnityEngine;
using System.Collections;

public class NPCOpenDoor : MonoBehaviour {

	public GameObject doorObject;

	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			if (doorObject != null) {
				Door door = doorObject.GetComponent<Door>();
				if (door != null) {
					door.Unlock();
				}
			}
		}
		
	}

}
