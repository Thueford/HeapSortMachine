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
    
    void Awake()
    {
        dlg = button.GetComponent<Dialogue>();
    }

    void Start()
    {
        string[] input = { "1", "2", "3" };
        
        dlg.name = "Tipp 1_1";
        dlg.sentences.Clear();
        dlg.sentences.AddRange(input);
    }


     public void Hife1_1()
    {
    string[] input = { "1", "2", "3" };
        
        dlg.name = "Tipp 1_1";
        dlg.sentences.Clear();
        dlg.sentences.AddRange(input);
      }
  
}