using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public  class Dialogue : MonoBehaviour
{
    public static Random rnd = new Random();
    public static string name;
    [TextArea(3, 10)]
    public static List<string> sentences = new List<string>();

    public static string namenew;

    public static Dialogwrapper json = Dialogwrapper.Load();

    private static int[] hintCounter = new int[] {0, 0, 0, 0, 0};
    private static int[] tippCounter = new int[] {0, 0, 0, 0};

    public static void nameSetter(string k)
    {
        namenew = k;
        name = namenew;
    }

    /*public static void sentenceSetter(params string[] s)
    {
        sentences.Clear();
        sentences.AddRange(s);
    }*/

    public static void addSentences(params string[] s)
    {
        sentences.AddRange(s);
    }

    private static void SetDialog(string name, params string[] sents)
    {
        sentences.Clear();
        AddDialog(name, sents);
    }

    private static void AddDialog(string name, params string[] sents)
    {
        nameSetter(name);
        sentences.AddRange(sents);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    private static void SetDialog(string name, Dialogwrapper.Textwrapper tw, params string[] sents)
    {
        sentences.Clear();
        nameSetter(name);
        sentences.AddRange(sents);
        sentences.AddRange(tw.text);
        DialogueManager.setMecha(tw.emotion);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }

    private static void SetDialog(string name, Dialogwrapper.Textwrapper tw)
    {
        sentences.Clear();
        AddDialog(name, tw);
    }
    private static void AddDialog(string name, Dialogwrapper.Textwrapper tw)
    {
        nameSetter(name);
        sentences.AddRange(tw.text);
        DialogueManager.setMecha(tw.emotion);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }
    private static  void SetDialoge(string name, Dialogwrapper.Textwrapper tw, params string[] sents)
    {
        sentences.Clear();
        nameSetter(name);
        sentences.AddRange(sents);
        sentences.AddRange(tw.text);
        DialogueManager.setMecha(tw.emotion);
        DialogueManager.self.StartDialogue();
        DialogueManager.self.contiButton.gameObject.SetActive(true);
    }


    // Hilfe Zone/////////////////////////////////////////////////////////
    public static void Hilfe_1()
    {
        int i = 0;
        DialogueManager.setMecha("explain");
        switch(tippCounter[i]) {
            case 0: SetDialog("Hilfe 1:", json.level_hints.stage_1.text[0], json.level_hints.stage_1.text[1]);
                    break;
            case 1: SetDialog("Hilfe 1:", json.level_hints.stage_1.text[2]);
                    break;
        }
        tippCounter[i] = (tippCounter[i]+1) % 2;
    }

    public static void Hilfe_2()
    {
        int i = 1;
        DialogueManager.setMecha("explain");
        switch(tippCounter[i]) {
            case 0: SetDialog("Hilfe 1:", json.level_hints.stage_2.text[0], json.level_hints.stage_2.text[1]);
                    break;
            case 1: SetDialog("Hilfe 1:", json.level_hints.stage_2.text[2], json.level_hints.stage_2.text[3]);
                    break;
            case 2: SetDialog("Hilfe 1:", json.level_hints.stage_2.text[4]);
                    break;
        }
        tippCounter[i] = (tippCounter[i]+1) % 3;
    }

    public static void Hilfe_3()
    {
        int i = 2;
        DialogueManager.setMecha("explain");
        switch(tippCounter[i]) {
            case 0: SetDialog("Hilfe 1:", json.level_hints.stage_3.text[0], json.level_hints.stage_3.text[1]);
                    break;
            case 1: SetDialog("Hilfe 1:", json.level_hints.stage_3.text[2], json.level_hints.stage_3.text[3]);
                    break;
            case 2: SetDialog("Hilfe 1:", json.level_hints.stage_3.text[4], json.level_hints.stage_3.text[5]);
                    break;
        }
        tippCounter[i] = (tippCounter[i]+1) % 3;
    }

    public static void Hilfe_4()
    {
        int i = 3;
        DialogueManager.setMecha("explain");
        switch(tippCounter[i]) {
            case 0: SetDialog("Hilfe 1:", json.level_hints.stage_4.text[0], json.level_hints.stage_4.text[1]);
                    break;
            case 1: SetDialog("Hilfe 1:", json.level_hints.stage_4.text[2]);
                    break;
        }
        tippCounter[i] = (tippCounter[i]+1) % 2;
    }

    //Test Zone     /////////////////////////////////////////////////////////

    private static string GetRandom(params string[] sentences)
    {
        return sentences[Random.Range(0, sentences.Length - 1)];
    }

    public static void Test_1(bool b)
    {
        if (b)
        {
            SetDialoge("Richtig!", json.level_complete.stage_1, GetRandom(json.random_success.text));
            DialogueManager.nextStage = Globals.Stage.STAGE_2;
        }
        else
        {
            SetDialoge("Falsch!", json.falsch, GetRandom(json.random_mistake.text));
        }
    }

    public static void Test_2(bool b)
    {
        if (b)
        {
            SetDialoge("Richtig!", json.level_complete.stage_2, GetRandom(json.random_success.text));
            DialogueManager.nextStage = Globals.Stage.STAGE_3;
        }
        else
        {
            SetDialoge("Falsch!", json.falsch, GetRandom(json.random_mistake.text));
        }
    }

    public static void Test_3(bool b)
    {
        if (b)
        {
            SetDialoge("Richtig!", json.level_complete.stage_3, GetRandom(json.random_success.text));
            DialogueManager.nextStage = Globals.Stage.STAGE_4;
        }
        else
        {
            SetDialoge("Falsch!", json.falsch, GetRandom(json.random_mistake.text));
        }
    }

    public static void Test_4(bool b, int toBeSorted)
    {
        if (b && toBeSorted < 1)
        {
            SetDialoge("Richtig!", json.level_complete.stage_4, GetRandom(json.random_success.text));
            DialogueManager.nextStage = Globals.Stage.END;
        }
        else if (b)
        {
            if (toBeSorted < 13) { } // SetDialog("Richtig!", GetRandom(json.random_success.text));
            else if (toBeSorted == 13) reasonWhyEfficient();
            else firstChange();
        }
        else
        {
            SetDialoge("Falsch!", json.falsch, GetRandom(json.random_mistake.text));
        }
    }

    // AutoZone vroom vroom/////////////////////////////////////////////////////////

    public static void Auto_1() {
        SetDialog("Auto", "Stage 1 läuft nun automatisch ab");
    }
    public static void Auto_2() {
        SetDialog("Auto", "Stage 2 läuft nun automatisch ab");
    }
    public static void Auto_3() {
        SetDialog("Auto", "Stage 3 läuft nun automatisch ab");
    }
    public static void Auto_4() {
        SetDialog("Auto", "Stage 4 läuft nun automatisch ab");
    }

    /// Reactions from Stage 3////////////////////////////////////////////

    public static void heap_destroy()
    {
        if (hintCounter[0] > 0) return;
        SetDialog("Hinweis:", json.reaction_from_3.heap_destroy);
        hintCounter[0] += 1;
    }

    public static void notLastSubtree()
    {
        if (hintCounter[1] > 1) return;
        SetDialog("Hinweis:", json.reaction_from_3.not_last_subtree);
        hintCounter[1] += 1;
    }

    public static void changeLittleOne() {
        if (hintCounter[2] > 1) return;
        SetDialog("Hinweis:", json.reaction_from_3.change_little_one);
        hintCounter[2] += 1;
    }

    public static void firstChange() {
        SetDialog("Hinweis:", json.reaction_from_3.first_change);
    }

    public static void reasonWhyEfficient() {
        SetDialog("Hinweis:", json.reaction_from_3.reason_why_efficient);
    }

    public static void Outro() {
        SetDialog("Mechaniker:", json.stage4_outro);
    }

    public static void Stage_1() {
        SetDialog("Mechaniker:", json.stage1_intro);
    }
}
