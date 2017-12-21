using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class MultiQuestionXMLBase : MonoBehaviour 
{

	// Pole vo editorot vo koe ke se dodava XML datotekata
	public TextAsset textXml;
	// Baza na prasanja koja drugite skripti treba da ja citaat
	public List<Question> Questions;

	// Pretstavuvanje na XML dokument
	private XmlDocument xmlDoc;
	
	// Struktura na prasanje 
	public struct Question
	{
		public string question;
		public List<Answer> answers;
	}

	// Struktura na odgovor
	public struct Answer
	{
		public string answer;
		public bool correct;
	}

	// Na pocetok povikuvame citanje na XML.
	void Awake ()
	{
		// Kreirame prazna baza prasanja
		Questions = new List<Question>();
		// Loadirame XML file
		loadXMLFromAssest();
		if (xmlDoc != null) {
			// Citame (parsirame) XML file
			readXml();
		}
	}

	// Loadiranje XML.
	private void loadXMLFromAssest()
	{
		xmlDoc = new XmlDocument();
		if(textXml != null) {
			xmlDoc.LoadXml(textXml.text);
		}
	}

	// Citanje XML
	private void readXml()
	{
		// Go pominuvame sekoj Question node.
		foreach(XmlElement node in xmlDoc.SelectNodes("Questions//Question"))
		{
			// Za sekoj question node kreirame Question objekt.
			Question tempQuestion = new Question();
			// Go zemame prasanjeto.
			tempQuestion.question = node.SelectSingleNode("text").InnerText;
			// Kreirame lista za odgovori.
			tempQuestion.answers = new List<Answer>();
			// Go pominuvame sekoj odgovor.
			foreach(XmlElement answer in node.SelectNodes("Answers//Answer")) {
				// Za sekoj odgovork kreirame soodveten objekt.
				Answer tempAnswer = new Answer();
				// Go zemame odgovorot.
				tempAnswer.answer = answer.SelectSingleNode("text").InnerText;
				// Zmame dali e e tocen ili ne.
				tempAnswer.correct = bool.Parse(answer.SelectSingleNode("correct").InnerText);
				// Go dodavame odgovorot vo listata odgovori.
				tempQuestion.answers.Add(tempAnswer);
			}
			// Prasanjeto go dodavame vo bazata od prasanja.
			Questions.Add(tempQuestion);
		}
	}

}