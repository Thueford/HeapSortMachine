using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Globals.Stage;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
   // void Start()
   // {
        public string name ;
        [TextArea(3, 10)]
        public List<string> sentences;
        public GameObject button;
        public Dialogue dlg;
        public string namenew;
        public DialogueTrigger dialogueT;
        public GameObject contiButton;

    void Awake()
    {
        
    dlg = button.GetComponent<Dialogue>();
       
    }

   
    public void Start()
    {
        // Unnötiges Script
        /*string[] input = { "1", "2", "3" };
        
        dlg.name = namenew; Debug.Log(namenew);
        dlg.sentences.Clear();
        dlg.sentences.AddRange(input);*/
    }

    public void nameSetter(string k)
    {
        namenew = k;
        dlg.name = namenew;
        Debug.Log(dlg.name);
    }

    public void sentenceSetter(string[] s)
    {
        dlg.sentences.Clear();
        dlg.sentences.AddRange(s);

    }

    // Hilfe Zone/////////////////////////////////////////////////////////

    public void Hilfe1_1()
    {
        nameSetter("Hilfe1_1");
        string[] sentence = { "Fülle den Baum von oben nach unten!", "Orientiere dich an der vorgegebenen Liste.","Das sind alle Tipps für diese Stage."};
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }

    public void Hilfe1_2()
    {
        nameSetter("Hilfe1_2");
        string[] sentence = { "" };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }
    public void Hilfe2_1()
    {
        nameSetter("Hilfe2_1");
        string[] sentence = { "Achte darauf, dass die größte Zahl im Dreierkomplex oben steht.", "Das sind alle Tipps für diese Stage." };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }
    public void Hilfe2_2()
    {
        nameSetter("Hilfe2_2");
        string[] sentence = { "Am Ende muss das größte Element die Wurzel sein", "Prüfe ob das vorherige Heapify ein anderes zerstört hat", "Das sind alle Tipps für diese Stage." };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }
    public void Hilfe2_3()
    {
        nameSetter("Hilfe2_3");
        string[] sentence = { "Das unterste Blatt ist am weitesten von der Wurzel entfernt.", "Tausche doch die Wurzel mit dem untersten Blatt.", "Das sind alle Tipps für diese Stage." };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }

    //Test Zone     /////////////////////////////////////////////////////////
    public void Test_1_1()
    {
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }
    public void Test_1_2()
    {
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }
    public void Test_2_1()
    {
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }
    public void Test_2_2()
    {
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }
    public void Test_2_3()
    {
        nameSetter("Test");
        string[] sentence = { "5", "5", "7", "8" };
        sentenceSetter(sentence);
        dialogueT.TriggerDialogue();
        contiButton.gameObject.SetActive(true);
    }

    // AutoZone vroom vroom/////////////////////////////////////////////////////////

    public void Auto_1_1()
    {
        string[] input = { "4", "5", "6" };

        dlg.name = "Tipp 1_2";
        dlg.sentences.Clear();
        dlg.sentences.AddRange(input);
    }
    public void Auto_1_2()
    {
        string[] input = { "4", "5", "6" };

        dlg.name = "Tipp 1_2";
        dlg.sentences.Clear();
        dlg.sentences.AddRange(input);
    }
    public void Auto_2_1()
    {
        string[] input = { "4", "5", "6" };

        dlg.name = "Tipp 1_2";
        dlg.sentences.Clear();
        dlg.sentences.AddRange(input);
    }
    public void Auto_2_2()
    {
        string[] input = { "4", "5", "6" };

        dlg.name = "Tipp 1_2";
        dlg.sentences.Clear();
        dlg.sentences.AddRange(input);
    }
    public void Auto_2_3()
    {
        string[] input = { "4", "5", "6" };

        dlg.name = "Tipp 1_2";
        dlg.sentences.Clear();
        dlg.sentences.AddRange(input);
    }
    
    // Reset-Zone/////////////////////////////////////////////////////////


}