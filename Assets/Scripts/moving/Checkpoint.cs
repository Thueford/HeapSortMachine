using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    //public static List<Checkpoint> checkpoints = new List<Checkpoint>();
    public static Checkpoint[,] checkpoints = new Checkpoint[4, 31];
    public static int checkpointcount = 0;
    //if true checkpoitns already creared
    public static bool used = false;
    public enum CheckpointType
    {
        MOVE, TELEPORT
    }
    public int Id;
    public int holeID = 0;

    public CheckpointType checkpoint;
    public int stage;

    //checkpoint to teleport to
    public GameObject checkpointTeleport;

    void Start()
    {
        //Id = checkpointcount;
        if (stage == null) stage = -1;
        if (!checkpoints[stage, Id]) checkpoints[stage, Id] = this;
        checkpointcount++;
        //checkpoints.Add(this)
    }

    void setCheckpoint (GameObject gameObject)
    {
        transform.position = gameObject.transform.position;
    }
}
