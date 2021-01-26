using UnityEngine;

public class Hole : MonoBehaviour
{
    public int index;
    public bool tree { get; private set; }
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
        tree = isType(TREEHOLE);
        GetComponent<SpriteRenderer>().sprite = Globals.globals.holeSprites[0];
    }

    public void setContent(Ball ball)
    {
        content = ball;
    }

    public static Hole getLastNonEmpty()
    {
        int min = -1;
        foreach (Hole h in Globals.getHoles(TREEHOLE)) {
            min = h.content && (h.index > min) ? h.index : min;
        }
        return min == -1 ? null : Globals.getHoles(TREEHOLE).Find(fh => min == fh.index);
    }

    public bool isType(string type)
    {
        return transform.parent.name == type;
    }
}
