using UnityEngine;
using System;
using System.Collections.Generic;

public class Bowl : MonoBehaviour
{
    private Globals globs;

    private Vector2 mouse_position;
    private Collider2D bowlCollider;
    private Collider2D holeCollider;
    public Vector3 startPosition;
    private bool picked;
    // private bool collide;
    private GameObject text;
    public bool enableDragnDrop;
    private List<Hole> collisions = new List<Hole>();

    public int value;
    public int holeId { get; private set; } = -1;

    // Start is called before the first frame update
    void Start()
    {
        globs = Globals.TryGetObjWithTag("Background").GetComponent<Globals>();

        // text = transform.Find("BowlText").gameObject;

        bowlCollider = GetComponent<Collider2D>();

        picked = false;
        // collide = false;
        enableDragnDrop = true;

        //Debug.Log(transform.position);

        startPosition = transform.position;

        //Debug.Log(startPosition);

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
                // Debug.Log(Physics2D.OverlapPoint(mouse_position));
                // if (bowlCollider == Physics2D.OverlapPoint(mouse_position))
                if (bowlCollider.OverlapPoint(mouse_position))
                {
                    picked = true;

                    //changes z of bowl+text -2
                    Vector3 tempvec = this.transform.position;
                    tempvec.z += -3;

                    this.transform.position = tempvec;

                    Debug.Log(transform.position.z);

                    if (false)
                    {
                        tempvec = text.transform.position;
                        tempvec.z -= 3;

                        //text.transform.position = tempvec;
                    }
                }//*/

                /*if (bowlCollider.OverlapPoint(mouse_position))
                {
                    picked = true;
                }//*/
            }

            if (Input.GetMouseButtonUp(0))
            {
                picked = false;

                //changes z of bowl+text +2
                Vector3 tempvec = this.transform.position;
                tempvec.z += 3;

                this.transform.position = tempvec;

                // Debug.Log(transform.position.z);

                if (false)
                {
                    tempvec = text.transform.position;
                    tempvec.z = 3;

                    text.transform.position = tempvec;
                }

                // if (!collide)
                // {
                //     //get back to origin position
                //     //this.transform.position = startPosition;
                // }

            }//*/
        }

        if (picked)
        {
            this.transform.position = mouse_position;
        }
        else
        {
            if (holeCollider != null) {
                startPosition = holeCollider.transform.position;
            }

            this.transform.position = startPosition;

        }

    }

    public void setValue(int val, bool nums = true)
    {
        Sprite[] sprites = globs.bowlsBlank; // nums ? globs.bowlsNumbered : globs.bowlsBlank;
        value = val % sprites.Length;

        GetComponent<SpriteRenderer>().sprite = sprites[value];
        // setText(value.ToString());
    }

    private void setText(string txt)
    {
        TextMesh t = text.GetComponent<TextMesh>();
        t.text = txt;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider.tag);
        //holeCollider = collider;

        if (collider.tag == "Hole")
        {
            Hole hole = collider.gameObject.GetComponent<Hole>();

            if (hole.free)
            {
                collisions.Add(hole);
                holeCollider = collider;
                // collide = true;
                hole.free = false;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //Debug.Log(collide);
        if (collider.tag == "Hole" && collisions.Contains(collider.gameObject.GetComponent<Hole>()))
        {
            Hole hole = collider.gameObject.GetComponent<Hole>();
            collisions.Remove(hole);
            hole.free = true;
            // collide = false;
        }
    }
}
