using UnityEngine;

public class Hole : MonoBehaviour
{
    public int value;
    public bool tree = false;
    public Bowl content;

    private void Awake()
    {
        Globals.holes.Add(this);
    }
    public int getHoleValue()
    {
        return this.value;
    }

    public void setContent(Bowl ball) {
        this.content = ball;
    }

    public Bowl getContent() {
        return this.content;
    }
}
