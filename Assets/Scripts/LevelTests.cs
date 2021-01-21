using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Text.RegularExpressions;

public class LevelTests : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool Test_1()
    {

        bool allClear = true;
        foreach (Hole h in Globals.getHoles(Hole.TREEHOLE)) //Iterate through every tree Hole
        {


            if (!h.content) // no boll in hole
            {
                allClear = false;
                h.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[2];
            }

            else if (h.content.index == h.value)// index of ball in Hole is equal to value of Hole
            {
                h.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[1];
            }

            else
            {
                h.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[2];
                allClear = false;
            }

        }
        // every ball is in the right hole

        Globals.globals.StartCoroutine(waitASecondThenResetColor());
        return allClear;
    }

    // throws Exceptions
    static double Eval(string expression)
    {
        return Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
    }

    public static bool Test_2()
    //if textfield left = 2n+1 and textfield Right = 2n+2 return true
    {
        InputField ifl = GameObject.Find("edtRuleLeft").GetComponent<InputField>();
        InputField ifr = GameObject.Find("edtRuleRight").GetComponent<InputField>();

        // Regex.Match(ifl.text, "^\\s*2\\s*[*]?\\s*n\\s*[+]\\s*1\\s*$").Success &&
        // Regex.Match(ifr.text, "^\\s*2\\s*[*]?\\s*n\\s*[+]\\s*2\\s*$").Success;

        try
        {
            string sl = Regex.Replace(ifl.text, "(\\d+)(\\w+)", "$1*$2");
            string sr = Regex.Replace(ifr.text, "(\\d+)(\\w+)", "$1*$2");
            Debug.Log("Formulae: '" + sl + "' '" + sr + "'");
            for (int n = 0; n < 15; n++) {
                if (Math.Round(Eval(sl.Replace("n", n.ToString()))) != 2 * n + 1) return false;
                if (Math.Round(Eval(sr.Replace("n", n.ToString()))) != 2 * n + 2) return false;
            }
        } catch(Exception e) {
            Debug.Log("input Field has errors");
            Debug.Log(e);
            return false;
            // TODO: color input fields red
        }
        return true;
    }

    public static bool Test_3()
    {
        bool b = true;
        for (int n = 0; n <= 6; n++) {
            bool t = Test_3_Heapified(n);
            b = t && b;
            Globals.globals.heapChkBtns[n].GetComponent<Image>().sprite = t ? ButtonHandler.self.sprHeapChk : ButtonHandler.self.sprHeapUnchk;
        }
        return b;
    }

    public static bool Test_3_Heapified(int n)
    {
        Joint[] tmp = Joint.getJoints(n);
        Debug.Log(tmp);
        bool b = true;

        //TODO
        //implement comparison rule
        for (int i = 0; i < 2; i++) {
            if (tmp[i].hole1.content.value > tmp[i].hole2.content.value) {
                tmp[i].GetComponent<SpriteRenderer>().sprite = Globals.globals.jointSprites[n>0 ? n>2 ? 4 : 2 : 0];
                } else {
                    b = false;
                    tmp[i].GetComponent<SpriteRenderer>().sprite = Globals.globals.jointSprites[n>0 ? n>2 ? 5 : 3 : 1];
                }
            tmp[i].GetComponent<SpriteRenderer>().enabled = true;
        }

        Globals.globals.StartCoroutine(waitASecondThenResetColor());
        return b;
    }

    public static bool Test_4()
    {
        bool b = true;
        for (int n = 0; n <= 6; n++) {
            bool t = Test_3_Heapified(n);
            b = t && b;
            Globals.globals.heapChkBtns[n].GetComponent<Image>().sprite = t ? ButtonHandler.self.sprHeapChk : ButtonHandler.self.sprHeapUnchk;
        }
        return b;
    }


    private static IEnumerator waitASecondThenResetColor()
    {
        yield return new WaitForSeconds(1);
        foreach (Hole h in Globals.getHoles(Hole.TREEHOLE))
            h.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[0];
        foreach (Joint j in Globals.joints)
            j.GetComponent<SpriteRenderer>().enabled = false;
    }
}
