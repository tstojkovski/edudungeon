using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {


	private Animator animator;


	void Start() {

		animator = GetComponent<Animator> ();

	}

	public void Unlock () {

		animator.SetBool("Locked", false);

	}
}
