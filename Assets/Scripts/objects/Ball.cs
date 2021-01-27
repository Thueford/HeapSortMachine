using UnityEngine;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
    //to know how much balls are still moving
    public static List<Ball> moving = new List<Ball>();
    public static bool staticDnDEnable = true;
    public static bool isSwapping = false;
    public static bool masterSwap = false;
    //list of checkpoints to move
    public List<Checkpoint> checkpoints = new List<Checkpoint>();
    private Vector2 mouse_position, startPosition;
    private Vector3 movePosition = Vector3.zero;
    private Collider2D ballCollider, startHole, swapHole;
    private GameObject text;
    private Checkpoint tempCheckpoint;

    private bool automove;
    private bool picked = false;
    private bool nextCheckpointTeleport = false; //if next checkpoint is teleport... cuz it gets deleted
    public bool enableDragnDrop = true;

    public int value { get; private set; } = -1;
    public int index { get; private set; } = -1;
    public int holeId { get; private set; } = -1;


    private const int
        ZDRAGGED = 6 -  3,
        ZDROPPED = 6 -  1,
        ZANIMATE = 6 + 21;

    // Start is called before the first frame update
    void Start()
    {
        ballCollider = GetComponent<Collider2D>();
        startPosition = transform.position;
        setValue(value);
    }

    // Update is called once per frame
    void Update()
    {
        //mouse_position = Input.mousePosition;
        //mouse_position = Camera.main.ScreenToWorldPoint(mouse_position);
        //mouse_position.z = 0;

        mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (enableDragnDrop && staticDnDEnable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (ballCollider.OverlapPoint(mouse_position))
                {
                    picked = true;
                    Globals.player.oneShot("pick");
                    //changes z of ball+text to 3
                    transform.position = setVecZ(startPosition, ZDRAGGED);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (picked) {
                Globals.player.oneShot("drop");
                picked = false;
                }
                if (swapHole != startHole) { // Ball Movement happens
                    Hole to = swapHole.gameObject.GetComponent<Hole>();
                    if (to.content != null) { // Swap two Balls
                        swapTwo(this, to.content);
                        transform.position = setVecZ(startPosition, ZDROPPED);
                    } else { // Move a single Ball
                        moveToHole(swapHole);
                    }
                } else transform.position = setVecZ(startPosition, ZDROPPED); //changes z of ball+text to 5
            }
        } else
        {
            //for the case picked = true
            //Debug.Log(checkpoints);
            if (automove)
            {
                if (checkpoints.Count == 0)
                {
                    if (movePosition == Vector3.zero) return;
                    if (movePosition == transform.position)
                    {
                        //ende
                        enableDragnDrop = true;
                        automove = false;
                        moving.Remove(this);

                        if (moving.Count == 0)
                        {
                            //set everything to normal again
                            foreach (GameObject g in Globals.self.toMoveZ)
                                g.transform.position = setVecZ(g.transform.position, ZDROPPED);
                            BallMover.AnimationComplete();
                        }

                        //the hole to move 2 (swaphole is only set for treehole)
                        if(tempCheckpoint.overHole != null)
                        {
                            moveToHole(tempCheckpoint.overHole);
                        } else
                        {
                            moveToHole(swapHole);
                        }
                        return;
                    }
                }

                if (movePosition != transform.position && movePosition != new Vector3())
                {
                    //do stuff idk
                } else
                {
                    if (checkpoints.Count == 0) return;

                    tempCheckpoint = checkpoints[0];
                    checkpoints.RemoveAt(0);

                    if (tempCheckpoint.type == Checkpoint.CheckpointType.TELEPORT) nextCheckpointTeleport = true;
                    movePosition = tempCheckpoint.transform.position;
                    //moveSpeed = getScaledSpeed(transform.position, movePosition, 10);
                }

                //wird true gesetzt wenn noch zum näcshten checkpoint gemovt wird deswegen erst wenn der nicht teleport ist (es wird keine 2 teleport hintereinander geben da die sonst zusammengefasst werden können)
                if (nextCheckpointTeleport && tempCheckpoint && tempCheckpoint.type != Checkpoint.CheckpointType.TELEPORT)
                {
                    transform.position = movePosition;
                    nextCheckpointTeleport = false;
                }//*/

                //movespeed wieder scalled setzten
                if (!moving.Contains(this)) moving.Add(this);
                transform.position = Vector3.MoveTowards(transform.position, movePosition, 4.5f * Time.deltaTime);
                return;
            }
        }

        if (picked) transform.position = mouse_position;
    }

    public static void clearMovePosition()
    {
        foreach (Ball b in Globals.balls)
        {
            b.movePosition = new Vector3();
            b.tempCheckpoint = null;
            b.checkpoints.Clear();
        }
        Checkpoint.used = false;
        BallMover.checkpointlist.Clear();
    }

    private float getScaledSpeed(Vector3 pos, Vector3 npos, int speed)
    {
        //not rlly needed anymore

        //for testing
        speed = 12;

        float d = Vector3.Distance(pos, npos);
        //Debug.Log(d);

        return speed / d;
    }

    public static void swapTwo(Ball b1, Ball b2) {
        isSwapping = true;
        Collider2D tmp = b1.startHole;
        if (b1.startHole == null || b2.startHole == null ||
                !b1.startHole.gameObject.GetComponent<Hole>().tree ||
                !b2.startHole.gameObject.GetComponent<Hole>().tree) return;
        b1.moveToHole(b2.startHole);
        b2.moveToHole(tmp);
        isSwapping = masterSwap;
    }

    //Collider 'to' must be the collider of a *HOLE*
    public void moveToHole(Collider2D to) {
        if (to.gameObject.GetComponent<Hole>() == null) return;
        if (startHole != null && !isSwapping) startHole.gameObject.GetComponent<Hole>().setContent(null);
        to.gameObject.GetComponent<Hole>().setContent(this);
        holeId = to.gameObject.GetComponent<Hole>().index;
        fixPosition(to);
    }

    public void moveToHole(Hole ho) {
        Collider2D to = ho.gameObject.GetComponent<Collider2D>();
        if (startHole != null && !isSwapping) startHole.gameObject.GetComponent<Hole>().setContent(null);
        ho.setContent(this);
        holeId = ho.index;
        fixPosition(to);
    }

    //Should only be used in conjunction with moveToHole(), never in isolation
    private void fixPosition(Collider2D coll) {
        startPosition = coll.transform.position;
        transform.position = setVecZ(startPosition, ZDROPPED);

        startHole = coll;
        swapHole = coll;
    }

    public static Vector3 setVecZ(Vector3 vec, float z)
    {
        vec.z = z;
        return vec;
    }
    public static Vector3 addVecZ(Vector3 vec, float z)
    {
        vec.z += z;
        return vec;
    }

    public static Ball spawn(int index, int value, Vector3 pos)
    {
        GameObject ball = Instantiate(Globals.self.ballPrefab, pos, Quaternion.identity);
        ball.transform.SetParent(Globals.self.ballHolder.transform);

        Vector3 ball_pos = addVecZ(ball.transform.position, -0.01f);
        GameObject txt = Instantiate(Globals.self.ballTextPrefab, ball_pos, Quaternion.identity);
        txt.transform.SetParent(ball.transform);

        Ball b = ball.GetComponent<Ball>();
        b.value = value;
        b.index = index;
        b.text = txt;
        return b;
    }

    public void move(Vector3 newPos)
    {
        enableDragnDrop = false;
    }

    public void startAutomaticMove()
    {
        enableDragnDrop = false;
        automove = true;

        // transform.position = setVecZ(transform.position, ZANIMATE - 0.03f * index);
    }

    public void visible(bool v)
    {
        ballCollider.gameObject.SetActive(v);
    }

    public int getValue()
    {
        return value;
    }

    public int getHoleIDofBall()
    {
        return holeId;
    }

    public int getIndex()
    {
        return index;
    }

    public void setValue(int val, bool nums = true)
    {
        Sprite[] sprites = Globals.self.ballsBlank; // nums ? globs.ballsNumbered : globs.ballsBlank;
        value = val % sprites.Length;

        GetComponent<SpriteRenderer>().sprite = sprites[value];
        setText(value.ToString());
    }

    private void setText(string txt)
    {
        TextMesh t = text.GetComponent<TextMesh>();
        t.text = txt;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isSwapping && collider.tag == "Hole" && collider.gameObject.GetComponent<Hole>().tree)
            swapHole = collider;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!isSwapping && collider.tag == "Hole" &&
                collider.gameObject.GetComponent<Hole>().tree &&
                collider == swapHole) swapHole = startHole;
    }
}
