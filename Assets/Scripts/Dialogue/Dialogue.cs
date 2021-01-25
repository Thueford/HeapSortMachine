using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public  class Dialogue : MonoBehaviour
{
    public static Random rnd = new UnityEngine.Random();
    public static string name;
    [TextArea(3, 10)]
    public static List<string> sentences = new List<string>();
     
    public static string namenew;

    public static Json_Test.Dialogwrapper json = Json_Test.Load();

    public static void nameSetter(string k)
    {
        namenew = k;
        name = namenew;
        Debug.Log(name);
    }

    public static void sentenceSetter(string[] s)
    {
        sentences.Clear();
        sentences.AddRange(s);
        Debug.Log("Ich hab die Texte eingefügt");
    }

    public static void addSentences(string[] s)
    {
        sentences.AddRange(s);
    }

    // Hilfe Zone/////////////////////////////////////////////////////////
    public static void Hilfe_1()
    {
        sentences.Clear();

        nameSetter("Hilfe 1:");
        string[] sentence = json.level_hints.stage_1.text;
        sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
        
        // DialogueManager.self.sprExplain.gameObject.SetActive(true);
    }
 
    public static void Hilfe_2()
    {
        sentences.Clear();
        nameSetter("Hilfe 2:");
        string[] sentence = json.level_hints.stage_2.text;
        sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
        // DialogueManager.self.sprExplain.gameObject.SetActive(true);
    }

    public static void Hilfe_3()
    {
        sentences.Clear();
        nameSetter("Hilfe 3:");
        string[] sentence = json.level_hints.stage_3.text;
        sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
        // DialogueManager.self.sprExplain.gameObject.SetActive(true);
    }

    public static void Hilfe_4()
    {
        sentences.Clear();
        nameSetter("Hilfe 4:");
        string[] sentence = json.level_hints.stage_4.text;
        sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
        // DialogueManager.self.sprExplain.gameObject.SetActive(true);
    }

    //Test Zone     /////////////////////////////////////////////////////////
    public static void Test_1(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            DialogueManager.setMecha(DialogueManager.self.sprHappy);
            DialogueManager.nextStage = Globals.Stage.STAGE_2;

            nameSetter("Richtig!");
            string[] sentence_random = json.random_success.text;
            string[] uebergang = json.level_complete.stage_1.text;
            int sIndex = Random.Range(0, sentence_random.Length-1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] {sent_rand};
            sentenceSetter(sentence);
            addSentences(uebergang);
        }
        else
        {
            DialogueManager.setMecha(DialogueManager.self.sprAngry);
            nameSetter("Falsch!");
            string[] sentence_random = json.random_mistake.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { sent_rand, "Wenn du nicht weiter weißt hilft vielleicht ein Tipp!" };
            sentenceSetter(sentence);
        }

        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Test_2(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            DialogueManager.setMecha(DialogueManager.self.sprHappy);
            DialogueManager.nextStage = Globals.Stage.STAGE_3;

            nameSetter("Richtig!");     
            string[] sentence_random = json.random_success.text;
            string[] uebergang = json.level_complete.stage_2.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] {sent_rand};
            sentenceSetter(sentence);
            addSentences(uebergang);
        }
        else
        {
            DialogueManager.setMecha(DialogueManager.self.sprAngry);
            nameSetter("Falsch!");
            string[] sentence_random = json.random_mistake.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { sent_rand, "Wenn du nicht weiter weißt hilft vielleicht ein Tipp!" };
            sentenceSetter(sentence);
        }
        
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Test_3(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            DialogueManager.setMecha(DialogueManager.self.sprHappy);
            DialogueManager.nextStage = Globals.Stage.STAGE_4;

            nameSetter("Richtig!");
            string[] sentence_random = json.random_success.text;
            string[] uebergang = json.level_complete.stage_3.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] {sent_rand, "Als nächstes behandeln wir Stage 4" };
            // DialogueManager.self.sprHappy.gameObject.SetActive(true);
        }
        else
        {
            DialogueManager.setMecha(DialogueManager.self.sprAngry);
            nameSetter("Falsch!");
            string[] sentence_random = json.random_mistake.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { sent_rand, "Wenn du nicht weiter weißt hilft vielleicht ein Tipp!" }; ;
            // DialogueManager.self.sprAngry.gameObject.SetActive(true);
        }
        sentenceSetter(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Test_4(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            DialogueManager.setMecha(DialogueManager.self.sprHappy);
            nameSetter("Richtig!");
            DialogueManager.nextStage = Globals.Stage.END;
            string[] sentence_random = json.random_success.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { json.level_complete.stage_4.text[0], sent_rand, "Super du hast alle Stages gemeistert." };
            // DialogueManager.self.sprHappy.gameObject.SetActive(true);
        }
        else
        {
            DialogueManager.setMecha(DialogueManager.self.sprAngry);
            nameSetter("Falsch!");
            string[] sentence_random = json.random_mistake.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { sent_rand, "Wenn du nicht weiter weißt hilft vielleicht ein Tipp!" };
            // DialogueManager.self.sprAngry.gameObject.SetActive(true);
        }
        sentenceSetter(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }


    // AutoZone vroom vroom/////////////////////////////////////////////////////////

    public static void Auto_1()
    {
        sentences.Clear();
        string[] input = {"Stage 1 läuft nun automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
        // DialogueManager.self.sprSceptic.gameObject.SetActive(true);
    }
    public static void Auto_2()
    {
        sentences.Clear();
        string[] input = { "Stage 2 läuft nun automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
        // DialogueManager.self.sprSceptic.gameObject.SetActive(true);
    }
    public static void Auto_3()
    {
        sentences.Clear();
        string[] input = { "Stage 3 läuft jetzt automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
        // DialogueManager.self.sprSceptic.gameObject.SetActive(true);
    }
    public static void Auto_4()
    {
        sentences.Clear();
        string[] input = { "Stage 4 läuft jetzt automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
        // DialogueManager.self.sprSceptic.gameObject.SetActive(true);
    }

    /// Übergangszone

}