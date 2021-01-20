using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Hole hole1;
    public Hole hole2;
    public int id;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake() {
        Globals.joints.Add(this);
    }

    public void onClick() {
        if (!(Globals.stage == Globals.Stage.STAGE_3 || Globals.stage == Globals.Stage.STAGE_4)) {
            Debug.Log("Wrong Stage");
            return;
        }
        if (hole1.content == null || hole2.content == null) {
            Debug.Log("One hole empty, swap canceled");
            return;
        }
        Bowl.swapTwo(hole1.content, hole2.content);
    }
}
