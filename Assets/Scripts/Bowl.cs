using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bowl : MonoBehaviour
{
    private Vector3 mouse_position;
    private Collider2D bowlCollider;
    private Collider2D bowlGapCollider;
    private Vector3 startPosition;
    private bool picked = false;
    private bool collide = false;

    public string displayText;
    public bool enableDragnDrop = true;


    // Start is called before the first frame update
    void Start()
    {
        bowlCollider = GetComponent<Collider2D>();
        startPosition = this.transform.position;

        setText(displayText);

        
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
        } else
        {
            if (collide == true)
            {
                this.transform.position = bowlGapCollider.transform.position;
            } else
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
