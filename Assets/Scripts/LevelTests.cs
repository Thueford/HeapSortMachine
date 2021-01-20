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

        Globals.globals.StartCoroutine(waitASecondThenResetHoleColor());
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
        bool result = true;

        // Regex.Match(ifl.text, "^\\s*2\\s*[*]?\\s*n\\s*[+]\\s*1\\s*$").Success &&
        // Regex.Match(ifr.text, "^\\s*2\\s*[*]?\\s*n\\s*[+]\\s*2\\s*$").Success;

        try { 
                if (Math.Round(Eval(ifl.text.Replace("n", "42"))) != 1 + 84) result = false;
                if (Math.Round(Eval(ifr.text.Replace("n", "42"))) != 2 + 84) result = false;
        } catch(Exception e) {
            Debug.Log("input Field has errors");
            Debug.Log(e);
            result = false;
            // TODO: color input fields red
        }
        return result;
    }

    public static bool Test_3()
    {
        // TODO
        return false;
    }

    public static bool Test_3_Heapified(int n)
    {
        return false;
    }

    public static bool Test_4()
    {
        // TODO
        return false;
    }


    private static IEnumerator waitASecondThenResetHoleColor()
    {
        yield return new WaitForSeconds(1);
        foreach (Hole h in Globals.getHoles(Hole.TREEHOLE))
            h.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[0];
    }
}
