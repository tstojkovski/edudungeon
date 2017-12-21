using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class QuestionDialogBase : MonoBehaviour {

	private Quaternion fixedRotation;

	protected Canvas canvas;
	protected Text question;
	public delegate void QuestionDialogHandler();
	public event QuestionDialogHandler QuestionAnswered;
	
	
	void Awake () {

		fixedRotation = transform.rotation;
		question = GetComponentInChildren<Text> ();
		canvas = GetComponent<Canvas> ();
		
	}
	
	void LateUpdate() {
		
		transform.rotation = fixedRotation;
		
	}
	
	public virtual void SetVisible(bool visible) {
		
		canvas.enabled = visible;
		
	}

	protected void Answered() {
		if (QuestionAnswered != null) {
			QuestionAnswered();
		}
	}
}
