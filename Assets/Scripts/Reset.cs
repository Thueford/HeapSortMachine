using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
public class Reset : MonoBehaviour
{

    public static void Reset_1()
    {
       foreach (Bowl b in Globals.bowls)
       {
           foreach (Hole h in Globals.getHoles(Hole.LISTHOLE))
           {
               if (b.index == h.value)
                {
                    b.moveToHole(h.GetComponent<Collider2D>());
                }
           }
       }
    
    }

    public static void Reset_2()
    {
        GameObject.Find("edtRuleLeft").GetComponent<InputField>().text = "";
        GameObject.Find("edtRuleRight").GetComponent<InputField>().text = "";
    }

    public static void Reset_3()
    {
        foreach (Bowl b in Globals.bowls)
       {
           foreach (Hole h in Globals.getHoles(Hole.TREEHOLE))
           {
               if (b.index == h.value)
                {
                    b.moveToHole(h.GetComponent<Collider2D>());
                }
           }
       }
    }

    public static void Reset_4()
    {
        // TODO
    }
}
