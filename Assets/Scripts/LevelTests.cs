using UnityEngine;
using System;
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
        
        foreach (Hole itterationHole in Globals.holes)//Itterate through every tree Hole
        {                                               
            if (itterationHole.tree)                    
            {   

                try
                {
                    if (itterationHole.content.index == itterationHole.value)// index of bowl in Hole is equal to value of Hole
                    {
                        continue;
                    }

                    else
                    {
                        
                        return false;
                    }
                }
                catch (NullReferenceException e)// thrown if no bowl in hole
                {
                    return false;
                }
            }
            
        }
        // every bowl is in the right hole
        return true;
        
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
}
