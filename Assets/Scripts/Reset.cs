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
                    Debug.Log("index of bowl "+b.index+"value of hole "+h.value);
                    b.moveToHole(h.GetComponent<Collider2D>());

                    //clear checkpoints
                    b.checkpoints.Clear();
                    Checkpoint.used = false;
                    BowlMover.checkpointlist.Clear();
                    Bowl.clearMovePosition();
                }
           }
       }
    }

    public static void Reset_2()
    {
        // TODO
    }

    public static void Reset_3()
    {
        // TODO
    }

    public static void Reset_4()
    {
        // TODO
    }
}
