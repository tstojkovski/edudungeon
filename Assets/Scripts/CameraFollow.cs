using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject objectToFollow;
	
	void FixedUpdate () {
	
		if (objectToFollow != null) {
			Vector3 newPositon = new Vector3(objectToFollow.transform.position.x, 
			                                 objectToFollow.transform.position.y, transform.position.z);
			transform.position = newPositon;
		}

	}

}
