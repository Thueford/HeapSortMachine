using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private static List<Hole> holes = new List<Hole>(); 
    public int value;
    public bool free = true;
    public bool tree = false;

    private void Awake()
    {
        holes.Add(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static List<Hole> getHoles()
    {
        return holes;
    }
}
