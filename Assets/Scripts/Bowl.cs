using UnityEngine;
using System.Collections.Generic;

public class Bowl : MonoBehaviour
{
    private Vector2 mouse_position;
    private Vector3 startPosition;
    private Collider2D bowlCollider, startHole, swapHole;
    private GameObject text;
    private bool picked = false;
    private bool automove;
    private bool nextCheckpointTeleport = false; //if next checkpoint is teleport... cuz it gets deleted
    private float moveSpeed;
    private static bool isSwapping = false;
    private Vector3 movePosition;
    private Checkpoint tempCheckpoint;

    //to know how much bowls are still moving
    public static List<Bowl> moving = new List<Bowl>();

    public bool enableDragnDrop = true;
    public int value, index;
    public int holeId { get; private set; } = -1;

    //list of checkpoints to move
    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    private const int ZDRAGGED = -3;
    private const int ZDROPPED = -1;

    // Start is called before the first frame update
    void Start()
    {
        bowlCollider = GetComponent<Collider2D>();
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

        if (enableDragnDrop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (bowlCollider.OverlapPoint(mouse_position))
                {
                    picked = true;
                    Globals.player.oneShot("pick");
                    //changes z of bowl+text to 3
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
                        if (startHole != null) {
                            isSwapping = true; // To ignore Collision Triggers

                            to.content.moveToHole(startHole);
                            moveToHole(swapHole);

                            isSwapping = false; // To notice Collision Triggers again
                        } else transform.position = setVecZ(startPosition, ZDROPPED);
                    } else { // Move a single Ball
                        moveToHole(swapHole);
                    }
                } else transform.position = setVecZ(startPosition, ZDROPPED); //changes z of bowl+text to 5
            }
        } else
        {
            //for the case picked = true
            //Debug.Log(checkpoints);
            if (automove)
            {
                
                if (checkpoints.Count == 0 && movePosition == new Vector3()) return;
                if (movePosition == new Vector3())
                {
                    //checks for teleport checkpoint
                    if (checkpoints[0].checkpoint == Checkpoint.CheckpointType.TELEPORT)
                    {
                        nextCheckpointTeleport = true;
                    }

                    //pops first element
                    movePosition = checkpoints[0].transform.position;

                    checkpoints.RemoveAt(0);

                    //creates speed
                    moveSpeed = getScaledSpeed(transform.position, movePosition, 10);
                }

                if (movePosition == transform.position)
                {
                    if (checkpoints.Count != 0)
                    {
                        if (nextCheckpointTeleport)
                        {
                            transform.position = checkpoints[0].transform.position;
                            checkpoints.RemoveAt(0);

                            if (checkpoints.Count != 0)
                            {
                                movePosition = checkpoints[0].transform.position;
                                checkpoints.RemoveAt(0);
                            }

                            nextCheckpointTeleport = false;
                            return;
                        }

                        //checks for teleport checkpoint
                        if (checkpoints[0].checkpoint == Checkpoint.CheckpointType.TELEPORT)
                        {
                            nextCheckpointTeleport = true;
                        }

                        movePosition = checkpoints[0].transform.position;
                        checkpoints.RemoveAt(0);

                        //creates speed
                        moveSpeed = getScaledSpeed(transform.position, movePosition, 10);

                    } else
                    {
                        enableDragnDrop = true;
                        automove = false;
                        //transform.position = setVecZ(transform.position, ZDROPPED);

                        //muss swapping gefixt werden
                        //startPosition = transform.position;

                        //not moving anymore
                        moving.Remove(this);
                        //checks of this bowl was last that was moving
                        if (moving.Count == 0)
                        {
                            //set everything to normal again
                            foreach (GameObject g in Globals.globals.toMoveZ)
                            {
                                g.transform.position = addVecZ(g.transform.position, 10);
                            }
                        }

                        moveToHole(swapHole);
                        return;
                    }
                }
                //*/ //Neue implementierung (kurzer aber nicht fertig also nicht ändern @jakob)

                if (checkpoints.Count == 0 && movePosition == new Vector3()) return;

                if (movePosition != transform.position && movePosition != new Vector3())
                {
                    //do stuff idk
                } else
                {
                    if (checkpoints.Count == 0) return;

                    tempCheckpoint = checkpoints[0];
                    checkpoints.RemoveAt(0);

                    if (tempCheckpoint.checkpoint == Checkpoint.CheckpointType.TELEPORT) nextCheckpointTeleport = true;
                    movePosition = tempCheckpoint.transform.position;
                }

                if (nextCheckpointTeleport)
                {
                    transform.position = movePosition;
                    nextCheckpointTeleport = false;
                }//*/

                //movespeed wieder scalled setzten
                if (!moving.Contains(this)) moving.Add(this);
                transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);
                return;
            }
        }

        if (picked) transform.position = mouse_position;
    }

    public static void clearMovePosition()
    {
        foreach (Bowl b in Globals.bowls)
        {
            b.movePosition = new Vector3();
        }
    }

    private float getScaledSpeed(Vector3 pos, Vector3 npos, int speed)
    {
        //for testing
        speed = 12;

        float d = Vector3.Distance(pos, npos);
        Debug.Log(d);

        return speed / d;
    }

    public void moveToHole(Collider2D to) {
        if (startHole != null && !isSwapping) startHole.gameObject.GetComponent<Hole>().setContent(null);
        to.gameObject.GetComponent<Hole>().setContent(this);
        holeId = swapHole.gameObject.GetComponent<Hole>().value;
        fixPosition(to);
    }

    private void fixPosition(Collider2D coll) {
        startPosition = coll.transform.position;
        transform.position = setVecZ(startPosition, ZDROPPED);

        startHole = coll;
        swapHole = coll;
    }

    public static Vector3 setVecZ(Vector3 vec, int z) {
        vec.z = z;
        return vec;
    }
    public static Vector3 addVecZ(Vector3 vec, int z)
    {
        vec.z = z;
        return vec;
    }

    public static Bowl spawn(int index, int value, Vector3 pos)
    {
        GameObject bowl = Instantiate(Globals.globals.bowlPrefab, pos, Quaternion.identity);
        bowl.transform.SetParent(Globals.globals.bowlHolder.transform);

        Vector3 bowl_pos = addVecZ(bowl.transform.position, -1);
        GameObject txt = Instantiate(Globals.globals.bowlTextPrefab, bowl_pos, Quaternion.identity);
        txt.transform.SetParent(bowl.transform);

        Bowl b = bowl.GetComponent<Bowl>();
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

        transform.position = setVecZ(transform.position, ZDRAGGED);
    }

    public void visible(bool v)
    {
        bowlCollider.gameObject.SetActive(v);
    }

    public int getValue()
    {
        return value;
    }

    public int getHoleIDofBowl()
    {
        return holeId;
    }

    public int getIndex()
    {
        return index;
    }

    public void setValue(int val, bool nums = true)
    {
        Sprite[] sprites = Globals.globals.bowlsBlank; // nums ? globs.bowlsNumbered : globs.bowlsBlank;
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
        if (!isSwapping && collider.tag == "Hole" &&
                collider.gameObject.GetComponent<Hole>().tree) swapHole = collider;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!isSwapping && collider.tag == "Hole" &&
                collider.gameObject.GetComponent<Hole>().tree &&
                collider == swapHole) swapHole = startHole;
    }
}
