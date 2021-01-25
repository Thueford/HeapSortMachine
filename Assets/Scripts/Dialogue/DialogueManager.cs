using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;
	public GameObject contiButton;
	public Sprite sprHappy, sprExplain, sprNeutral, sprSceptic, sprAngry;
	public static DialogueManager self;
	private static Image mecha;
	public static Globals.Stage nextStage = Globals.Stage.NONE;

	private Queue<string> sentences;

	void Awake()
    {
		self = this;
    }

	void Start()
	{
		mecha = GetComponent<Image>();
		sentences = new Queue<string>();
	}

	public static void setMecha(string emo)//(Sprite img)
    {
		switch (emo)
        {
			case "explain":
				mecha.sprite = DialogueManager.self.sprExplain;
				break;
			case "positiv":
				mecha.sprite = DialogueManager.self.sprHappy;
				break;
			case "neutral":
				mecha.sprite = DialogueManager.self.sprNeutral;
				break;
			case "sceptic":
				mecha.sprite = DialogueManager.self.sprSceptic;
				break;
			case "angry":
				mecha.sprite = DialogueManager.self.sprAngry;
				break;
			default:
				Debug.Log("Falsche Emotion!");
				break;
		}
		//mecha.sprite = img;
    }

	public void StartDialogue()
	{
		Debug.Log("Start Dialogue");

		//falls hier fehler kommt prüfen ob im dialog manager script die einzelnen objekte zugewiesen sind (reingezogen) zb nameText
		nameText.text = Dialogue.name;

		sentences.Clear();

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
		contiButton.gameObject.SetActive(false);
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.01f);
		}
		contiButton.gameObject.SetActive(true);
	}
	
	void EndDialogue()
	{
		Debug.Log("Der Dialogue ist Offiziel Leer");
		dialogueText.text = "Ich bin immer für dich da Drück nur die Knöpfe";
		nameText.text = "Mechaniker";
		contiButton.gameObject.SetActive(false);
		mecha.sprite = sprNeutral;

		// load next Stage
		if (nextStage != Globals.Stage.NONE) Globals.SetStage(nextStage);
		nextStage = Globals.Stage.NONE;
	}
	
}