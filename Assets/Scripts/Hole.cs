using UnityEngine;

public class Hole : MonoBehaviour
{
    public int value;
    public bool free = true;
    public bool tree = false;

    private void Start()
    {
        Globals.holes.Add(this);
    }
}
