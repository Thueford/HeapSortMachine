using UnityEngine;

public class Bowl : MonoBehaviour
{
    private static Globals globs;

    private Vector3 mouse_position;
    private Collider2D bowlCollider;
    private Collider2D bowlGapCollider;
    private Vector3 startPosition;
    private bool picked = false;
    private bool collide = false;

    public bool enableDragnDrop = true;

    public int value;
    public int holeId { get; private set; } = -1;

    // Start is called before the first frame update
    void Start()
    {
        globs = Globals.TryGetObjWithTag("Background").GetComponent<Globals>();
        bowlCollider = GetComponent<Collider2D>();
        startPosition = transform.position;
        setValue(0);
    }

    // Update is called once per frame
    void Update()
    {
        mouse_position = Input.mousePosition;
        mouse_position = Camera.main.ScreenToWorldPoint(mouse_position);
        mouse_position.z = 0;

        if (enableDragnDrop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (bowlCollider == Physics2D.OverlapPoint(mouse_position))
                {
                    picked = true;
                }
            }
        }

        if (picked == true)
        {
            this.transform.position = mouse_position;
        } 
        else
        {
            if (collide == true)
            {
                this.transform.position = bowlGapCollider.transform.position;
            } 
            else
            {
                //get back to origin position
                this.transform.position = startPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            picked = false;

            
            if (!collide)
            {
                //get back to origin position
                //this.transform.position = startPosition;
            }
        }
    }

    public void setValue(byte val, bool nums = true)
    {
        Sprite[] sprites = nums ? globs.bowlsNumbered : globs.bowlsBlank;
        value = val % sprites.Length;

        setText(value.ToString());
        GetComponent<SpriteRenderer>().sprite = sprites[value];
    }

    private void setText(string text)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Enter Collision");
        bowlGapCollider = collider;
        collide = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Leave Collision");
        collide = false;
    }
}
