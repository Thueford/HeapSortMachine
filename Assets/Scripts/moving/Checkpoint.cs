using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<Checkpoint> checkpoints = new List<Checkpoint>();
    public enum CheckpointType
    {
        MOVE, TELEPORT
    }
    public int id;

    public CheckpointType checkpoint;

    //checkpoint to teleport to
    public GameObject checkpointTeleport;

    void Start()
    {
        checkpoints.Add(this);

    }

    void setCheckpoint (GameObject gameObject)
    {
        transform.position = gameObject.transform.position;
    }
}
