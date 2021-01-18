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

    public bool enableDragnDrop = true;
    public int value, index;
    public int holeId { get; private set; } = -1;

    //list of checkpoints to move
    public List<Checkpoint> checkpoints = new List<Checkpoint>();

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

                    //changes z of bowl+text to 3
                    transform.position = setVecZ(startPosition, 3);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                picked = false;

                if (swapHole != startHole) { // Ball Movement happens
                    Hole to = swapHole.gameObject.GetComponent<Hole>();
                    if (to.getContent() != null) { // Swap two Balls
                        if (startHole != null) {
                            isSwapping = true; // To ignore Collision Triggers

                            to.getContent().moveToHole(startHole);
                            moveToHole(swapHole);

                            isSwapping = false; // To notice Collision Triggers again
                        } else transform.position = setVecZ(startPosition, 5);
                    } else { // Move a single Ball
                        moveToHole(swapHole);
                    }
                } else transform.position = setVecZ(startPosition, 5); //changes z of bowl+text to 5
            }
        } else
        {
            //for the case picked = true
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
                        transform.position = setVecZ(transform.position, 5);

                        //muss swapping gefixt werden
                        //startPosition = transform.position;
                        moveToHole(swapHole);
                        return;
                    }
                }

                transform.position = Vector3.MoveTowards(transform.position, movePosition, moveSpeed * Time.deltaTime);
            }
        }

        if (picked) transform.position = mouse_position;
    }

    private float getScaledSpeed(Vector3 pos, Vector3 npos, int speed)
    {
        //for testing 
        speed = 2;

        float d = Vector3.Distance(pos, npos);

        return speed / d*5;

        //return 0;
    }

    public void moveToHole(Collider2D to) {
        if (startHole != null && !isSwapping) startHole.gameObject.GetComponent<Hole>().setContent(null);
        to.gameObject.GetComponent<Hole>().setContent(this);
        holeId = swapHole.gameObject.GetComponent<Hole>().value;
        fixPosition(to);
    }

    private void fixPosition(Collider2D coll) {
        startPosition = coll.transform.position;
        transform.position = setVecZ(startPosition, 5);

        startHole = coll;
        swapHole = coll;
    }

    public static Vector3 setVecZ(Vector3 vec, int z) {
        Vector3 tempvec = vec;
        tempvec.z = z;
        return tempvec;
    }

    public static Bowl spawn(int index, int value, Vector3 pos)
    {
        GameObject bowl = Instantiate(Globals.globals.bowlPrefab, pos, Quaternion.identity);
        bowl.transform.SetParent(Globals.globals.bowlHolder.transform);

        Vector3 bowl_pos = bowl.transform.position;
        bowl_pos.z -= 1;
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

        transform.position = setVecZ(transform.position, 3);
    }

    public void visible(bool v)
    {
        if (v)
        {
            bowlCollider.gameObject.SetActive(true);
        } else
        {
            bowlCollider.gameObject.SetActive(false);
        }
    }

    public int getValue()
    {
        return this.value;
    }

    public int getHoleIDofBowl()
    {
        return this.holeId;
    }

    public int getIndex()
    {
        return this.index;
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
        if (!isSwapping && enableDragnDrop && collider.tag == "Hole" &&
                collider.gameObject.GetComponent<Hole>().tree) swapHole = collider;
        if (collider.tag == "Checkpoint" && collider.gameObject.GetComponent<Checkpoint>().checkpoint == Checkpoint.CheckpointType.TELEPORT)
        {
            //teleport to idk
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!isSwapping && enableDragnDrop && collider.tag == "Hole" &&
                collider.gameObject.GetComponent<Hole>().tree &&
                collider == swapHole) swapHole = startHole;
    }
}
