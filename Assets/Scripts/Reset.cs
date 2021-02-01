using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
public class Reset : MonoBehaviour
{

    private static List<Ball> heapReset = new List<Ball>();

    public static void ResetBallsTo(string holeType)
    {
        foreach (Ball b in Globals.balls)
        {
            Hole h = Globals.getHoles(holeType).Find(fh => b.index == fh.index);
            if (h) {
                if (h.content) Ball.isSwapping = true;
                b.moveToHole(h.GetComponent<Collider2D>());
                Ball.isSwapping = Ball.masterSwap;
            }
        }
        Ball.clearMovePosition();
    }

    public static void ResetBallsHeapifiedTo(string holeType)
    {
        if (heapReset.Count == 0) createHeapReset();
        for (int i = 0; i < heapReset.Count; i++) {
            Hole h = Globals.getHoles(holeType).Find(fh => i == fh.index);
            if (h) {
                if (h.content) Ball.isSwapping = true;
                heapReset[i].moveToHole(h.GetComponent<Collider2D>());
                Ball.isSwapping = Ball.masterSwap;
            }
        }
        Ball.clearMovePosition();
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
         HeapTests.resetStatus();
    }

    public static void Reset_4()
    {
        ResetBallsHeapifiedTo(Hole.TREEHOLE);
        HeapTests.resetStatus();
    }

    public static void createHeapReset() {
        if (!Hole.getLastNonEmpty() && heapReset.Count == 0) {
            for (int i = 0; i < 15; i++) {
                Hole h = Globals.getHoles(Hole.TREEHOLE).Find(fh => i == fh.index);
                if (h) heapReset.Add(Globals.balls[i]);
            }
        } else {
            heapReset.Clear();
            for (int i = 0; i < 15; i++) {
                Hole h = Globals.getHoles(Hole.TREEHOLE).Find(fh => i == fh.index);
                if (h && h.content) heapReset.Add(h.content);
            }
        }
    }
}
