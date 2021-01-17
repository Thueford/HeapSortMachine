using UnityEngine;
using System;
using System.Collections;
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

    public static bool Test_1_1()
    {
        bool allClear = true;
        foreach (Hole h in Globals.getTreeHoles())//Itterate through every tree Hole
        {    
                                                   
              
            if (!h.content)// no boll in hole
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

    public static bool Test_1_2()
    {
        // TODO
        return false;
    }

    public static bool Test_2_1()
    {
        // TODO
        return false;
    }

    public static bool Test_2_2()
    {
        // TODO
        return false;
    }

    public static bool Test_2_3()
    {
        // TODO
        return false;
    }


    private static IEnumerator waitASecondThenResetHoleColor()
    {
        yield return new WaitForSeconds(1);
        foreach (Hole h in Globals.getTreeHoles())
        {

            h.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[0];
        }
    }
}
