using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public  class Dialogue : MonoBehaviour
{
    public Random rnd = new UnityEngine.Random();
        public static string name ;
        [TextArea(3, 10)]
        public static List<string> sentences = new List<string>();
     
        public static string namenew;
        private static Dialogue self;
    public DialogueManager dialogueManager;

    void Awake()
    {
        
        self = this;
       
    }

  

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
    public static void Hilfe1_1()
    {
        sentences.Clear();
        nameSetter("Hilfe1_1");
        string[] sentence = { "Fülle den Baum von oben nach unten!", "Orientiere dich an der vorgegebenen Liste.","Das sind alle Tipps für diese Stage."};
        //  sentences.AddRange(sentence);
        sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
 
    public static void Hilfe1_2()
    {
        sentences.Clear();
        nameSetter("Hilfe1_2");
        string[] sentence = { "Hier gibt es leider keine Tipps" };
        sentences.AddRange(sentence);
       DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Hilfe2_1()
    {
        sentences.Clear();
        nameSetter("Hilfe2_1");
        string[] sentence = { "Achte darauf, dass die größte Zahl im Dreierkomplex oben steht.", "Das sind alle Tipps für diese Stage." };
         sentences.AddRange(sentence);
        ////DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Hilfe2_2()
    {
        sentences.Clear();
        nameSetter("Hilfe2_2");
        string[] sentence = { "Am Ende muss das größte Element die Wurzel sein", "Prüfe ob das vorherige Heapify ein anderes zerstört hat", "Das sind alle Tipps für diese Stage." };
         sentences.AddRange(sentence);
       DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Hilfe2_3()
    {
        sentences.Clear();
        nameSetter("Hilfe2_3");
        string[] sentence = { "Das unterste Blatt ist am weitesten von der Wurzel entfernt.", "Tausche doch die Wurzel mit dem untersten Blatt.", "Das sind alle Tipps für diese Stage." };
         sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

   //Test Zone     /////////////////////////////////////////////////////////
   public static void Test_1_1(bool b)
   {
        string[] sentence;
        sentences.Clear();
        if (b)
        {   
            nameSetter("Richtig!");
            string[] sentence_random = { "Super das ist ja fast wie meine eigen Arbeit.", "Wenn du so weiter machst kann ich dich meinen Schüler nennen." };
            int sIndex = Random.Range(0, sentence_random.Length-1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] {sent_rand, "Als nächstes behandeln wir Stage 1.2" };
        }
        else
        {
            nameSetter("Falsch");
            sentence = new string[] { "Wenn du so weiter machst werden wir beide noch gefeuert!", "Versuche es einfach nocheinmal!", "Benutze doch einfach auch mal den Tipp Button" };
        }

        sentenceSetter(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Test_1_2(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            nameSetter("Richtig!");
            string[] sentence_random = { "Super das ist ja fast wie meine eigen Arbeit.", "Wenn du so weiter machst kann ich dich meinen Schüler nennen." };

            // Random importieren
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { sent_rand, "Da hast du aber einen schönenen Baum erstellt.", "Als nächstes behandeln wir Stage 2.1" };
            sentences.AddRange(sentence);
        }
        else
        {
            nameSetter("Falsch");
            sentence = new string[] { "Wenn du so weiter machst werden wir beide noch gefeuert!", "Versuche es einfach nocheinmal!", "Benutze doch einfach auch mal den Tipp Button" };
            sentences.AddRange(sentence);
        }

       
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Test_2_1(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            nameSetter("Richtig!");
            string[] sentence_random = { "Super das ist ja fast wie meine eigen Arbeit.", "Wenn du so weiter machst kann ich dich meinen Schüler nennen." };

            // Random importieren
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { sent_rand, "Dein Baum erfüllt jetzt die Heap-Bedingung", "Als nächstes behandeln wir Stage 2.2" };
        }
        else
        {
            nameSetter("Falsch");
            sentence = new string[] { "Wenn du so weiter machst werden wir beide noch gefeuert!", "Versuche es einfach nocheinmal!", "Benutze doch einfach auch mal den Tipp Button" };
        }

        sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    public static void Test_2_2(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            nameSetter("Richtig!");
            string[] sentence_random = { "Super das ist ja fast wie meine eigen Arbeit.", "Wenn du so weiter machst kann ich dich meinen Schüler nennen." };
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { sent_rand, "Als nächstes behandeln wir Stage 2.3"};
        }
        else
        {
            nameSetter("Falsch");
            sentence = new string[] { "Wenn du so weiter machst werden wir beide noch gefeuert!", "Versuche es einfach nocheinmal!", "Benutze doch einfach auch mal den Tipp Button" };
        }

        sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Test_2_3(bool b)
    {
        string[] sentence;
        sentences.Clear();
        if (b)
        {
            nameSetter("Richtig!");
            string[] sentence_random = { "Super das ist ja fast wie meine eigen Arbeit.", "Wenn du so weiter machst kann ich dich meinen Schüler nennen." };
            int sIndex = Random.Range(0, sentence_random.Length - 1);
            string sent_rand = sentence_random[sIndex];
            sentence = new string[] { sent_rand, "Wir sind fertig du hast eigenständig die Heap-Sort-Maschine repariert.", "Jetzt musst du den Heap-Sort-Algorithmus verstanden haben. Falls nicht starte das Spiel einfach neu" };

        }
        else
        {
            nameSetter("Falsch");
            sentence = new string[] { "Wenn du so weiter machst werden wir beide noch gefeuert!", "Versuche es einfach nocheinmal!", "Benutze doch einfach auch mal den Tipp Button" };
        }

        sentences.AddRange(sentence);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    
    // AutoZone vroom vroom/////////////////////////////////////////////////////////

    public static void Auto_1_1()
    {
        sentences.Clear();
        string[] input = {"Stage 1.1 läuft nun automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Auto_1_2()
    {
        sentences.Clear();
        string[] input = { "Stage 1.2 läuft nun automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Auto_2_1()
    {
        sentences.Clear();
        string[] input = { "Stage 2.1 läuft jetzt automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Auto_2_2()
    {
        sentences.Clear();
        string[] input = { "Stage 2.2 läuft jetzt automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Auto_2_3()
    {
        sentences.Clear();
        string[] input = { "Stage 2.3 läuft jetzt automatisch ab" };

        name = "Auto";
        sentences.Clear();
        sentences.AddRange(input);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }


    // Reset-Zone/////////////////////////////////////////////////////////

}