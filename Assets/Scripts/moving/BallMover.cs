using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    //list all checkpoints are in
    public delegate void AnimationCallback();

    public static List<Checkpoint> checkpointlist = new List<Checkpoint>();
    public static List<Checkpoint> staticcheckpointlist = new List<Checkpoint>();
    public static BallMover ballMover;
    private static AnimationCallback cb = null;

    //je nachdem welche stage
    //bei stage 2 gibts noch nen fehler die erste kugel macht checkpoints in falscher reihnfolge
    private static int stage = 1;

    private static int moving = 0;

    public GameObject checkpointPrefab;

    private void Awake()
    {
        if (!ballMover) ballMover = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void AnimationComplete()
    {
        //manchmal null idk wer das hier geadded hat
        if (cb != null) cb();
        cb = null;
    }

    public static void autoMoveStart(AnimationCallback acb)
    {
        cb = acb;

        //create checkpoints
        //add existing checkpoint 
        foreach (Checkpoint cp in Checkpoint.checkpoints)
        {
            if (cp) //lucas meint null?
            {
                if (cp.stage == stage)
                {
                    staticcheckpointlist.Add(cp);
                }
            }
        }
        //existing checkpoints have to get sorted by id first
        staticcheckpointlist.Sort((a, b) => a.Id < b.Id ? -1 : 1);

        //create checkpoint on the holes position here
        if (!Checkpoint.used)
        {
            foreach (Hole hole in Globals.getHoles(Hole.TREEHOLE))
            {
                GameObject chp = Instantiate(ballMover.checkpointPrefab, hole.transform.position, Quaternion.identity);
                Checkpoint cp = chp.GetComponent<Checkpoint>();
                cp.transform.SetParent(Globals.globals.checkpointHolder.transform);
                cp.holeID = hole.value;
                checkpointlist.Add(cp);
                Checkpoint.used = true;
            }
        }
        //sort checkpoint list
        checkpointlist.Sort((a, b) => a.holeID < b.holeID ? -1 : 1);

        //have to move some objects in forground for putting them back to default z look at ball.cs
        foreach (GameObject g in Globals.globals.toMoveZ)
        {
            
            Vector3 tempvec = g.transform.position;
            tempvec.z -= 21;

            g.transform.position = tempvec;
        }

        //put checkpoints to balllist
        int n = 0;
        foreach (Ball ball in Globals.balls)
        {
            //Debug.Log(checkpointlist);
            foreach (Checkpoint c in staticcheckpointlist)
                if (c) ball.checkpoints.Add(c);

            //für das perfekte sortieren ball.value nehmen
            foreach (Checkpoint c in checkpointlist)
                if (ballMover.isParent(ball.index, c.holeID))
                    ball.checkpoints.Add(c);

            ball.checkpoints.Sort((a, b) => a.holeID < b.holeID ? -1 : 1);

            //Debug.Log(ball.checkpoints);

            if (ball.index == 0)
            {
                //ball.checkpoints.Reverse();
            }

            //ball.startAutomaticMove();
            //StartCoroutine(ballMover.ballStarter);
            //Globals.globals.StartCoroutine(ballMover.ballStarter(ball));
        }

        Globals.globals.StartCoroutine(ballMover.ballStarter());
    }

    private IEnumerator ballStarter()
    {
        foreach(Ball ball in Globals.balls)
        {
            ball.startAutomaticMove();
            yield return new WaitForSeconds(0.4f);
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
