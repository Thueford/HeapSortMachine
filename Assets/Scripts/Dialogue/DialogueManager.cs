using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager self;
	public static Globals.Stage nextStage = Globals.Stage.NONE;

	public Text nameText, dialogueText;
	public GameObject contiButton, darkener;
	public Sprite sprHappy, sprExplain, sprNeutral, sprSceptic, sprAngry;

	private Queue<string> sentences;
	private static Image mecha;
	private Fade darken;

	void Awake()
    {
		self = this;
    }

	void Start()
	{
		mecha = GetComponent<Image>();
		darken = darkener.GetComponent<Fade>();
		sentences = new Queue<string>();
	}

	public static void setMecha(string emo)//(Sprite img)
    {
		switch (emo)
        {
			case "explain": mecha.sprite = self.sprExplain; break;
			case "positiv": mecha.sprite = self.sprHappy;   break;
			case "neutral": mecha.sprite = self.sprNeutral; break;
			case "sceptic": mecha.sprite = self.sprSceptic; break;
			case "angry":   mecha.sprite = self.sprAngry;   break;
			default:        Debug.Log("Falsche Emotion!");  break;
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
			sentences.Enqueue(sentence);

		darken.DarkenOut(null);

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(!skipDialog)
		{
			skipDialog = true;
			return;
		}

		if (sentences.Count == 0)
		{
			EndDialogue();
			Debug.Log("EndDialogue");
			contiButton.gameObject.SetActive(false);
			return;
		}
		
		contiButton.gameObject.SetActive(true);
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	private volatile bool skipDialog = true;
	IEnumerator TypeSentence(string sentence)
	{
		//contiButton.gameObject.SetActive(false);
		dialogueText.text = "";
		skipDialog = false;
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			if(!skipDialog) yield return new WaitForSeconds(0.015f);
		}
		skipDialog = true;
		//contiButton.gameObject.SetActive(true);
	}
	
	void EndDialogue()
	{
		Debug.Log("Der Dialogue ist Offiziel Leer");

		if(Globals.stage == Globals.Stage.END)
        {
			dialogueText.text = "Vielen Dank für's Spielen.";
        } else
        {
			dialogueText.text = "Ich bin immer für dich da Drück nur die Knöpfe";
        }
		
		nameText.text = "Mechaniker";
		contiButton.SetActive(false);
		mecha.sprite = sprNeutral;
		darken.DarkenIn(null);

		// load next Stage
		if (nextStage != Globals.Stage.NONE) Globals.SetStage(nextStage);
		nextStage = Globals.Stage.NONE;
	}
	
}