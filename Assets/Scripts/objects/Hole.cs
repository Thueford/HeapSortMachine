using UnityEngine;

public class Hole : MonoBehaviour
{
    public int value;
    public bool tree = false;
    public Ball content;
    public const string LISTHOLE = "ListHolder";
    public const string TREEHOLE = "TreeHolder";
    public const string SORTHOLE = "SortedHolder";

    private void Awake()
    {
        Globals.holes.Add(this);
    }

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[0];
    }
    public void setContent(Ball ball)
    {
        content = ball;
    }
}
