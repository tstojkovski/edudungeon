using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {

	public Transform[] npcMovingPath;
	public float speed;
	public bool pause;

	private Animator animator;
	private Transform currentTarget;
	private int nextTargetIndex;

	void Start () {

		animator = GetComponent<Animator> ();

		nextTargetIndex = 0;
		nextTarget();
	
	}

	void FixedUpdate () {

		if (pause || currentTarget == null || transform.position == currentTarget.position) {
			animator.SetBool("Walking", false);
			return;
		} else {
			animator.SetBool("Walking", true);
		}

		float step = Time.deltaTime * speed;
		Vector3 newPosition = Vector3.MoveTowards(transform.position, currentTarget.position, step);

		Vector3 direction = newPosition - transform.position;
		direction.Normalize ();

		transform.position = newPosition;

		transform.eulerAngles = new Vector3 (0, 0, -Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI);

		if (transform.position == currentTarget.position) {
			nextTarget();
		}
		
	}

	private void nextTarget() {

		if (npcMovingPath.Length == 0) {
			currentTarget = null;
		} else {
			currentTarget = npcMovingPath[nextTargetIndex];
		}

		nextTargetIndex++;
		if (nextTargetIndex >= npcMovingPath.Length) {
			nextTargetIndex = 0;
		}

	}
}
