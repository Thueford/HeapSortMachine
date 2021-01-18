using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlMover : MonoBehaviour
{
    //list all checkpoints are in
    public static List<Checkpoint> checkpointlist = new List<Checkpoint>();
    public static List<Checkpoint> staticcheckpointlist = new List<Checkpoint>();
    public static BowlMover bowlMover;

    public GameObject checkpointPrefab;

    private void Awake()
    {
        if (!bowlMover) bowlMover = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void autoMoveStart()
    {
        //create checkpoints
        //add existing checkpoint 
        foreach (Checkpoint cp in Checkpoint.checkpoints)
        {
            staticcheckpointlist.Add(cp);
        }

        //create checkpoint on the holes position here
        if (!Checkpoint.used)
        {
            foreach (Hole hole in Globals.getTreeHoles())
            {
                GameObject chp = Instantiate(bowlMover.checkpointPrefab, hole.transform.position, Quaternion.identity);
                Checkpoint cp = chp.GetComponent<Checkpoint>();
                cp.transform.SetParent(Globals.globals.checkpointHolder.transform);
                cp.holeID = hole.value;
                checkpointlist.Add(cp);
                Checkpoint.used = true;

            }
        }
        //sort checkpoint list
        checkpointlist.Sort((a, b) => a.holeID < b.holeID ? -1 : 1);

        //put checkpoints to bowllist
        foreach (Bowl bowl in Globals.bowls)
        {
            //Debug.Log(checkpointlist);
            foreach (Checkpoint c in staticcheckpointlist)
            {
                if (c)
                {
                    bowl.checkpoints.Add(c);
                }
            }

            foreach (Checkpoint c in checkpointlist)
            {
                //für das perfekte sortieren bowl.value nehmen
                if (bowlMover.isParent(bowl.index, c.holeID))
                {
                    bowl.checkpoints.Add(c);
                }
            }

            bowl.checkpoints.Sort((a, b) => a.holeID < b.holeID ? -1 : 1);
            if (bowl.index == 0)
            {
                bowl.checkpoints.Reverse();
            }
            bowl.startAutomaticMove();
        }
    }

    private bool isParent(int childID, int holeID)
    {
        if (childID == holeID) return true;
        if (childID < holeID) return false;
        if (isParent((int)(childID - 1) / 2, holeID)) return true;
        return false;
    }
}
