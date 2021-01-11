using UnityEngine;
using System;
using System.Collections.Generic;

public class Bowl : MonoBehaviour
{
    private Globals globs;

    private Vector2 mouse_position;
    private Collider2D bowlCollider;
    private Vector3 startPosition;
    private bool picked = false;
    private GameObject text;
    public GameObject textPrefab;
    public bool enableDragnDrop;
    private List<Collider2D> collisions = new List<Collider2D>();

    public int value;
    public int holeId { get; private set; } = -1;

    // Start is called before the first frame update
    void Start()
    {
        globs = Globals.TryGetObjWithTag("Background").GetComponent<Globals>();
        textPrefab = Globals.globals.bowlTextPrefab;

        bowlCollider = GetComponent<Collider2D>();

        startPosition = transform.position;

        spawnText();
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
                    tempvec.z = 3;

                    this.transform.position = tempvec;


                    // if (false)
                    // {
                    //     tempvec = text.transform.position;
                    //     tempvec.z -= 3;
                    //
                    // }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                picked = false;

                //changes z of bowl+text +2
                Vector3 tempvec = this.transform.position;
                tempvec.z = 5;

                this.transform.position = tempvec;

                // if (false)
                // {
                //     tempvec = text.transform.position;
                //     tempvec.z = 3;
                //
                //     text.transform.position = tempvec;
                // }
            }
        }

        if (picked) this.transform.position = mouse_position;
        else
        {
            if (collisions.Count != 0) startPosition = collisions[collisions.Count-1].transform.position;

            //uses the z coord from the hole so have to change back to 5
            Vector3 tempvec = startPosition;
            tempvec.z = 5;
            this.transform.position = tempvec;
        }
    }
    private void spawnText()
    {
        Vector3 bowl_pos = this.transform.position;
        bowl_pos.z -= 1;
        GameObject txt = Instantiate(textPrefab, bowl_pos, Quaternion.identity);
        txt.transform.SetParent(this.transform);
        text = txt;
    }

    public void setValue(int val, bool nums = true)
    {
        Sprite[] sprites = globs.bowlsBlank; // nums ? globs.bowlsNumbered : globs.bowlsBlank;
        value = val % sprites.Length;

        GetComponent<SpriteRenderer>().sprite = sprites[value];
        
        setText(value.ToString());
        
    }

    private void setText(string txt)
    {
        /*if (!text)
        {
            text = transform.Find("BowlText").gameObject;
        }//*/
        TextMesh t = text.GetComponent<TextMesh>();
        t.text = txt;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Hole" && collider.gameObject.GetComponent<Hole>().free)
        {
            collisions.Add(collider);
            collider.gameObject.GetComponent<Hole>().free = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Hole" && collisions.Contains(collider))
        {
            collisions.Remove(collider);
            collider.gameObject.GetComponent<Hole>().free = true;
        }
    }
}
