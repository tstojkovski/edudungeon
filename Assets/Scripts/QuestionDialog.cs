using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionDialog : QuestionDialogBase {

	private QuestionBase.Question currentQuestion;


	public override void SetVisible(bool visible) {
		base.SetVisible(visible);
		if (visible) {
			SetQuestion();
		}
	}

	public void SetQuestion() {

		currentQuestion = QuestionBase.questionBase [Random.Range (0, QuestionBase.questionBase.Length)];
		question.text = currentQuestion.question;

	}

	public void ButtonClicked(bool value) {

		if (currentQuestion.answer == value) {
			Answered();
		} else {
			SetQuestion();
		}

	}

}
