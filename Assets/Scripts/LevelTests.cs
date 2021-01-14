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
        foreach (Hole itterationHole in Globals.holes)//Itterate through every tree Hole
        {                                               
            if (itterationHole.tree)                    
            {   
                try
                {
                    if (itterationHole.content.index == itterationHole.value)// index of bowl in Hole is equal to value of Hole
                    {
                        itterationHole.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[1];
                        continue;
                    }

                    else
                    {
                        itterationHole.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[2];
                        allClear = false;
                        continue;
                    }
                }
                catch (NullReferenceException)// thrown if no bowl in hole
                {
                    return false;
                }
            }
            
        }
        // every bowl is in the right hole
        Globals.globals.StartCoroutine(waitASecondThenResetHoleColor());
        return allClear;
    }

    public static void Test_1_2()
    {
        // TODO
    }

    public static void Test_2_1()
    {
        // TODO
    }

    public static void Test_2_2()
    {
        // TODO
    }

    public static void Test_2_3()
    {
        // TODO
    }



    private static IEnumerator waitASecondThenResetHoleColor()
    {
        yield return new WaitForSeconds(1);
        foreach (Hole h in Globals.holes)
        {
            if (h.tree)                    
            { 
                h.GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[0];
            }
        }
    }
}
