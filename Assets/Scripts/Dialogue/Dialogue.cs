using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Globals.Stage;

[System.Serializable]
public  class Dialogue : MonoBehaviour
{
   // void Start()
   // {
        public static string name ;
        [TextArea(3, 10)]
        public static List<string> sentences = new List<string>();
       // public Dialogue /*dlg*/;
        public static string namenew;
        private static Dialogue self;
    public DialogueManager dialogueManager;

    void Awake()
    {
        
       // /*dlg*/ = button.GetComponent<Dialogue>();
        self = this;
       
    }

   
    public static void Start()
    {
        // Unnötiges Script
        /*string[] input = { "1", "2", "3" };
        /*
        /*dlg.name = namenew; Debug.Log(namenew);
        /*dlg.sentences.Clear();
        /*dlg.sentences.AddRange(input);
        */
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
        Debug.Log(s);

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
        string[] sentence = { "" };
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
        ////dialogueT.TriggerDialogue();
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
    public static void Test_1_1()
    {
        sentences.Clear();
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
         sentences.AddRange(sentence);
       DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Test_1_2()
    {
        sentences.Clear(); 
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
         sentences.AddRange(sentence);
       DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Test_2_1()
    {
        sentences.Clear(); 
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
         sentences.AddRange(sentence);
       DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Test_2_2()
    {
        sentences.Clear(); 
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
         sentences.AddRange(sentence);
       DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    public static void Test_2_3()
    {
        sentences.Clear(); 
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
         sentences.AddRange(sentence);
       DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    // AutoZone vroom vroom/////////////////////////////////////////////////////////

    public static  void Auto_1_1()
    {
        sentences.Clear(); 
        string[] input = { "4", "5", "6" };

        /*dlg.*/name = "Tipp 1_2";
        /*dlg.*/sentences.Clear();
        /*dlg.*/sentences.AddRange(input);
    }
    public static void Auto_1_2()
    {
        sentences.Clear(); 
        string[] input = { "4", "5", "6" };

        /*dlg.*/name = "Tipp 1_2";
        /*dlg.*/sentences.Clear();
        /*dlg.*/sentences.AddRange(input);
    }
    public static void Auto_2_1()
    {
        sentences.Clear(); 
        string[] input = { "4", "5", "6" };

        /*dlg.*/name = "Tipp 1_2";
        /*dlg.*/sentences.Clear();
        /*dlg.*/sentences.AddRange(input);
    }
    public static void Auto_2_2()
    {
        sentences.Clear(); 
        string[] input = { "4", "5", "6" };

        /*dlg.*/name = "Tipp 1_2";
        /*dlg.*/sentences.Clear();
        /*dlg.*/sentences.AddRange(input);
    }
    public static void Auto_2_3()
    {
        sentences.Clear(); 
        string[] input = { "4", "5", "6" };

        /*dlg.*/name = "Tipp 1_2";
        /*dlg.*/sentences.Clear();
        /*dlg.*/sentences.AddRange(input);
    }

    // Reset-Zone/////////////////////////////////////////////////////////
    
}