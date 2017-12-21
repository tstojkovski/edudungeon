using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerDialog : MonoBehaviour {

	public GameObject question;

	private MultiQuestionXMLBase questionBase;
	private RectTransform rect;
	private float height;

	private Quaternion fixedRotation;
	
	protected Canvas canvas;
	protected Text answer;
	
	
	void Awake () {
		
		fixedRotation = transform.rotation;
		answer = GetComponentInChildren<Text> ();
		canvas = GetComponent<Canvas> ();
		
	}

	void Start () {

		questionBase = GameObject.FindWithTag("QuestionBase").GetComponent<MultiQuestionXMLBase> ();
		
		rect = GetComponent<RectTransform> ();
		height = rect.sizeDelta.y;


		for (int i = 0; i < questionBase.Questions.Count; i++) {
			GameObject tmpAnswer = (GameObject) Instantiate(question);
			tmpAnswer.transform.SetParent(transform, false);
			Text tmpText = tmpAnswer.GetComponentInChildren<Text>();
			tmpText.text = questionBase.Questions[i].question;
			string ans = "";
			for (int j = 0; j < questionBase.Questions[i].answers.Count; j++) {
				if (questionBase.Questions[i].answers[j].correct) {
					ans = questionBase.Questions[i].answers[j].answer;
					break;
				}
			}
			tmpAnswer.GetComponent<Button> ().onClick.AddListener(
				() => ButtonClicked(ans));
			RectTransform tmpRect = tmpAnswer.GetComponent<RectTransform> ();
			tmpRect.anchoredPosition = new Vector2(tmpRect.anchoredPosition.x, tmpRect.anchoredPosition.y - (tmpRect.rect.height * i));
		}
		height += (question.GetComponent<RectTransform>().rect.height * (questionBase.Questions.Count - 1));
		rect.sizeDelta = new Vector2(rect.sizeDelta.x, height);
		
	}
	
	void LateUpdate() {
		
		transform.rotation = fixedRotation;
		
	}
	
	public void SetVisible(bool visible) {
		
		canvas.enabled = visible;
		
	}
	

	public void ButtonClicked(string value) {

		answer.text = value;

	}
}
