using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    //public static List<Checkpoint> checkpoints = new List<Checkpoint>();
    public static Checkpoint[] checkpoints = new Checkpoint[31];
    public static int checkpointcount = 0;
    //if true checkpoitns already creared
    public static bool used = false;
    public enum CheckpointType
    {
        MOVE, TELEPORT
    }
    public int id;
    public int holeID = 0;

    public CheckpointType checkpoint;

    //checkpoint to teleport to
    public GameObject checkpointTeleport;

    void Start()
    {
        id = checkpointcount;
        checkpoints[id] = this;
        checkpointcount++;
        //checkpoints.Add(this)
    }

    void setCheckpoint (GameObject gameObject)
    {
        transform.position = gameObject.transform.position;
    }
}
