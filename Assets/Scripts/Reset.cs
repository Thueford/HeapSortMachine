using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
public class Reset : MonoBehaviour
{
    public static void ResetBallsTo(string holeType)
    {
        foreach (Bowl b in Globals.bowls)
        {
            Hole h = Globals.getHoles(holeType).Find(fh => b.index == fh.value);
            if (h) b.moveToHole(h.GetComponent<Collider2D>());
        }
        Bowl.clearMovePosition();
    }

    public static void Reset_1()
    {
        ResetBallsTo(Hole.LISTHOLE);
    }

    public static void Reset_2()
    {
        GameObject.Find("edtRuleLeft").GetComponent<InputField>().text = "";
        GameObject.Find("edtRuleRight").GetComponent<InputField>().text = "";
    }

    public static void Reset_3()
    {
         ResetBallsTo(Hole.TREEHOLE);
    }

    public static void Reset_4()
    {
        // TODO
    }
}
