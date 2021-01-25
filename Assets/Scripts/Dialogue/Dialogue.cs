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
            nameSetter("Richtig!");
            DialogueManager.nextStage = Globals.Stage.STAGE_2;
            string[] sentence_random = json.random_success.text;
            int sIndex = Random.Range(0, sentence_random.Length-1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] {json.level_complete.stage_1.text[0], sent_rand, "Als nächstes behandeln wir Stage 2" };
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

    public static void Test_2(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            DialogueManager.setMecha(DialogueManager.self.sprHappy);
            nameSetter("Richtig!");
            DialogueManager.nextStage = Globals.Stage.STAGE_3;
            string[] sentence_random = json.random_success.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { json.level_complete.stage_2.text[0], sent_rand, "Als nächstes behandeln wir Stage 3" };
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

    public static void Test_3(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            DialogueManager.setMecha(DialogueManager.self.sprHappy);
            nameSetter("Richtig!");
            DialogueManager.nextStage = Globals.Stage.STAGE_4;
            string[] sentence_random = json.random_success.text;
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { json.level_complete.stage_3.text[0], sent_rand, "Als nächstes behandeln wir Stage 4" };
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
    


    // Reset-Zone/////////////////////////////////////////////////////////

    public static void Outro()
    {
        string[] input = {  //"Herzlichen Glückwunsch! Du bist nun in der Lage auch ohne diese Maschine die Kugeln mit Hilfe von HeapSort zu sortieren. Es freut mich das du dir die Zeit genommen hast, dir dies anzueignen.", 
                            "Du warst ein aufmerksamer und wissbegieriger Lehrling und ich wünsche dir viel Erfolg bei der Anwendung deiner erlernten Fähigkeiten." ,
                            "Lass mich dir noch ein paar zusätzliche Informationen zu HeapSort geben die vielleicht einmal hilfreich werden könnten.",
                            "Einer der großen Vorteile von HeapSort ist der überaus geringe Speicheraufwand, da es sich hierbei um eine in-place Sortierung handelt.",
                            "In-place bedeutet dabei, dass der Algorithmus außer den zu bearbeitenden Daten nur eine, von der Datenmenge unabhängigen, Konstante als Speicher benötigt.",
                            "Der zweite Vorteil ist die logarithmische Maximallaufzeit des Algorithmus von O (n * log n).",
                            "Ein Nachteil ist allerding, dass der Algorithmus nicht auf Stabilität achtet, also die gleiche Reihenfolge von gleichwertigen Elementen bevor und nach der Sortierung nicht gewährleistet ist.",
                            "Somit ist HeapSort immer dann eine gute Wahl, wenn man eine zeitlich zuverlässige Sortierung mit möglichst geringem Speicheraufwand haben möchte und die Reihenfolge gleichwertiger Elemente irrelevant ist.",

     };

        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
}