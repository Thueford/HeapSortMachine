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
    public static BallMover self;
    private static AnimationCallback cb = null;

    private static List<Checkpoint> startListCheckpoint = new List<Checkpoint>();
    private static List<Checkpoint> treeListCheckpoints = new List<Checkpoint>();
    private static List<Checkpoint> sortedListCheckpoint = new List<Checkpoint>();
    private static List<Checkpoint> currentCheckpoints = new List<Checkpoint>();

    private bool treeList = false;
    public GameObject checkpointPrefab;


    private void Awake()
    {
        self = this;
    }

    public static void AnimationComplete()
    {
        //manchmal null idk wer das hier geadded hat
        if (cb != null) cb();
        cb = null;
    }

    public static void makeCheckpoints(List<Checkpoint> cpList, string HoleType, bool ovrHole = false)
    {
        if (cpList.Count == 0)
        {
            //create checkpoints in start list and sort them
            foreach (Hole hole in Globals.getHoles(HoleType))
            {
                GameObject chp = Instantiate(self.checkpointPrefab, hole.transform.position, Quaternion.identity);
                Checkpoint cp = chp.GetComponent<Checkpoint>();
                cp.transform.SetParent(Globals.self.checkpointHolder.transform);
                cp.holeID = hole.index;
                cp.dynamicPlaced = true;
                if(ovrHole) cp.overHole = hole;

                //new
                cpList.Add(cp);
            }

            cpList.Sort((a, b) => a.holeID < b.holeID ? -1 : 1);
        }
    }

    // returns boolean, true if animation was started
    public static bool autoMoveInit(AnimationCallback acb)
    {
        bool res = true;
        cb = acb;

        //testing
        //Globals.Stage currentStage = Globals.Stage.STAGE_4;
        Globals.Stage currentStage = Globals.stage;

        makeCheckpoints(startListCheckpoint, Hole.LISTHOLE);
        makeCheckpoints(treeListCheckpoints, Hole.TREEHOLE);
        makeCheckpoints(sortedListCheckpoint, Hole.SORTHOLE, true);

        foreach (GameObject g in Globals.self.toMoveZ)
            g.transform.position = Ball.addVecZ(g.transform.position, -21);

        switch (currentStage)
        {
            //all dynamic Checkpoints get added here (you can add more than one list to currentCheckpoints)
            case Globals.Stage.STAGE_2: currentCheckpoints = treeListCheckpoints; self.treeList = true; break;
            case Globals.Stage.STAGE_4: currentCheckpoints = sortedListCheckpoint; self.treeList = false; break;
            default: res = false; break;
        }

        //sort already placed checkpoints by id and add them to list
        //Checkpoint.checkpoints[currentStage].Sort((a, b) => a.Id < b.Id ? -1 : 1);
        //foreach (Checkpoint cp in Checkpoint.checkpoints[currentStage]) {
            //currentCheckpoints.Insert(0, cp);  }

        foreach (Ball ball in Globals.balls)
        {
            //sort already placed checkpoints by id and add them to list
            Checkpoint.checkpoints[currentStage].Sort((a, b) => a.Id < b.Id ? -1 : 1);
            ball.checkpoints.AddRange(Checkpoint.checkpoints[currentStage]);
            ball.checkpoints.Sort((a, b) => a.Id < b.Id ? -1 : 1);

            //if has to get in tree order
            if (self.treeList)
                ball.checkpoints.AddRange(currentCheckpoints.FindAll(cp => self.isParent(ball.index, cp.holeID)));
            else
                ball.checkpoints.AddRange(currentCheckpoints.FindAll(cp => cp.holeID == ball.value));

            //works in stage 2 but not 4 idk why 
            //static checkpoints are not affected cuz they are holeID = 0
            //ball.checkpoints.Sort((a, b) => a.holeID < b.holeID ? -1 : 1);
        }
        Globals.self.StartCoroutine(self.ballStarter());
        return res;
    }

    public static void moveToSortedList(Ball ball, Hole h)
    {
        makeCheckpoints(sortedListCheckpoint, Hole.SORTHOLE, true);

        if (ball.checkpoints.Count != 0) return;

        foreach (GameObject g in Globals.self.toMoveZ)
            g.transform.position = Ball.addVecZ(g.transform.position, -21);

        ball.checkpoints.AddRange(Checkpoint.checkpoints[Globals.Stage.STAGE_4]);
        ball.checkpoints.Sort((a, b) => a.Id < b.Id ? -1 : 1);
        ball.checkpoints.AddRange(sortedListCheckpoint.FindAll(cp => cp.holeID == ball.value));

        /*if (ball.checkpoints[ball.checkpoints.Count-1].overHole == null)
        {
            Debug.Log(ball);
            Debug.LogError("last checkpoint is not on hole");
        }*/

        Globals.self.StartCoroutine(self.ballStarter());
    }

    private IEnumerator ballStarter()
    {
        foreach (Ball ball in Globals.balls)
        {
            ball.startAutomaticMove();
            yield return new WaitForSeconds(0.4f);
        }
    }

    private bool isParent(int childID, int holeID)
    {
        if (childID > holeID) return isParent((childID - 1) / 2, holeID);
        return childID == holeID;
    }
}
