using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;
	public GameObject contiButton;
	public static DialogueManager self;



	private Queue<string> sentences;

	void Awake()
    {
		self = this;
    }
	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue()
	{
		Debug.Log("Start Dialogue");

		nameText.text = Dialogue.name;

		//sentences.Clear();

		foreach (string sentence in Dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			Debug.Log("EndDialogue");
			return;
		}

		Debug.Log("Funktioniert Eventuell");
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
	
	void EndDialogue()
	{
		Debug.Log("Der Dialogue ist Offiziel Leer");
		dialogueText.text = "Ich bin immer für dich da Drück nur die Knöpfe";
		nameText.text = "Mechaniker";
		contiButton.gameObject.SetActive(false);
	}
	
}