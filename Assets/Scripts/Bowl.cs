using UnityEngine;
using System.Collections.Generic;

public class Bowl : MonoBehaviour
{
    private List<Collider2D> collisions = new List<Collider2D>();

    private Vector2 mouse_position;
    private Vector3 startPosition;
    private Collider2D bowlCollider;
    private GameObject text, gameobject;
    private bool picked = false;

    public bool enableDragnDrop;
    public int value, index;
    public int holeId { get; private set; } = -1;

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
                // Debug.Log(Physics2D.OverlapPoint(mouse_position));
                // if (bowlCollider == Physics2D.OverlapPoint(mouse_position))
                if (bowlCollider.OverlapPoint(mouse_position))
                {
                    picked = true;

                    //changes z of bowl+text -2
                    Vector3 tempvec = this.transform.position;
                    tempvec.z = 3;

                    transform.position = tempvec;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                picked = false;

                //changes z of bowl+text +2
                Vector3 tempvec = transform.position;
                tempvec.z = 5;

                transform.position = tempvec;
            }
        }

        if (picked) transform.position = mouse_position;
        else
        {
            if (collisions.Count != 0) startPosition = collisions[collisions.Count-1].transform.position;

            //uses the z coord from the hole so have to change back to 5
            Vector3 tempvec = startPosition;
            tempvec.z = 5;
            transform.position = tempvec;
        }
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
        b.gameobject = bowl;
        b.value = value;
        b.text = txt;
        return b;
    }

    public void setValue(int val, bool nums = true)
    {
        Sprite[] sprites = Globals.globals.bowlsBlank; // nums ? globs.bowlsNumbered : globs.bowlsBlank;
        value = val % sprites.Length;
        this.index = index;

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
        Hole hole = collider.gameObject.GetComponent<Hole>();
        if (collider.tag == "Hole" && hole.free)
        {
            collisions.Add(collider);
            hole.free = false;
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
